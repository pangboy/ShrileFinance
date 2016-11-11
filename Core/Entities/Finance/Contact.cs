namespace Core.Entities.Finance
{
    using System;

    /// <summary>
    /// 合同
    /// </summary>
    public class Contact : Entity
    {
        /// <summary>
        /// 合同名称
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 合同日期
        /// </summary>
        public DateTime Date { get; set; }
    }
}
