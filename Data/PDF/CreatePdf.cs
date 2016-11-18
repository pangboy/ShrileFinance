using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace Data.PDF
{
    public class CreatePdf
    {
        /// <summary>
        /// 远程转Pdf,并返回pdf保存路径
        /// wangpf  16.08.01
        /// </summary>
        /// <param name="fileName">合同模板名</param>
        /// <param name="param">参数</param>
        /// <param name="targetPdfName">需要生成的pdf的名字</param>
        public string TransformPdf( string fileName, string param, string targetPdfName)
        {
            //string url = System.Web.Configuration.WebConfigurationManager.AppSettings["PrintUrl"].ToString();
           string url = "D:/Projects/UsedCarsFinance/trunk/Web/upload/PDF/";
            //url = url+"fileName=" + fileName;
            url = url + fileName;
           // string[] strs = File.ReadAllLines(url);

            // 创建httpWebRequest对象
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            // 初始化HttpWebRequest对象
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            webRequest.ContentLength = byteArray.Length;

            // 附加要POST给服务器的数据到HttpWebRequest对象(附加POST数据的过程比较特殊，它并没有提供一个属性给用户存取，需要写入HttpWebRequest对象提供的一个stream里面。)
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            // 读取服务器的返回信息
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            Stream stream = webResponse.GetResponseStream();

            // 请求下载的pdf地址
            string pdfFile = System.Web.HttpContext.Current.Server.MapPath("~\\upload\\PDF\\" + targetPdfName + ".pdf");

            FileStream fs = new FileStream(pdfFile, FileMode.Create);

            int bufferSize = 2048;
            byte[] bytes = new byte[bufferSize];
            try
            {
                int length = stream.Read(bytes, 0, bufferSize);
                while (length > 0)
                {
                    fs.Write(bytes, 0, length);

                    length = stream.Read(bytes, 0, bufferSize);
                }

                stream.Close();
                fs.Close();
                webResponse.Close();

                // 把生成的pdf写入文件流
                FileStream fileStream = new FileStream(pdfFile, FileMode.Open);
                byte[] file = new byte[fileStream.Length];
                fileStream.Read(file, 0, file.Length);
                fileStream.Close();

                // 强制下载
                //HttpResponse response = System.Web.HttpContext.Current.Response;
                //response.AddHeader("content-disposition", "attachment; filename=" + pdfFile);
                //response.ContentType = "application/octet-stream";
                //response.BinaryWrite(file);
                //response.End();
            }
            catch (Exception)
            {
                stream.Close();
                fs.Close();
                webResponse.Close();
                pdfFile = string.Empty;
            }
            return pdfFile;
        }

        /// <summary>
        /// DataRow格式数据转成url参数
        /// </summary>
        /// wangpf  16.08.01
        /// <param name="dt">DataRow</param>
        /// <returns></returns>
        public string DataRowToParams(DataRow dr)
        {
            StringBuilder sb = new StringBuilder();

            DataTable dt = dr.Table;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName);
                sb.Append("=");
                if (dt.Rows.Count > 0)
                {
                    sb.Append(dt.Rows[0][i].ToString());
                }
                sb.Append("&");
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
