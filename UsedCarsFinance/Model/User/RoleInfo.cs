namespace Models.User
{
	/// <summary>
	/// 角色信息
	/// </summary>
	/// qiy		16.03.07
	public class RoleInfo
	{
		[Alias("UR_ID")]
		public int RoleId { get; set; }
		public string Name { get; set; }
		[Newtonsoft.Json.JsonIgnore]
		public byte Power { get; set; }
	}
}
