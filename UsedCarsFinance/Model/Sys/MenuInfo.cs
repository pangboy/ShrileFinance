using System.Collections.Generic;

namespace Models.Sys
{
	/// <summary>
	/// 菜单信息
	/// </summary>
	/// qiy		16.03.07
	public class MenuInfo
	{
		[Alias("MN_ID")]
		public int MenuId { get; set; }
		public string Name { get; set; }
		public string Link { get; set; }
		public int? ParentId { get; set; }
		public List<MenuInfo> Children { get; set; }
		public bool HasPermission{ get; set; }
		public byte Sort { get; set; }
	}
}
