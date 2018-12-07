using OpenApiSample.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.Service
{
    public interface IAgentPower : IServiceBase
    {

        CommonReturnDTO<AuthDTO> ApplyToken(string username, string pwd);

         List<AgentPowerInfoDTO> GetAgentPowerInfo(AuthDTO atuh);
    }
}
