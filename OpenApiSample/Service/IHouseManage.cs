using System;
using System.Collections.Generic;
using System.Text;
using OpenApiSample.DTO;

namespace OpenApiSample.Service
{
    public interface IHouseManage : IServiceBase
    {

        CommonReturnDTO<HouseReturnDTO> Save(AuthDTO atuh,HouseBaseDTO house, PType ptype);


    }
}
