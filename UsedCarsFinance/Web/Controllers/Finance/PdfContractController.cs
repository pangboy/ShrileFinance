using Model;
using Model.Sys;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace Web.Controllers
{
    public class PdfContractController : ApiController
    {
        private static readonly BLL.Contract.PdfContract contract = new BLL.Contract.PdfContract();

        /// <summary>
        /// 获取合同地址
        /// </summary>
        /// wangpf  16.08.04 修改
        /// <param name="fileId">文件ID</param>
        /// <returns></returns>
        [HttpGet]
        public Model.Sys.FileInfo GetPath(int fileId)
        {
            return new BLL.Sys.File().Get(fileId);
        }

        /// <summary>
        /// 获取合同名称
        /// </summary>
        /// yand    16.05.16
        /// <param name="FinanceId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetContrantType(int FinanceId)
        {
            return new BLL.Contract.PdfContract().FindContrantName(FinanceId);
        }


        /// <summary>
        /// 测试,测试,测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Test(int id)
        {
            var _contract = new BLL.Contract.PdfContract();
            _contract.CreateContrant(id);
            return Ok();
        }


    }
}
