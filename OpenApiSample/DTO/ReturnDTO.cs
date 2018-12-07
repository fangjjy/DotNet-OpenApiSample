using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    public class ReturnDTO
    {       
        public int Code { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                if (this.Code == 1)
                {
                    return true;

                }
                return false;
            }
        }
    }
}
