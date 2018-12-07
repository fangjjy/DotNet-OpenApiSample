using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web;

namespace OpenApiSample.Util
{
    public class OpenApiHttpClient : IOpenApiHttpClient
    {
        //private static HttpClient client=new HttpClient();
        private static ConcurrentDictionary<string, HttpClient> dict = new ConcurrentDictionary<string, HttpClient>();
        private static ReaderWriterLockSlim clientLock = new ReaderWriterLockSlim();
        static OpenApiHttpClient()
        {
            // 
            System.Timers.Timer timer = new System.Timers.Timer(60 * 60 * 1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            clientLock.EnterWriteLock();
            try
            {
                Console.WriteLine("开始清除httpclient队列");
                var keys = dict.Keys;
                foreach (var item in keys)
                {
                    HttpClient client = null;
                    if (dict.TryRemove(item, out client))
                    {
                        client.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("清理httpclient队列异常", ex);
            }
            finally
            {
                clientLock.ExitWriteLock();
            }
        }

        public OpenApiHttpClient(int timeout)
        {
            this.TimeOutMS = timeout;
        }
        public OpenApiHttpClient() : this(10 * 1000)
        {

        }

        private HttpClient TryGetOrAddByDomian(string url)
        {
            var uri = new Uri(url);
            var host = uri.Scheme + "://" + uri.Host + uri.Port;
            HttpClient client;
            if (!dict.TryGetValue(host, out client))
            {
                client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 0, 0, this.TimeOutMS);
                client.BaseAddress = new Uri(host);

                TryAddClient(host, client);
            }
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Connection", " Keep-Alive");
            return client;
        }
        private void TryAddClient(string host, HttpClient client)
        {
            dict.TryAdd(host, client);
        }
        public int TimeOutMS { get; private set; }

        public string GetData(string url, Dictionary<string, string> header)
        {
            clientLock.EnterReadLock();
            try
            {
                var client = TryGetOrAddByDomian(url);

                if (header != null)
                {
                    foreach (var item in header)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);
                    }
                }
                var result = client.GetAsync(url).Result;
                result.EnsureSuccessStatusCode();
                return result.Content.ReadAsStringAsync().Result;
            }
            finally
            {
                clientLock.ExitReadLock();
            }
        }

        public string PostData(string url, Dictionary<string, string> header, Dictionary<string, string> body)
        {
            clientLock.EnterReadLock();
            try
            {
                var encoding = Encoding.UTF8;
                var client = TryGetOrAddByDomian(url);
                if (header != null)
                {
                    foreach (var item in header)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);
                    }
                }
                if (body != null)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (var item in body)
                    {
                        builder.Append(item.Key).Append("=").Append(HttpUtility.UrlEncode(item.Value, encoding)).Append("&");
                    }
                    var content = new StringContent(builder.ToString(), encoding, "application/x-www-form-urlencoded");
                    var result = client.PostAsync(url, content).Result;
                    result.EnsureSuccessStatusCode();
                    return result.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    var result = client.PostAsync(url, null).Result;
                    result.EnsureSuccessStatusCode();
                    return result.Content.ReadAsStringAsync().Result;
                }

            }
            finally
            {
                clientLock.ExitReadLock();
            }
        }

        public string PostData(string url, long keyId, string token, Dictionary<string, string> body)
        {
            var encoding = Encoding.UTF8;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("Token", token);
            request.Headers.Add("KeyId", keyId.ToString());
            request.Headers.Add("DataType", "json");
            StringBuilder builder = new StringBuilder();
            if (body != null)
            {
                foreach (var item in body)
                {
                    builder.Append(item.Key).Append("=").Append(HttpUtility.UrlEncode(item.Value, encoding)).Append("&");
                }
            }
            var content = new StringContent(builder.ToString(), encoding, "application/x-www-form-urlencoded");
            request.ContentType = content.Headers.ContentType.ToString();
            var bytes = content.ReadAsByteArrayAsync().Result;
            request.ContentLength = bytes.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            using (var respose= request.GetResponse().GetResponseStream())
            {
                StreamReader myStreamReader = new StreamReader(respose, encoding);
                string retString = myStreamReader.ReadToEnd();
                return retString;
            } 
        }
    }
}

