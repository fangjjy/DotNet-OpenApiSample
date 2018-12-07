using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OpenApiSample.Util
{
    public static class EncryptHelper
    {
        /// <summary>
        /// 加密帮助方法
        /// </summary>
        /// <param name="secret">秘钥兼向量</param>
        /// <param name="content">待加密字符串</param>
        /// <returns>返回base64的加密传</returns>
        public static string DesEncrypt(string secret, string content)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            secret = secret + "00000000";
            secret = secret.Substring(0, 8);
            byte[] inputByteArray = Encoding.UTF8.GetBytes(content);
            des.Key = Encoding.UTF8.GetBytes(secret);
            des.IV = Encoding.UTF8.GetBytes(secret);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
