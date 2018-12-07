using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using OpenApiSample.DTO;
using OpenApiSample.Util;

namespace OpenApiSample.Service
{
    public class AgentPower : IAgentPower
    {
        private IOpenApiHttpClient client;
        /// <summary>
        ///
        /// </summary>
        /// <param name="unitKey">房天下申请的key</param>
        /// <param name="client">http请求实现，传null走默认</param>
        public AgentPower(CompanyUnitKey unitKey, IOpenApiHttpClient client)
        {
            this.FangOpenApiDomain = "http://openapi.agentn.fang.com";
            this.KeyUnit = unitKey;
            this.client = client ?? new OpenApiHttpClient();
        }
        public CompanyUnitKey KeyUnit { get; set; }
        public string FangOpenApiDomain { get; set; }

        /// <summary>
        /// 授权申请接口
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public CommonReturnDTO<AuthDTO> ApplyToken(string username, string pwd)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("username", username);
            keyValues.Add("pwd", EncryptHelper.DesEncrypt(this.KeyUnit.Secret, pwd));
            keyValues.Add("keyid", this.KeyUnit.KeyId.ToString());
            var str = client.PostData(this.FangOpenApiDomain + "/agent/UserLoginAuthenticate", null, keyValues);
            return JsonConvert.DeserializeObject<CommonReturnDTO<AuthDTO>>(str);
        }

        public List<AgentPowerInfoDTO> GetAgentPowerInfo(AuthDTO atuh)
        {
            throw new NotImplementedException();
        }
    }
}
