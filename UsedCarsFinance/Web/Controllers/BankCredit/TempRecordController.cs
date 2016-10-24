using System.Web.Http;
using Models.BankCredit;

namespace Web.Controllers.BankCredit
{
    public class TempRecordController : ApiController
    {
        private static readonly BLL.BankCredit.TempRecord TempRecord = new BLL.BankCredit.TempRecord();

        /// <summary>
        /// 临时数据保存
        /// </summary>
        /// yangj    16.09.20
        /// <param name="tempRecordInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public object SaveAsTemp(TempRecordInfo tempRecordInfo)
        {
            bool result = true;
            string message = string.Empty;

            result = TempRecord.SaveAsTemp(tempRecordInfo);

            if (result)
            {
                return result;
            }
            else
            {
                return message;
            }
        }

        /// <summary>
        /// 加载临时数据
        /// </summary>
        /// yangj   16.09.21
        /// <param name="infoTypeId">信息记录类型标识</param>
        /// <param name="reportId">报文标识</param>
        /// <returns></returns>
        [HttpGet]
        public MessageInfo GetTempRecord(int infoTypeId, int reportId)
        {
            TempRecordInfo tempRecordInfo = TempRecord.Get(infoTypeId, reportId);

            if (tempRecordInfo != null)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<MessageInfo>(tempRecordInfo.Context);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// yangj    16.09.20
        /// <param name="infoTypeId">信息记录类型标识</param>
        /// <param name="reportId">报文标识</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult DeleteTemp(int infoTypeId, int reportId)
        {
            return TempRecord.DeleteByInfoTypeIdAndReportId(infoTypeId, reportId) ? (IHttpActionResult)Ok() : BadRequest("删除失败");
        }

        /// <summary>
        /// 查询单条记录的标识
        /// </summary>
        /// <param name="infoTypeId"></param>
        /// <param name="reportId"></param>
        /// <returns></returns>
        [HttpGet]
        public TempRecordInfo GetTempInfoId(int infoTypeId, int reportId)
        {
            TempRecordInfo tempRecordInfo = TempRecord.Get(infoTypeId, reportId);

            return tempRecordInfo;
        }
    }
}
