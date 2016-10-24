namespace Models.Flow
{
    /// <summary>
    /// 行为信息
    /// </summary>
    /// qiy		16.03.07
    /// qiy     16.04.29    字段调整
    /// wangpf  16.08.29    字段调整,添加了BusinessMethod
    public class ActionInfo
    {
        public int ActionId { get; set; }
        public string Name { get; set; }
        public int NodeId { get; set; }
        public int? Transfer { get; set; }
        public TypeEnum Type { get; set; }
        public AllocationEnum AllocationType { get; set; }
        public string Description { get; set; }
        public string Method { get; set; }
        /// <summary>
        /// 调用的业务方法名
        /// </summary>
        public string BusinessMethod { get; set; }


        public enum TypeEnum : byte
        {
            发起 = 1,
            流转 = 2,
            完成 = 3,
            终止 = 4
        }

        public enum AllocationEnum : byte
        {
            角色 = 1,
            指定 = 2,
            记录 = 3,
            不指定 = 4,
            渠道经理 = 5,
            发起者 = 6,
            自己 = 7
        }
    }
}
