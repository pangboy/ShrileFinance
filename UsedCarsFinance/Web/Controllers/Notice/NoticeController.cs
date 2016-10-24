using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using BLL.Tools;
using Models;
using Models.Notice;
using Models.User;

namespace Web.Controllers.Notice
{
    public class NoticeController : ApiController
    {
        private static readonly BLL.Notice.Notice Notice = new BLL.Notice.Notice();
        private static readonly BLL.Notice.ActionNotice ActionNotice = new BLL.Notice.ActionNotice();
        private static readonly BLL.User.User Users = new BLL.User.User();

        /// <summary>
        /// 接收者忽略消息接口
        /// </summary>
        /// zouql   16.08.30
        /// <param name="idList">标识集合</param>
        /// <returns>处理结果</returns>
        [HttpGet]
        public IHttpActionResult ReceiverIgnoreNotices(string idList)
        {
            var list = idList.Split(',').ToList();

            // 更新消息为已读
            var result = Notice.ModifyIsRead(list);
            return Ok(result);
        }

        /// <summary>
        /// 接收者查看消息接口
        /// </summary>
        /// zouql   16.08.30
        /// <param name="id">标识集合</param>
        /// <returns>处理结果</returns>
        public IHttpActionResult ReceiverReadNotices(int? id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            // 获取指定消息
            var result = Notice.Get(id.Value);

            return Ok(result);
        }

        /// <summary>
        /// 获取指定用户（已读/未读）的通知接口
        /// </summary>
        /// zouql   2016.09.10
        /// <param name="id">用户ID</param>
        /// <param name="isRead">是否已读</param>
        /// <param name="page">页码</param>
        /// <param name="rows">尺寸</param>
        /// <returns>消息列表</returns>
        public IHttpActionResult GetIsReadNoticeList(int id, bool isRead, int page, int rows)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Pagination pagination = new Pagination(page, rows);

            // 匿名类
            var result = new
            {
                rows = Notice.Get(id, isRead, pagination),
                total = pagination.Total
            };

            return Ok(result);
        }

        /// <summary>
        /// 根据用户ID查找围堵信息记录数
        /// </summary>
        /// yand    16.09.13
        /// <returns></returns>
        public IHttpActionResult GetByUserId()
        {
            int userid = BLL.User.User.CurrentUserId;
           var dt = Notice.GetByUserId(userid);
            return Ok(dt);
        }

        /// <summary>
        /// 获取消息通知列表
        /// </summary>
        /// yangj   2016.08.30
        /// <param name="page">页码</param>
        /// <param name="rows">尺寸</param>
        /// <returns></returns>
        public IHttpActionResult GetNoticesList(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);

            var id = BLL.User.User.CurrentUserId;

            // 匿名类
            var result = new
            {
                rows = Notice.GetAll(id, pagination),
                total = pagination.Total
            };

            return Ok(result);
        }
    }
}
