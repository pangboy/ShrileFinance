namespace Models.Flow
{
    /// <summary>
    /// 表单状态
    /// </summary>
    /// wangpf  16.09.11
    public enum FormStatusEnum
    {
        禁用 = 0,
        启用 = 1,
        部分禁用 = 2
    }

    /// <summary>
    /// 流程表单
    /// </summary>
    /// wangpf  16.08.29
    public class FlowForm
    {
        /// <summary>
        /// 表单Id
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// 所属流程Id
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        /// 表单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表单链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 表单状态
        /// </summary>
        public FormStatusEnum Status { get; set; }

        /// <summary>
        /// 是否打开状态
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// 是否需要处理
        /// </summary>
        public bool IsHandler { get; set; }
    }
}
