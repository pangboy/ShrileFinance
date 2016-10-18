using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using BLL.Flow;
using BLL.Tools;
using Model;
using Model.Flow;
using Model.Notice;
using Model.User;
using System.Transactions;

namespace BLL.Notice
{
    public class Notice
    {
        private static readonly DAL.Notice.NoticeMapper NoticeMapper = new DAL.Notice.NoticeMapper();

        /// <summary>
        /// 查找指定通知
        /// </summary>
        /// zouql   16.08.29
        /// <param name="id">用户标识</param>
        /// <returns>通知</returns>
        public NoticeInfo Get(int id)
        {
            return NoticeMapper.Find(id);
        }

        /// <summary>
        /// 查找指定用户（已读/未读）的通知
        /// </summary>
        /// zouql   16.08.29
        /// <param name="userId">用户标识</param>
        /// <param name="isRead">是否已读</param>
        /// <param name="pagination">分页</param>
        /// <returns>通知集合</returns>
        public DataTable Get(int userId, bool isRead = false, Model.Pagination pagination = null)
        {
            return NoticeMapper.Find(userId, isRead, pagination);
        }

        /// <summary>
        /// 根据用户ID查找
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetByUserId(int userId)
        {
            return NoticeMapper.FindByUserId(userId);
        }

        /// <summary>
        /// 查找指定用户所有的通知
        /// </summary>
        /// zouql   16.08.29
        /// <param name="userId">用户标识</param>
        /// <param name="pagination">分页</param>
        /// <returns>通知</returns>
        public DataTable GetAll(int userId, Model.Pagination pagination = null)
        {
            return NoticeMapper.FindAll(userId, pagination);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// zouql   16.08.29
        /// <param name="noticeReceiver">通知实体</param>
        /// <returns>插入结果</returns>
        public bool Add(Model.Notice.NoticeInfo noticeReceiver)
        {
            return NoticeMapper.Insert(noticeReceiver) > 0;
        }

        /// <summary>
        /// 发送邮件通知,并记录邮件
        /// </summary>
        /// wangpf  16.09.12
        /// <param name="mail">邮箱内容等配置实体</param>
        /// <returns></returns>
        public bool SendEmail(List<Mail> mail)
        {
            bool result = true;
            var emailUtil = new EmailUtil();

            using (TransactionScope scope = new TransactionScope())
            {

                foreach (Mail item in mail)
                {
                    var isEmail = Regex.IsMatch(item.To, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

                    // 判断邮箱格式是否合法，如果合法则发送邮件
                    if (isEmail == true)
                    {
                        // 发送邮件
                        result &= emailUtil.SendEmail(item);

                        // 记录邮件
                        NoticeInfo notice = new NoticeInfo()
                        {
                            UserId = item.UserId,
                            Title = item.Title,
                            Content = item.Body,
                            Time = DateTime.Now,
                            NoticeType = NoticeType.邮件,
                            IsRead = false
                        };

                        result &= NoticeMapper.Insert(notice) > 0;
                    }
                }

                if (result)
                {
                    scope.Complete();
                }
            }

            return result;
        }

        /// <summary>
        /// 发送系统通知
        /// </summary>
        /// <param name="notices">消息通知实体类</param>
        /// <returns></returns>
        public bool SendSystem(List<NoticeInfo> notices)
        {
            bool result = true;

            using (TransactionScope scope = new TransactionScope())
            {
                foreach (NoticeInfo item in notices)
                {
                    result &= NoticeMapper.Insert(item) > 0;
                }
                if (result)
                {
                    scope.Complete();
                }
            }

            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// zouql   16.08.29
        /// <param name="noticeReceiver">通知实体</param>
        /// <returns>更新结果</returns>
        public bool Modify(Model.Notice.NoticeInfo noticeReceiver)
        {
            return NoticeMapper.Update(noticeReceiver) > 0;
        }

        /// <summary>
        /// 更新是否已读
        /// </summary>
        /// zouql   16.08.29
        /// <param name="idList">标识List</param>
        /// <param name="isRead">IsRead新值</param>
        /// <returns>更新结果</returns>
        public bool ModifyIsRead(List<string> idList, bool isRead = true)
        {
            return NoticeMapper.UpdateIsRead(idList, isRead) > 0;
        }
    }
}
