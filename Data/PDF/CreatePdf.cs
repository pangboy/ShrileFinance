using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using PDFPrint;

namespace Data.PDF
{
    public class CreatePdf
    {
        /// <summary>
        /// 远程转Pdf,并返回pdf保存路径
        /// </summary>
        /// <param name="fileName">合同模板名</param>
        /// <param name="param">参数</param>
        /// <param name="targetPdfName">需要生成的pdf的名字</param>
        public string TransformPdf(string fileName, string param, string targetPdfName)
        {
           object url = "D:/Projects/upload/PDF/" + fileName;//模板
            object url1 = "D:/Projects/upload/PDF/" + fileName.Substring(0, fileName.Length - 5) + DateTime.Now.Millisecond + ".docx";//新生成的
            WordHelper wdHelp = new WordHelper();
            File.Copy(url.ToString(), url1.ToString());

            // string path = @"~\upload\PDF\";
            object fullpath = url;// HttpContent.Current.Server.MapPath(path);
            //if (Directory.Exists(fullpath))
            //{
            //    Directory.CreateDirectory(fullpath);
            //}
            string WordContent = wdHelp.GetContract(url1.ToString(), false, false);
            //List<string> list = new List<string>(WordContent.Substring)

            Microsoft.Office.Interop.Word.Application app = null;
            Microsoft.Office.Interop.Word.Document doc = null;
            Microsoft.Office.Interop.Word.WdExportFormat wdPdf = Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF;

            //将要导出的新word文件名
            string newFile = DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc";
            string physicNewFile = "D:/Projects/upload/PDF/" + targetPdfName + ".pdf";
            try
            {
                //将获取的页面数据按'['进行分割
                string[] spilt = param.Split('&');
                // 构造数据，用于存放占位符数据
                Dictionary<string, string> placeholder = new Dictionary<string, string>();
                foreach (var item in spilt)
                {
                    if (item.IndexOf('=') > -0)
                    {
                        if (item.IndexOf('=') >= 0)
                        {
                            var x = item.Substring(0, item.IndexOf('='));
                            var y = item.Substring(item.IndexOf('=') + 1, item.Length - item.IndexOf('=') - 1);
                            placeholder.Add(x, y);
                        }
                    }
                }

                app = new Microsoft.Office.Interop.Word.Application();//创建word应用程序
                object oMissing = System.Reflection.Missing.Value;
                doc = app.Documents.Open(ref url1,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                Dictionary<string, string> datas = new Dictionary<string, string>();
                datas.Add("[融资租赁合同]", "张三");
                datas.Add("[乙方姓名]", "男");
                datas.Add("{provinve}", "浙江");
                datas.Add("{address}", "浙江省杭州市");
                datas.Add("{education}", "本科");
                datas.Add("{telephone}", "12345678");
                datas.Add("{cardno}", "123456789012345678");

                object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                foreach (var item in datas)
                {
                    app.Selection.Find.Replacement.ClearFormatting();
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Text = item.Key;//需要被替换的文本
                    app.Selection.Find.Replacement.Text = item.Value;//替换文本 

                    //执行替换操作
                    app.Selection.Find.Execute(
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref replace,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                }
                object objWdPdf = wdPdf;
                //保存PDF文档
                doc.SaveAs(physicNewFile,
                objWdPdf, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
            }
            catch(Exception ex)
            {
               
            }
            return null;
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
