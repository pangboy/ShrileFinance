using iTextSharp.text;
using Models;
using Models.Finance;
using Models.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Web;

namespace BLL.Contract
{
    public class PdfContract
    {
        private static readonly DAL.Finance.ApplicantInfoMapper applicantInfoMapper = new DAL.Finance.ApplicantInfoMapper();
        private static readonly DAL.Finance.FinanceInfoMapper financeInfoMapper = new DAL.Finance.FinanceInfoMapper();
        private static readonly DAL.Finance.VehicleInfoMapper vehicleInfoMapper = new DAL.Finance.VehicleInfoMapper();
        private static readonly DAL.Sys.MoneyToUpper moneyToUpper = new DAL.Sys.MoneyToUpper();
        private static readonly BLL.Sys.Reference reference = new Sys.Reference();
        private readonly static DAL.Sys.FileListMapper fileMapper = new DAL.Sys.FileListMapper();
        private static readonly BLL.Contract.ContractsCalc contractsCalc = new ContractsCalc();
        private readonly static DAL.Contract.ContractMapper contract = new DAL.Contract.ContractMapper();

        public string filename;
        public string PDFPath;

        public PdfContract()
        {
            string path = @"~\upload\PDF\";
            string fullpath = HttpContext.Current.Server.MapPath(path);

            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }

            PDFPath = path;
        }

        /// <summary>
        /// 生成合同
        /// </summary>
        /// yand    16.05.11
        /// wangpf  16.08.02 修改删除
        /// <param name="financeId">融资Id</param>
        /// <returns>合同是否生成成功</returns>
        public bool CreateContrant(int financeId)
        {
            // 生成并获取融资租赁合同
            string path = this.CreateLeaseInfoPdf(financeId);

            // 只有融资合同生成了,才可以进行其他合同生成操作
            if (!String.IsNullOrEmpty(path))
            {
                //生成保证合同
                this.CreateEnsurePdf(financeId);
                //生成抵押合同
                this.CreateMortgagePdf(financeId);
            }
            return !String.IsNullOrEmpty(path);
        }

        /// <summary>
        /// 生成融资租赁合同信息pdf,并返回pdf路径
        /// </summary>
        /// wangpf  16.08.04
        /// <returns>合同地址</returns>
        public string CreateLeaseInfoPdf(int financeId)
        {
            // 获取融资信息
            DataTable dt = contract.FindLeaseInfo(financeId);

            // 合同参数
            string contractParams = String.Empty;
            // 保存的PDF名称(以合同编号命名)
            string pdfName = String.Empty;
            // 合同模板名称
            string contractName = "FinancingLease.doc";
            // 合同pdf地址
            string pdfPath = String.Empty;

            if (dt.Rows.Count > 0)
            {
                contractParams = DataRowToParams(dt.Rows[0]);
                pdfName = dt.Rows[0]["[融资租赁合同]"].ToString();
            }

            // 合同名称为空,表示该合同数据不存在不需要生成
            if (!String.IsNullOrEmpty(pdfName))
            {
                pdfPath = TransformPdf(contractName, contractParams, pdfName);
            }

            return pdfPath;
        }

        /// <summary>
        /// 生成车辆抵押合同pdf,并返回pdf路径
        /// </summary>
        /// wangpf  16.08.04
        /// <param name="financeId">融资Id</param>
        /// <returns>pdf路径</returns>
        public string CreateMortgagePdf(int financeId)
        {
            // 获取车辆抵押信息
            DataTable dt = contract.FindMortgageInfo(financeId);

            // 合同参数
            string contractParams = string.Empty;
            // 保存的PDF名称(以合同编号命名)
            string pdfName = string.Empty;
            // 合同模板名称
            string contractName = "Mortgage.doc";
            // 合同pdf地址
            string pdfPath = String.Empty;

            if (dt.Rows.Count > 0)
            {
                contractParams = DataRowToParams(dt.Rows[0]);
                pdfName = dt.Rows[0]["[车辆抵押合同编号]"].ToString();
            }

            // 合同名称为空,表示该合同数据不存在不需要生成
            if (!String.IsNullOrEmpty(pdfName))
            {
                pdfPath = TransformPdf(contractName, contractParams, pdfName);
            }

            return pdfPath;

        }

        /// <summary>
        /// 生成保证合同pdf,并返回pdf路径
        /// </summary>
        /// wangpf  16.08.04
        /// <param name="financeId">融资Id</param>
        /// <returns>pdf路径</returns>
        public string CreateEnsurePdf(int financeId)
        {
            // 获取保证信息
            DataTable dt = contract.FindEnsureInfo(financeId);

            // 合同参数
            string contractParams = string.Empty;
            // 保存的PDF名称(以合同编号命名)
            string pdfName = string.Empty;
            // 合同模板名称
            string contractName = "Ensure.doc";
            // 合同pdf地址
            string pdfPath = String.Empty;

            if (dt.Rows.Count > 0)
            {
                contractParams = DataRowToParams(dt.Rows[0]);
                pdfName = dt.Rows[0]["[保证合同编号]"].ToString();

            }

            // 合同名称为空,表示该合同数据不存在不需要生成
            if (!String.IsNullOrEmpty(pdfName))
            {
                pdfPath = TransformPdf(contractName, contractParams, pdfName);
            }

            return pdfPath;
        }


        /// <summary>
        /// 保存文件表中
        /// </summary>
        /// <param name="number">合同编号作为OldName</param>
        /// <param name="referenceid"></param>
        private bool InsertFile(string number, Guid referenceid, string ContrantName)
        {
            throw new NotImplementedException();

            //bool result = false;
            ////插入一条pdf文件数据
            //Models.Sys.FileInfo fi = new Models.Sys.FileInfo();
            //fileMapper.Insert(fi = new Models.Sys.FileInfo
            //{
            //    OldName = number,
            //    ExtName = ".pdf",
            //    NewName = ContrantName,
            //    FilePath = PDFPath,
            //    ReferenceId = referenceid,
            //    AddDate = DateTime.Now
            //});
            //result = fi.FileId > 0;
            //return result;
        }

        /// <summary>
        /// 合同保存
        /// </summary>
        /// yand    16.05.16
        /// <param name="FinanceId">融资ID</param>
        public bool SaveFile(int FinanceId)
        {
            throw new NotImplementedException();

            //bool result = true;
            //List<ApplicantInfo> Applicant = applicantInfoMapper.Find(FinanceId);
            //using (TransactionScope scope = new TransactionScope())
            //{
            //    var mainApplicant = Applicant.Find(m => m.Type == ApplicantInfo.TypeEnum.主要申请人);
            //    if (mainApplicant != null)
            //    {
            //        string hz = contractsCalc.GetContractNum("HZ", FinanceId, mainApplicant.ApplicantId.Value);//融资租赁合同编号代码
            //        ReferenceInfo referenceInfo = reference.Apply(FinanceId, 4, 1);//合同模块为4，1为融资租赁合同
            //        var refid = referenceInfo.ReferenceId;
            //        if (result)
            //            result &= InsertFile(hz, refid, "融资租赁合同");

            //        referenceInfo = reference.Apply(FinanceId, 4, 2);//合同模块为4，2为车辆抵押
            //        refid = referenceInfo.ReferenceId;

            //        List<Models.Sys.FileInfo> filelist = fileMapper.FindByReference(refid);
            //        string dy = contractsCalc.GetContractNum("DY", FinanceId, mainApplicant.ApplicantId.Value);//融资租赁合同编号代码
            //        if (filelist.Count > 0)
            //        {
            //            dy += (filelist.Count + 1);
            //        }
            //        else
            //        {
            //            dy += 1;
            //        }
            //        if (result)
            //            result &= InsertFile(dy, refid, "车辆抵押合同");
            //    }
            //    var guarantee = Applicant.FindAll(m => m.Type == ApplicantInfo.TypeEnum.担保人);
            //    for (int i = 1; i <= guarantee.Count; i++)
            //    {
            //        string bz = contractsCalc.GetContractNum("BZ", FinanceId, guarantee[i - 1].ApplicantId.Value);//保证合同编号代码
            //        ReferenceInfo referenceInfo = reference.Apply(FinanceId, 4, 3);//合同模块为4，3保证合同
            //        var refid = referenceInfo.ReferenceId;
            //        if (result)
            //            result &= InsertFile(bz, refid, "保证合同" + i);
            //    }

            //    if (result) scope.Complete();
            //}
            //return result;
        }

        /// <summary>
        /// 查询合同名称
        /// </summary>
        /// yand    16.05.17
        /// <param name="financeId"></param>
        /// <returns></returns>
        public List<ComboInfo> FindContrantName(Guid financeId)
        {
            List<ComboInfo> referenceList = new DAL.Sys.FileListMapper().FindContrantByReferenced(financeId);
            return referenceList;
        }

        /// <summary>
        /// 远程转Pdf,并返回pdf保存路径
        /// wangpf  16.08.01
        /// </summary>
        /// <param name="fileName">要转换的文件名</param>
        /// <param name="param">参数</param>
        /// <param name="targetPdfName">需要生成的pdf的名字</param>
        private string TransformPdf(string fileName, string param, string targetPdfName)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["PrintUrl"].ToString();

            url = url + "fileName=" + fileName;

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
        private string DataRowToParams(DataRow dr)
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

    public delegate string MyDelegate(object data);
}
