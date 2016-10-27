namespace Core.Entities.Customers.Enterprise
{
    /// <summary>
    /// 股东
    /// </summary>
    public abstract class Stockholder : Entity
    {
        /// <summary>
        /// 股东类型
        /// </summary>
        public string ShareholdersType { get; set; }

        /// <summary>
        /// 股东名称
        /// </summary>
        public string ShareholdersName { get; set; }

        /// <summary>
        /// 持股比例
        /// </summary>
        public decimal SharesProportion { get; set; }
    }
}
