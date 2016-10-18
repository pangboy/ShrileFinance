using System;
using System.Collections.Generic;

namespace Model.User
{
	/// <summary>
	/// 用户信息
	/// </summary>
	/// qiy		15.11.16
	/// qiy		16.03.07
	public class UserInfo
	{
		[Alias("UI_ID")]
		public int UserId { get; set; }
		public int RoleId { get; set; }
		[Alias("Realname")]
		public string Name { get; set; }
		public string Username { get; set; }
		[Newtonsoft.Json.JsonIgnore]
		public string Password { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public StatusEnum Status { get; set; }
		public DateTime RegisterDate { get; set; }
		public string Remarks { get; set; }


		public enum StatusEnum : byte
		{
			停用 = 0,
			正常 = 1
		}
	}
}
