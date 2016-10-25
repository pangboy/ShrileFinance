namespace Models.Sys
{
	/// <summary>
	/// 引用类
	/// </summary>
	/// qiy		16.03.20
	public class ReferenceInfo
	{
		/// <summary>
		/// 引用标识
		/// </summary>
		public int ReferenceId { get; set; }
		/// <summary>
		/// 被引用标识
		/// </summary>
		public int? ReferencedId { get; set; }
		/// <summary>
		/// 被引用子标识
		/// </summary>
		public int? ReferencedSid { get; set; }
		/// <summary>
		/// 被引用模块
		/// </summary>
		public int? ReferencedModule { get; set; }
	}
}
