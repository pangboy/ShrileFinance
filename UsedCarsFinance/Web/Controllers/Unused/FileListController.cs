//using Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using Model.System;

//namespace Web.Controllers
//{
//    public class FileListController : ApiController
//    {
//        private readonly static BLL.System.File filelist = new BLL.System.File();

//        /// <summary>
//        /// 查询文件列表通过referenceId,referenceModule
//        /// </summary>
//        /// yand    15.12.01
//        /// <param name="referenceId"></param>
//        /// <param name="referenceModule"></param>
//        /// <returns></returns>
//        [HttpGet]
//        public List<FileInfo> GetByReference(int referenceId, int referenceModule)
//        {
//            List<FileInfo> flist = filelist.GetByReference(referenceId, referenceModule);

//            return flist;
//        }
//    }
//}
