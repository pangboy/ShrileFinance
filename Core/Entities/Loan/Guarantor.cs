namespace Core.Entities.Loan
{
    /// <summary>
    /// 担保人
    /// </summary>
    public abstract class Guarantor : Entity
    {
        /// <summary>
        /// 担保人名称
        /// </summary>
        public string Name { get; set; }
    }
}
