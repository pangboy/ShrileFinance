using System;

namespace Models.Sys
{
	/// <summary>
	/// 操作记录信息
	/// </summary>
	/// qiy		16.03.07
	public class OperationLogInfo
    {
       [Alias("OL_ID")]
        public int LogId { get; set; }
       public int ReferenceId { get; set; }
       public byte Type { get; set; }
       public string Content { get; set; }
       public int UserId { get; set; }
       public DateTime AddDate { get; set; }
    }
}
