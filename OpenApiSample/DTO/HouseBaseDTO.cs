using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    public class HouseBaseDTO
    {/// <summary>
     /// 
     /// </summary>
        public HouseType HouseType { get; protected set; }

        /// <summary>
        ///  楼盘字典名称
        /// </summary>

        public string ProjName { get; set; }
        /// <summary>
        ///  楼盘字典id
        /// </summary>
        public long NewCode { get; set; }
        /// <summary>
        ///  楼盘所在区县
        /// </summary>

        public string District { get; set; }
        /// <summary>
        ///  楼盘所在商圈
        /// </summary>

        public string Comarea { get; set; }
        /// <summary>
        ///  物业地址
        /// </summary>

        public string Address { get; set; }
        /// <summary>
        ///  物业类型（住宅，别墅、商铺、写字楼）
        /// </summary>
        public Purpose PurposeType { get;protected set; }
        /// <summary>
        ///  价格
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        ///  建筑面积
        /// </summary>

        public double BuildingArea { get; set; }
        /// <summary>
        ///  房源内部编号
        /// </summary>
        public string InnerId { get; set; }
        /// <summary>
        ///  标 题 图
        /// </summary>
        public string PhotoUrl { get; set; }
        /// <summary>
        ///  房源信息编码
        /// </summary>
        public string InfoCode { get; set; }
        /// <summary>
        ///  总楼层数
        /// </summary>
        public int AllFloor { get; set; }
        /// <summary>
        ///  房源描述
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///  交通状况
        /// </summary>
        public string Trafficinfo { get; set; }
        /// <summary>
        ///  房源标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///  周边配套
        /// </summary>
        public string SubwayInfo { get; set; }
        /// <summary>
        ///  视频的地址，如果值是字符串null,表示删除视频，如果不传或是空代表视频不做修改
        /// </summary>
        public string VideoUrl { get; set; }
        /// <summary>
        ///  视频标题
        /// </summary>
        public string VideoTitle { get; set; }
    }
}
