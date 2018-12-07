using OpenApiSample.DTO;
using OpenApiSample.Service;
using OpenApiSample.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenApiSampleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyunit = new CompanyUnitKey { KeyId = 123456, Secret = "9876541236985214" };
            IAgentPower agentPower = new AgentPower(keyunit, null);
            //返回的授信数据，可以缓存，不必每次调用都申请
            var dto2 = agentPower.ApplyToken("用户名", "密码");
            if (dto2.IsSuccess)
            {
                HouseManager houseManager = new HouseManager(keyunit, null);
                //只是案例，没有写全字段，录入不成功，具体哪些字段必填，请查看文档
                HouseSaleDTO houseSale = new HouseSaleDTO()
                {
                    ProjName = "王翠山",
                    Price = 360,
                };
                houseSale.Image1.Add(new Image() { Url = "https://baidu.com", Name = "度娘娘" });
                var dto = houseManager.Save(dto2.Data, houseSale);
                Console.WriteLine(dto);
            }
            Console.Read();
        }
    }
}
