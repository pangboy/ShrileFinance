using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Model.Sys;
using System.Linq;

namespace BLL.Sys
{
    public class File
    {
        private const string Path = @"~\Upload\";
        private readonly static DAL.Sys.FileListMapper fileMapper = new DAL.Sys.FileListMapper();

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// qiy		16.04.05
        /// <param name="fileId">文件标识</param>
        /// <returns></returns>
        public FileInfo Get(int fileId)
        {
            return fileMapper.Find(fileId);
        }
        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// qiy		16.04.05
        /// <param name="referenceId">引用信息</param>
        /// <returns></returns>
        public List<FileInfo> GetByReference(int referenceId)
        {
            return fileMapper.FindByReference(referenceId);
        }

        /// <summary>
        /// 增加文件
        /// </summary>
        /// qiy		16.04.05
        /// <param name="file">文件</param>
        /// <param name="referenceId">引用标识</param>
        /// <returns></returns>
        public int Add(HttpPostedFile file, int referenceId,out string message)
        {
            message = "";
            string filename = file.FileName;
            string[] str = { ".jpg",".bmp", ".gif", ".rar", ".xls", ".pdf", ".psd", ".avi", ".zip", ".doc", ".ai",".ppt",".mp4",".mp3",".png", ".swf", ".docx" };
            List<string> extType = str.ToList();

            int pos = filename.LastIndexOf('.');

            FileInfo info = new FileInfo {
                OldName = filename.Substring(0, pos),
                ExtName = filename.Substring(pos).ToLower(),
                NewName = this.RandomName(),
                FilePath = Path + DateTime.Now.ToString("yyyyMM\\\\"),
                ReferenceId = referenceId,
                AddDate = DateTime.Now
            };
            if (!extType.Exists(m => m == info.ExtName))
            {
                message = "不合法的文件格式！";
                return 0;
            }
            
                fileMapper.Insert(info);

            if (info.FileId > 0)
                Save(info, file);

            return info.FileId;
        }
        /// <summary>
        /// 批量增加文件
        /// </summary>
        /// qiy     16.04.06
        /// <param name="files">文件集合</param>
        /// <param name="referenceId">引用标识</param>
        /// <returns></returns>
        public bool Add(HttpFileCollection files, int referenceId,out string message)
        {
            message = "";

            if (referenceId == 0) return false;

            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].ContentLength > 0)
                {
                    Add(files[i], referenceId,out message);
                }
            }

            return true;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// qiy		16.04.05
        /// <param name="fileId">文件标识</param>
        /// <returns></returns>
        public void Delete(int fileId)
        {
            fileMapper.Delete(fileId);
        }
        /// <summary>
        /// 根据引用批量删除
        /// </summary>
        /// qiy		16.04.05
        /// <param name="referenceId">引用信息</param>
        /// <returns></returns>
        public void DeleteByReference(int referenceId)
        {
            fileMapper.DeleteByReference(referenceId);
        }

        /// <summary>
        /// 保存文件到本地磁盘上
        /// </summary>
        /// qiy		16.04.05
        /// <param name="info">信息</param>
        /// <param name="file">文件</param>
        private void Save(FileInfo info, HttpPostedFile file)
        {
            if (file == null) throw new ArgumentNullException("File Not Exists");

            string filePath = HttpContext.Current.Server.MapPath(info.FilePath);

            if (!System.IO.Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }

            file.SaveAs(filePath + info.NewName + info.ExtName);
        }

        /// <summary>
        /// 生成随机名称
        /// </summary>
        /// qiy		16.04.05
        /// <returns></returns>
        private string RandomName()
        {
            DateTime now = DateTime.Now;
            Random random = new Random(now.Millisecond);

            Task.Delay(10);

            return now.ToString("yyMMddHHmmss") + random.Next(0, 10000).ToString("D4");
        }
    }
}
