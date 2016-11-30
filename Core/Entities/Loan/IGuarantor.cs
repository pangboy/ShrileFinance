namespace Core.Entities.Loan
{
    /// <summary>
    /// 担保人
    /// </summary>
    public interface IGuarantor
    {
        /// <summary>
        /// 担保人名称
        /// </summary>
        string Name { get; set; }
    }
}
