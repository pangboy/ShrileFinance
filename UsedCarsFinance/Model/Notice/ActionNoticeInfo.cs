using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Notice
{
    /// <summary>
    /// 行为通知实体
    /// </summary>
    /// yand    16.09.10
    public class ActionNoticeInfo
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// 通知标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 通知内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 是否系统通知
        /// </summary>
        public bool SystemNotice { get; set; }

        /// <summary>
        /// 是否邮件通知
        /// </summary>
        public bool EmailNotice { get; set; }

        /// <summary>
        /// 查找人方式（1表示已经操作的人，2下一个操作者，3已操作和下一个操作者）
        /// </summary>
        public int FindPeopleType { get; set; }

    }
}
