using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Notice
{
    /// <summary>
    /// 通知类型（邮件、短信、系统通知）
    /// </summary>
    /// zouql   16.08.29
    public enum NoticeType
    {
        邮件 = 0,

        短信 = 1,

        系统提示 = 2
    }

    /// <summary>
    /// 通知目标（用户、角色）、通知内容、通知时间、标题、状态（已读未读）、类型（邮件、短信、系统通知）
    /// </summary>
    public class NoticeInfo
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Alias("NR_ID")]
        public int Id { get; set; }

        /// <summary>
        /// 通知目标标识
        /// </summary>
        /// zouql   16.08.29
        public int UserId { get; set; }

        /// <summary>
        /// 通知内容
        /// </summary>
        /// zouql   16.08.29
        public string Content { get; set; }

        /// <summary>
        /// 通知时间
        /// </summary>
        /// zouql   16.08.29
        public DateTime Time { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        /// zouql   16.08.29
        public string Title { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        /// zouql   16.08.29
        public bool IsRead { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        /// zouql   16.08.29
        public NoticeType NoticeType { get; set; }
    }
}
