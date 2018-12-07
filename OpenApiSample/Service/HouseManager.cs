using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using OpenApiSample.DTO;
using OpenApiSample.Util;

namespace OpenApiSample.Service
{
    public class HouseManager : IHouseManage
    {
        private IOpenApiHttpClient client;
        private static Dictionary<Type, List<PropertyInfo>> typePropertys = new Dictionary<Type, List<PropertyInfo>>();
          
        public HouseManager(CompanyUnitKey unitKey,IOpenApiHttpClient client)
        {
            this.FangOpenApiDomain = "http://openapi.agentn.fang.com";
            this.KeyUnit = unitKey;
            this.client = client ?? new OpenApiHttpClient();
        }
        public CompanyUnitKey KeyUnit { get; set; }
        public string FangOpenApiDomain { get; set; }
        /// <summary>
        /// 房源保存
        /// </summary>
        /// <param name="auth">录入到那个经纪人</param>
        /// <param name="house">录入的房源</param>
        /// <param name="ptype">房源推广端</param>
        /// <returns></returns>
        public CommonReturnDTO<HouseReturnDTO> Save(AuthDTO auth, HouseBaseDTO house, PType ptype = PType.Default)
        {
            var dict = ConvertDTOToDict(house);
            var header = new Dictionary<string, string>();
            header.Add("KeyId", this.KeyUnit.KeyId.ToString());
            header.Add("DataType", "json");
            header.Add("Token", auth.Token);
            if (ptype != PType.Default)
            {
                dict.Add("ptype", ((int)ptype).ToString());
            }
            var result = client.PostData(auth.Domain + "/house/input", header, dict);
            return JsonConvert.DeserializeObject<CommonReturnDTO<HouseReturnDTO>>(result);

        }

      
        private Dictionary<string, string> ConvertDTOToDict<T>(T obj) where T : new()
        {
            var tt = obj.GetType();
            var flag = typePropertys.ContainsKey(tt);
            var list = new List<PropertyInfo>();
            if (!flag)
            {
                var pps = tt.GetProperties();
                foreach (PropertyInfo item in pps)
                {
                    list.Add(item);
                }
            }
            else
            {
                list = typePropertys[tt];
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var item in list)
            {
                var temp = item.GetValue(obj);
                string val = "";
                if (item.Name.StartsWith("Image"))
                {
                   val=  temp == null ? "" : JsonConvert.SerializeObject(temp);
                }
                else
                {
                    val= temp == null ? "" : temp.ToString();
                }
                if(!string.IsNullOrEmpty(val))
                {
                    dict.Add(item.Name.ToLower(), val);
                }
            }
            return dict;
        }

    }
}
