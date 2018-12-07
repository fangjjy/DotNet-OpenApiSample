using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    public class HouseSaleDTO : HouseBaseDTO
    {
        public HouseSaleDTO()
        {
            this.HouseType = HouseType.Sale;
            this.PurposeType = Purpose.House;
            this.Image1 = new List<Image>();
            this.Image2 = new List<Image>();
            this.Image3 = new List<Image>();
        }
        /// <summary>
        ///  建筑形式
        /// </summary>
        public string BuildingType { get; set; }
        /// <summary>
        ///  PayInfo
        /// </summary>
        public int Room { get; set; }
        /// <summary>
        ///  厅
        /// </summary>
        public int Hall { get; set; }
        /// <summary>
        ///  卫生间
        /// </summary>
        public int Toilet { get; set; }
        /// <summary>
        ///  厨房
        /// </summary>
        public int Kitchen { get; set; }
        /// <summary>
        ///  阳台
        /// </summary>
        public int Balcony { get; set; }
        /// <summary>
        ///  厅结构
        /// </summary>
        public string HouseStructure { get; set; }
        /// <summary>
        ///  地下室类型
        /// </summary>
        public string ShopType { get; set; }
        /// <summary>
        ///  花园面积（如果有）
        /// </summary>
        public double SpaceArea { get; set; }
        /// <summary>
        ///  车库数量
        /// </summary>
        public int Garage { get; set; }
        /// <summary>
        ///  车位数量（如果有）
        /// </summary>
        public int ParkingPlace { get; set; }
        /// <summary>
        ///  使用面积
        /// </summary>
        public double LiveArea { get; set; }
        /// <summary>
        ///  建筑年代
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        ///  进门朝向
        /// </summary>
        public string Forward { get; set; }
        /// <summary>
        ///  装修程度
        /// </summary>
        public string Fitment { get; set; }
        /// <summary>
        ///  配套设施
        /// </summary>
        public string BaseService { get; set; }
        /// <summary>
        ///  看房时间
        /// </summary>
        public string LookHouse { get; set; }

        /// <summary>
        ///  房源标签
        /// </summary>
        public string Feature { get; set; }
        /// <summary>
        ///  社（小）区配套（只有住宅别墅有，其他物业类型留备）
        /// </summary>
        public string Communitymatching { get; set; }
        /// <summary>
        ///  服务介绍（只有住宅别墅有，其他物业类型留备）
        /// </summary>
        public string Serviceintroduction { get; set; }
        /// <summary>
        ///  业主心态（只有住宅别墅有，其他物业类型留备）
        /// </summary>
        public string Ownermentality { get; set; }
        /// <summary>
        ///  税费分析（只有住宅别墅有，其他物业类型留备）
        /// </summary>

        public string Taxanalysis { get; set; }
        /// <summary>
        ///  地下室面积
        /// </summary>
        public long WorkshopArea { get; set; }
        /// <summary>
        ///  室内图
        /// </summary>
        public List<Image> Image1 { get; set; }
        /// <summary> /// 
        ///  小区图
        /// </summary>
        public List<Image> Image2 { get; set; }
        /// <summary> ///    
        ///  户型图
        /// </summary>
        public List<Image> Image3 { get; set; }
    }
}
