using OpenApiSample.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.Service
{
  public  interface IServiceBase
    {
         CompanyUnitKey KeyUnit { get; set; }
        string FangOpenApiDomain { get; set; }
    }
}
