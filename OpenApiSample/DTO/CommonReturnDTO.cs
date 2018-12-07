using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    public class CommonReturnDTO<T> : ReturnDTO
    {
        [JsonProperty("returnmsgs")]
        public T Data { get; set; }
    }


    /// <summary>
    /// 授权返回数据
    /// </summary>
   [Serializable]
    public class AuthDTO
    {
        public string Token { get; set; }
        [JsonProperty("URL")]
        public string Domain { get; set; }   
        public long BUserId { get; set; }
    }
    /// <summary>
    /// 租售类型
    /// </summary>
    public enum HouseType
    {
        Sale,
        Lease
    }
    /// <summary>
    /// 物业类型
    /// </summary>
    public enum Purpose
    {
        House,
        Villa,
        Shop,
        Office
    }
}
