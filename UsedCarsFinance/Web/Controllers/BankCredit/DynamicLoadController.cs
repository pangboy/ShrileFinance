using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Bank
{
    public class DynamicLoadController : ApiController
    {
        private static readonly BLL.BankCredit.DynamicLoad dynamicLoad = new BLL.BankCredit.DynamicLoad();

        /// <summary>
        /// yand    16.07.04
        /// </summary>
        /// <param name="infoTypeID">信息记录ID</param>
        /// <returns></returns>
        [HttpGet]
        public PageInfo GetPageInfo(int infoTypeID)
        {
            return dynamicLoad.GetPageInfo(infoTypeID);
        }

        /// <summary>
        /// 加载信息记录信息
        /// </summary>
        /// yand    16.05.31
        /// <param name="InfoTypeId">信息记录ID</param>
        /// <returns></returns>
        [HttpGet]
        public InfoTypeInfo GetInfoType(int InfoTypeId)
        {
            return new BLL.BankCredit.DataRule().GetInfoTypeInfoById(InfoTypeId);
        }


        /// <summary>
        /// 报文提交
        /// </summary>
        /// yand    16.03.25
        /// <param name="postmessage"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PostMessageInfo(PostMessage postmessage)
        {
            try
            {
                var message = string.Empty;
                var result = new BLL.BankCredit.BusinessLogicScript().AddInfomationData(postmessage, ref message);

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(message);
                }
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}