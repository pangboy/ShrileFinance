using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{
    public class EmailUtil
    {
        public bool SendEmail(Mail mail)
        {
            if (mail == null)
            {
                return false;
            }

            try
            {
                MailMessage msg = new MailMessage();

                msg.From = new MailAddress(mail.From);
                msg.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");

                char[] separator = { ';' };

                if (mail.To != null)
                {
                    string[] arrToAddress = mail.To.Split(separator);
                    foreach (string toAddress in arrToAddress)
                    {
                        if (toAddress != string.Empty)
                        {
                            msg.To.Add(new MailAddress(toAddress));
                        }
                    }
                }

                if (mail.Cc != null)
                {
                    string[] arrCCAddress = mail.Cc.Split(separator);
                    foreach (string ccAddress in arrCCAddress)
                    {
                        if (ccAddress != string.Empty)
                        {
                            msg.CC.Add(new MailAddress(ccAddress));
                        }
                    }
                }

                if (mail.Bcc != null)
                {
                    string[] arrBCCAddress = mail.Bcc.Split(separator);
                    foreach (string bccAddress in arrBCCAddress)
                    {
                        if (bccAddress != string.Empty)
                        {
                            msg.Bcc.Add(new MailAddress(bccAddress));
                        }
                    }
                }

                msg.Body = mail.Body;
                msg.Subject = mail.Subject;

                if (string.Compare(mail.BodyFormat, "html", true) == 0)
                {
                    msg.IsBodyHtml = true;
                }
                else
                {
                    msg.IsBodyHtml = false;
                }

                SmtpClient smtpClient = new SmtpClient();

                // 开启SSL服务
                smtpClient.EnableSsl = true;

                // 指定电子邮件发送方式
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                // 指定SMTP服务器
                smtpClient.Host = mail.SmtpServer;

                if (mail.From.Length > 0)
                {
                    // 用户名和密码
                    smtpClient.Credentials = new System.Net.NetworkCredential(mail.From, mail.FromPassword);
                }

                smtpClient.Send(msg);
            }

            catch (Exception )
            {
                return false;
            }

            return true;
        }
    }
}
