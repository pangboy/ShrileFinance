namespace Web.Controllers.Finance
{
    using System;
    using System.Data;
    using System.Net.Http;
    using System.Web.Http;
    using Models.Sys;
    using Web.Controllers.Sys;

    public class ImageUploadController : ApiController
    {
        private static readonly BLL.Finance.ImageUpload ImageUploadInstance = new BLL.Finance.ImageUpload();

        /// <summary>
        /// 获取融资id所有文件
        /// </summary>
        /// cais    16.04.08
        /// <param name="financeid">融资ID</param>
        /// <returns></returns>
        [HttpGet]
        public DataTable GetAll(Guid financeid)
        {
            return ImageUploadInstance.ListByfinanceid(financeid);
        }

        /// <summary>
        /// 根据FinanceId 获得所有申请人的引用ID
        /// </summary>
        /// cais    16.05.03
        /// <param name="financeid"></param>
        [HttpGet]
        public DataTable GetAllRef(Guid financeid)
        {
            return ImageUploadInstance.RefListByfinanceid(financeid);
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
            return ImageUploadInstance.GetFiles(ReferenceId);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceId">文件引用id</param>
        [HttpDelete]
        public IHttpActionResult Delete(int? referenceId)
        {
            if (referenceId == null)
            {
                return BadRequest("参数为null");
            }

            ImageUploadInstance.Delete(referenceId.Value);

            return Ok();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceId">标识</param>
        /// <returns>引用</returns>
        public ReferenceInfo Get(int referenceId)
        {
            return ImageUploadInstance.Get(referenceId);
        }

        /// <summary>
        /// 获取引用信息
        /// </summary>
        /// cais    16.04.08
        /// <param name="referencedId">被引用标识</param>
        /// <param name="referencedModule">被引用模块</param>
        /// <param name="referencedSid">被引用子标识</param>
        /// <returns>引用</returns>
        public ReferenceInfo Get(Guid? referencedId, int? referencedModule, int? referencedSid = null)
        {
            return ImageUploadInstance.Get(referencedId, referencedModule, referencedSid);
        }

        /// <summary>
        /// 修改引用
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceInfo">值</param>
        /// <returns>修改结果</returns>
        public bool Put(ReferenceInfo referenceInfo)
        {
            return ImageUploadInstance.Modify(referenceInfo);
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
            FileInfo compressFile = ImageUploadInstance.Download(ImageUploadInstance.StringtoList(references));

            ImageUploadInstance.DeleteFileByDate(compressFile);

            ////FileController _fileController = new FileController();

            HttpResponseMessage response = new FileController().GetDownloadResponse(compressFile);

            return response;
        }
    }
}