using System;

namespace Models.Flow
{
	/// <summary>
	/// 记录信息
	/// </summary>
	/// qiy		16.03.07
    /// qiy     16.04.28    字段修改
	public class LogInfo
	{
		public long LogId { get; set; }
		public int InstanceId { get; set; }
		public int NodeId { get; set; }
		public int ActionId { get; set; }
		public int ProcessUser { get; set; }
		public DateTime ProcessTime { get; set; }
		public string Content { get; set; }
        public string InOpinion { get; set; }
        public string ExOpinion { get; set; }
	}
}
