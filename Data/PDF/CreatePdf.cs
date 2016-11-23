﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using PDFPrint;

namespace Data.PDF
{
    public class CreatePdf
    {
        Microsoft.Office.Interop.Word.Application app = null;
        Microsoft.Office.Interop.Word.Document doc = null;
        Microsoft.Office.Interop.Word.WdExportFormat wdPdf = Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF;
        object missing = System.Reflection.Missing.Value;

        /// <summary>
        /// 远程转Pdf,并返回pdf保存路径
        /// </summary>
        /// <param name="oldPath">word模板路径</param>
        /// <param name="newPath">新的pdf路径</param>
        /// <param name="fileName">合同模板名</param>
        /// <param name="param">参数</param>
        /// <param name="targetPdfName">需要生成的pdf的名字</param>
        public string TransformPdf(string oldPath,string newPath,string fileName, string param, string targetPdfName)
        {
            oldPath = oldPath + fileName;//模板
            object newPdfPath = newPath + targetPdfName + ".docx";//新生成的
            WordHelper wdHelp = new WordHelper();
            File.Copy(oldPath.ToString(), newPdfPath.ToString());
            //将要导出的新word文件名
            string physicNewFile = newPath + targetPdfName + ".pdf";
            try
            {
                // 处理成字典类型的占位符和数据
                var placeholder = BuildPlaceholder(param);

                //创建word应用程序
                app = new Microsoft.Office.Interop.Word.Application();
                object oMissing = System.Reflection.Missing.Value;

                // 打开Word文档
                doc = app.Documents.Open(ref newPdfPath,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                foreach (var item in placeholder)
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
                doc.Close(ref missing, ref missing, ref missing);
                app.Quit(ref missing, ref missing, ref missing);
                File.Delete(newPdfPath.ToString());
            }
            catch
            {
                return null;
                throw new Core.Exceptions.InvalidOperationAppException("合同生成失败.");
            }
            return physicNewFile;
        }

        /// <summary>
        /// 将占位符和数据处理成字典类型
        /// </summary>
        /// <param name="param">占位符和数</param>
        /// <returns></returns>
        public Dictionary<string, string> BuildPlaceholder(string param)
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
                        if (string.IsNullOrEmpty(y))
                        {
                            y = y.PadLeft(x.Length, ' ');
                        }
                        placeholder.Add(x, y);
                    }
                }
            }
            return placeholder;
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
