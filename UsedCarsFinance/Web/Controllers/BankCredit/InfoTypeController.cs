using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;

namespace Web.Controllers.BankCredit
{
    public class InfoTypeController : ApiController
    {
        private readonly static BLL.BankCredit.InfoType _infoType = new BLL.BankCredit.InfoType();

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetComList(int messageTypeId)
        {
            return _infoType.GetComList(messageTypeId);
        }

        /// <summary>
        ///获取信息记录下拉框
        /// </summary>
        /// yand    16.08.02
        /// <param name="infoTypeID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetList(int infoTypeID)
        {
            return _infoType.GetList(infoTypeID);
        }
    }
}