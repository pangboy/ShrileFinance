using Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.BankCredit
{
    public class MessageTypeController : ApiController
    {
        private readonly static BLL.BankCredit.MessageType _messageType = new BLL.BankCredit.MessageType();

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetComList(int fileId)
        {
            return _messageType.GetComList(fileId);
        }

        /// <summary>
        /// 通过文件类型获取下拉框列表
        /// </summary>
        /// yaoy    16.07.06
        /// <param name="fileType"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetComListByFileType(int fileType)
        {
            return _messageType.GetComListByFileType(fileType);
        }
        /// <summary>
        /// 通过信息记录类型ID获取信息记录类型下拉列表
        /// </summary>
        /// yand    16.07.11
        /// <param name="messageTypeID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> getList(int messageTypeId)
        {
            return _messageType.GetList(messageTypeId);
        }
    }
}