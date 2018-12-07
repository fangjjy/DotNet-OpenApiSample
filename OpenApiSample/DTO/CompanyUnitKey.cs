using System;
using System.Collections.Generic;
using System.Text;

namespace OpenApiSample.DTO
{
    /// <summary>
    /// CompanyKeyUnit 从搜房帮申请的key
    /// </summary>
    [Serializable]
    public class CompanyUnitKey
    {
        public long KeyId { get; set; }
        public string Secret { get; set; }
    }
}
