namespace Model.Sys
{
	/// <summary>
	/// 引用信息
	/// </summary>
	/// qiy		16.03.07
	public class Reference
	{
		public int ReferenceId { get; set; }
		public int ReferencedId { get; set; }
		public int? ReferencedSid { get; set; }
		public int ReferencedModule { get; set; }
	}
}