using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// wangpf  16.09.12 添加用户Id字段
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 收件人地址
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 发件人地址
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 发件人密码
        /// </summary>
        public string FromPassword { get; set; }

        /// <summary>
        /// 抄送人地址 多个应；隔开
        /// </summary>
        public string Cc { get; set; }

        /// <summary>
        /// 邮件密送人地址
        /// </summary>
        public string Bcc { get; set; }

        /// <summary>
        /// 邮件正文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 邮件的主题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 附件地址
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 邮件编码
        /// </summary>
        public string Encode { get; set; }

        /// <summary>
        /// 发送邮件服务地址
        /// </summary>
        public string SmtpServer { get; set; }

        /// <summary>
        /// 获取或设置此电子邮件的主题行
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 邮件模版编号
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// 邮件内容样式
        /// </summary>
        public string BodyFormat { get; set; }
    }
}
