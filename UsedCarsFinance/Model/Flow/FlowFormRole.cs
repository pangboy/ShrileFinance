namespace Models.Flow
{
    /// <summary>
    /// 流程表单与角色关系
    /// </summary>
    /// wangpf  16.08.29
    public class FlowFormRole
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 表单Id
        /// </summary>
        public int FromId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public byte Status { get; set; }
    }
}
