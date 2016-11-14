namespace Core.Entities.Finance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 融资扩展
    /// </summary>
    public class FinanceExtension : Entity
    {
        /// <summary>
        /// 合同文件Json
        /// </summary>
        public string ContactJson { get; set; }
    }
}
