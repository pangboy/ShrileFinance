using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Specialized;
using Models;
using Models.BankCredit;
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using Application;

namespace Web.Controllers.BankCredit
{
    public class ReportFilesController : ApiController
    {
        private readonly BLL.BankCredit.ReportFiles _files;

        public ReportFilesController(AccountAppService service)
        {
            service.User = this.User;
            _files = new BLL.BankCredit.ReportFiles(service);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpGet]
        public Datagrid GetReportFilesData(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection data = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = _files.GetReportFilesData(pagination, data),
                total = pagination.Total
            };
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public int Add(ReportFilesInfo value)
        {
            NameValueCollection data = ApiHelper.GetParameters();

            return _files.Add(data);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="reportFilesId"></param>
        /// <returns></returns>
        public ReportFilesInfo Get(int reportFilesId)
        {
            return _files.Get(reportFilesId);
        }
        [HttpGet]
        public ReportFilesInfo GetByOperator(int filesId)
        {
            return _files.GetByOperator(filesId);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="filesId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(int filesId)
        {
            return _files.Delete(filesId) ? (IHttpActionResult)Ok() : BadRequest("删除失败");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Modify(ReportFilesInfo value)
        {
            return _files.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("修改失败");
        }

        /// <summary>
        /// 报文发送
        /// </summary>
        /// yand    16.06.02
        /// <param name="reportId"></param>
        /// <returns></returns>
        [HttpGet]
        public object SendReportFile(int fileId)
        {
            return _files.SendReportFileInfo(fileId) ? true :false ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="Remarks"></param>
        /// <param name="FilesName"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Save(int fileId, string FilesName, string Remarks)
        {
            return _files.Save(fileId, FilesName, Remarks) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        /// <summary>
        /// 用于测试报文文件下载（丁桃仙测试后删除）
        /// </summary>
        /// yand    16.06.06
        /// <param name="reportFileID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFileTxt(int reportFileID)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ReportFilesInfo rfInfo = _files.Get(reportFileID);

            string path = @"~\upload\messageFile\";
            string fullpath = HttpContext.Current.Server.MapPath(path);
            string Filepath = fullpath+rfInfo.ReportTextName;
            response = GetFile(Filepath, rfInfo.ReportTextName);
            return response;
        }

        public HttpResponseMessage GetFile(string path,string TextName)
        {
            try
            {
                string ResponseFileName = TextName ;
                var stream = new FileStream(path, FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = ResponseFileName,
                    FileNameStar = ResponseFileName
                };

                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }
    }
}
