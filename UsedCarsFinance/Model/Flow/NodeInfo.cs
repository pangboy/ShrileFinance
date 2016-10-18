namespace Model.Flow
{
	/// <summary>
	/// 节点信息
	/// </summary>
	/// qiy		16.03.07
    /// qiy     16.04.29    字段调整
	public class NodeInfo
	{
		public int NodeId { get; set; }
		public int FlowId { get; set; }
		public int RoleId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
