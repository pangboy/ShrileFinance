namespace Models.Flow
{
    /// <summary>
    /// 流程表单与流程行为关系
    /// </summary>
    /// wangpf  16.08.29
    public class FlowFormNode
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public int NodeId { get; set; }
        /// <summary>
        /// 表单Id
        /// </summary>
        public int FormId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 是否默认打开状态
        /// </summary>
        public bool IsOpen { get; set; }
        /// <summary>
        /// 是否允许操作
        /// </summary>
        public bool IsHandler { get; set; }
    }
}
