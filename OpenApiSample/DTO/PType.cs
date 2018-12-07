using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    public enum PType
    {
        /// <summary>
        /// 搜房帮
        /// </summary>
        SFB=2,
        /// <summary>
        /// 住房帮
        /// </summary>
        ZFB=8,
        /// <summary>
        ///商铺帮
        /// </summary>
        Shop=16,
        /// <summary>
        /// 办公帮
        /// </summary>
        Office=32,
        /// <summary>
        /// 系统默认推广
        /// </summary>
        Default=0

    }
}
