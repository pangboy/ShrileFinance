using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.BankCredit
{
    public class DataSegmentController : ApiController
    {
        private readonly static BLL.BankCredit.DataSegment _dataSegment = new BLL.BankCredit.DataSegment();

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetComList(int messageTypeId)
        {
            return _dataSegment.GetComList(messageTypeId);
        }
    }
}
