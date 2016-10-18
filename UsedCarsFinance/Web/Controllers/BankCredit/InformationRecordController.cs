using BLL.BankCredit;
using Model;
using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.BankCredit
{
    public class InformationRecordController : ApiController
    {
        private static readonly InformationRecord informtionRecord = new InformationRecord();


        /// <summary>
        /// 根据报文ID查找信息记录
        /// </summary>
        /// cais    16.06.01
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetRecordData(int reportFileID)
        {
            return informtionRecord.GetAll(reportFileID);
        }


        /// <summary>
        /// 查找信息记录
        /// </summary>
        /// yand    16.06.02
        /// <param name="recordId">信息记录ID</param>
        /// <returns></returns>
        [HttpGet]
        public MessageInfo GetInfoRecordInfo(int recordId)
        {
            InformationRecordInfo informationRecordInfo = new BLL.BankCredit.InformationRecord().GetByRecordId(recordId);
            if (informationRecordInfo != null)
                return Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(informationRecordInfo.Context);
            else return null; 

        }
    }
}
