namespace BLL.Finance
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Web;
    using BLL.Sys;
    using Models.Sys;

    /// <summary>
    /// 引用模块
    /// </summary>
    public class ImageUpload
    {
        private static readonly DAL.Finance.ImageUploadMapper Imageupload = new DAL.Finance.ImageUploadMapper();
        private static readonly BLL.Sys.Reference Reference = new Sys.Reference();

        /// <summary>
        /// 获取引用数据
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceId">标识</param>
        /// <returns></returns>
        public ReferenceInfo Get(int referenceId)
        {
            return Reference.Get(referenceId);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// cais    16.04.08
        /// <param name="referencedId">被引用标识</param>
        /// <param name="referencedModule">被引用模块</param>
        /// <param name="referencedSid">被引用子标识</param>
        /// <returns></returns>
        public ReferenceInfo Get(Guid? referencedId, int? referencedModule, int? referencedSid)
        {
            return Reference.Apply(referencedId, referencedModule, referencedSid);
        }

        /// <summary>
        /// 修改引用
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceInfo">值</param>
        /// <returns></returns>
        public bool Modify(ReferenceInfo referenceInfo)
        {
            return Reference.Modify(referenceInfo);
        }

        /// <summary>
        /// 获取融资id所有文件
        /// </summary>
        /// cais    16.04.08
        /// <param name="financeId">融资ID</param>
        /// <returns></returns>
        public DataTable ListByfinanceid(Guid financeId)
        {
            return Imageupload.Find(financeId);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceId">文件引用id</param>
        public void Delete(int referenceId)
        {
            Imageupload.Delete(referenceId);
        }

        /// <summary>
        /// 将带,的referencesid 转化为 list
        /// </summary>
        /// cais    16.04.27
        /// <param name="referencesid">所有的referencesid</param>
        /// <returns>List</returns>
        public List<int> StringtoList(string referencesid)
        {
            referencesid = referencesid.TrimEnd(',');

            string[] s1 = referencesid.Split(new char[] { ',' });

            var referenceList = new List<int>();

            foreach (var item in s1)
            {
                if (!string.IsNullOrEmpty(item.ToString()))
                {
                    try
                    {
                        referenceList.Add(Convert.ToInt32(item));
                    }
                    catch
                    {
                    }
                }
            }

            return referenceList;
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// cais    16.04.27
        /// <param name="references">referencesid 集合</param>
        /// <returns>一个压缩好的文件信息</returns>
        public Models.Sys.FileInfo Download(List<int> references)
        {
            Sys.File file = new Sys.File();
            Compress compress = new Compress();

            foreach (var reference in references)
            {
                compress.Add(file.GetByReference(reference));
            }

            return compress.Comperssing();
        }

        /// <summary>
        /// 删除过期文件（以天为单位）,删除今天以前的压缩文件
        /// </summary>
        /// cais    16.04.28
        /// <param name="compressFile">文件信息</param>
        public void DeleteFileByDate(Models.Sys.FileInfo compressFile)
        {
            if (compressFile.FilePath != null)
            {
                var server = HttpContext.Current.Server;

                // 将虚拟转化成物理路劲
                DelOverdueZipFile(server.MapPath(compressFile.FilePath), server.MapPath(@"~\Upload\Temps"));
            }
        }

        /// <summary>
        /// 删除过期1天以上的压缩文件，已释放服务器硬盘空间
        /// </summary>
        /// cais    16.04.28
        /// <param name="fartherFilder">删除所放图片的文件夹的地址</param>
        /// <param name="file">删除压缩文件的地址</param>
        public void DelOverdueZipFile(string fartherFilder, string file)
        {
            // 适用于里面有子目录，文件的文件夹
            Directory.Delete(fartherFilder.TrimEnd('/'), true);
             
            ////Directory.Delete(fartherFilder);//适用于空文件夹
            DirectoryInfo di = new DirectoryInfo(file);

            System.IO.FileInfo[] fi = di.GetFiles("*.zip");
            DateTime dateTimeNow = DateTime.Now;

            foreach (System.IO.FileInfo tmpfi in fi)
            {
                // tmpfi.CreationTime;//创建时间 tmpfi.LastWriteTime//最后一次写
                TimeSpan ts = dateTimeNow.Subtract(tmpfi.LastWriteTime);

                // 距现在一天以上
                if (ts.TotalDays > 1)
                {
                    // 删除服务器临时保存文件
                    tmpfi.Delete();
                }
            }
        }

        /// <summary>
        /// 根据FinanceId 获得所有申请人的引用ID
        /// </summary>
        /// cais    16.05.03
        /// <param name="financeId">融资标识</param>
        /// <returns>列表</returns>
        public DataTable RefListByfinanceid(Guid financeId)
        {
            return Imageupload.FindReferenceId(financeId);
        }

        /// <summary>
        /// 根据ReferenceId  获得文件
        /// </summary>
        /// <param name="referenceId">引用id</param>
        /// cais    16.05.04
        /// <returns>引用id 下的引用列表</returns>
        public DataTable GetFiles(int referenceId)
        {
            return Imageupload.FindFiles(referenceId);
        }
    }
}