using Models.Sys;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using Web.Controllers.Sys;

namespace Web.Controllers.Finance
{
    public class ImageUploadController : ApiController
    {
        private readonly static BLL.Finance.ImageUpload imageUpload = new BLL.Finance.ImageUpload();

        /// <summary>
        /// 获取融资id所有文件
        /// </summary>
        /// cais    16.04.08
        /// <param name="financeid">融资ID</param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetAll(int financeid)
        {
            return imageUpload.ListByfinanceid(financeid);
        }

        /// <summary>
        /// 根据FinanceId 获得所有申请人的引用ID
        /// </summary>
        /// cais    16.05.03
        /// <param name="financeid"></param>
        [HttpGet]
        public DataTable GetAllRef(int financeid)
        {
            return imageUpload.RefListByfinanceid(financeid);
        }

        /// <summary>
        /// 根据ReferenceId  获得文件
        /// </summary>
        /// <param name="ReferenceId">引用id</param>
        /// cais    16.05.04
        /// <returns>引用id 下的引用列表</returns>
        [HttpGet]
        public DataTable GetFiles(int ReferenceId)
        {
            return imageUpload.GetFiles(ReferenceId);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceId">文件引用id</param>
        [HttpDelete]
        public IHttpActionResult Delete(int referenceId)
        {
            imageUpload.Delete(referenceId);

            return Ok();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceId">标识</param>
        /// <returns></returns>
        public ReferenceInfo Get(int referenceId)
        {
            return imageUpload.Get(referenceId);
        }

        /// <summary>
        /// 获取引用信息
        /// </summary>
        /// cais    16.04.08
        /// <param name="referencedId">被引用标识</param>
        /// <param name="referencedModule">被引用模块</param>
        /// <param name="referencedSid">被引用子标识</param>
        /// <returns></returns>
        public ReferenceInfo Get(int? referencedId, int? referencedModule, int? referencedSid = null)
        {
            return imageUpload.Get(referencedId, referencedModule, referencedSid);
        }



        /// <summary>
        /// 修改引用
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceInfo">值</param>
        /// <returns></returns>
        public bool Put(ReferenceInfo referenceInfo)
        {
            return imageUpload.Modify(referenceInfo);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// cais    16.04.28
        /// <param name="references">引用子id</param>
        /// <returns>文件流</returns>
        [HttpGet]
        public HttpResponseMessage Download(string references)
        {
            FileInfo compressFile = imageUpload.Download(imageUpload.StringtoList(references));

            imageUpload.DeleteFileByDate(compressFile);

            FileController _fileController = new FileController();

            HttpResponseMessage response = _fileController.GetDownloadResponse(compressFile);

            return response;
        }
    }
}