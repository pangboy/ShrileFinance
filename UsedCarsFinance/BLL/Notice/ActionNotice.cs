using Model.Notice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Notice
{
   public class ActionNotice
    {
        private static readonly DAL.Notice.ActionNotinceMapper actionNoticeMapper = new DAL.Notice.ActionNotinceMapper();

        /// <summary>
        /// 查找行为通知
        /// </summary>
        /// yand    16.09.10
        /// <param name="actionId">行为Id</param>
        /// <returns></returns>
        public ActionNoticeInfo GetActionNotice(int actionId)
        {
            return actionNoticeMapper.FindByActionId(actionId);
        }
    }
}
