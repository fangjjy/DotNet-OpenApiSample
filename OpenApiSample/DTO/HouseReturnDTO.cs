using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    /// <summary>
    /// 房源录入修改返回实体
    /// </summary>
    public class HouseReturnDTO
    {
        ///<summary>
        /// 房源id
        ///</summary>
        public int HouseId { get; set; }
        ///<summary>
        /// 房源的内部编号
        ///</summary>
        public string Innerid { get; set; }
        ///<summary>
        /// 房源
        ///</summary>
        public string HouseUrl { get; set; }
        ///<summary>
        /// 房源推广成功是1，否则是2
        ///</summary>
        public int Flag { get; set; }
        ///<summary>
        /// 推广的端，表示房源推广到了那些端
        ///</summary>
        public List<int> Promotedto { get; set; }
    }
}
