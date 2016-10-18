namespace Model.Sys
{
	/// <summary>
	/// 字典类型信息
	/// </summary>
	/// qiy		16.03.07
	public class DictionaryTypeInfo
	{
		[Alias("DT_ID")]
		public int TypeId { get; set; }
		public string Field { get; set; }
		public string Name { get; set; }
		public bool IsCommon { get; set; }
		public int Seed { get; set; }
	}
}
