using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class AgentPowerInfoDTO
    {
        /// <summary>
        ///  最大可推广房源量
        /// </summary>
        [JsonProperty("housemax")]
        public int HouseMax { get; set; }
        /// <summary>
        ///  已推广房源量
        /// </summary>
        [JsonProperty("houseusecount")]

        public int HouseUseCount { get; set; }
        /// <summary>
        ///  套餐版本
        /// </summary>
        [JsonProperty("productversion")]

        public int ProductVersion { get; set; }
        /// <summary>
        ///  产品类型（说明：2 搜房帮； 4 品牌公寓； 8 租房帮； 16 商铺帮； 32 办公帮）
        /// </summary>
        [JsonProperty("producttype")]

        public int ProductType { get; set; }

    }
}
