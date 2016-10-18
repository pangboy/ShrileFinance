using System;

namespace Model.Flow
{
	/// <summary>
	/// 实例信息
	/// </summary>
	/// qiy		16.03.07
	public class InstanceInfo
	{
		public int InstanceId { get; set; }
		public int FlowId { get; set; }
		public int? CurrentNode { get; set; }
		public int? CurrentUser { get; set; }
		public int ProcessUser { get; set; }
		public DateTime ProcessTime { get; set; }
		public int StartUser { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public StatusEnum Status { get; set; }
		public object InstanceData { get; set; }

		
		public enum StatusEnum : byte
		{
			正常 = 1,
			完成 = 2,
			终止 = 3
		}
	}
}
