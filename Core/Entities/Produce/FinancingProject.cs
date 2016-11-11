namespace Core.Entities.Produce
{
    using Interfaces;

    /// <summary>
    /// 融资项目
    /// </summary>
    public class FinancingProject : Entity, IAggregateRoot
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否为可融项目
        /// </summary>
        public bool IsFinancing { get; set; }
    }
}
