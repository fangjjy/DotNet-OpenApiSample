using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.Util
{
    public interface IOpenApiHttpClient
    {
        int TimeOutMS { get;  }
        string PostData(string uri, Dictionary<string, string> header,  Dictionary<string,string> body);
    //    string PostData(string url, long keyId, string token, Dictionary<string, string> body);
        string GetData(string uri,Dictionary<string, string> header);
    }
}
