using DAL.BankCredit;
using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.BankCredit
{
    public class InformationRecord
    {
        private static readonly InformationRecordMapper inforRecordMapper = new InformationRecordMapper();

        /// <summary>
        /// 增加一条信息记录
        /// </summary>
        /// cais    16.05.25
        /// <param name="values"></param>
        /// <returns></returns>
        public bool Add(InformationRecordInfo values)
        {
            inforRecordMapper.Insert(values);

            return values.RecordID > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// cais    16.05.25
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Modify(InformationRecordInfo value)
        {
            return inforRecordMapper.Update(value) > 0;
        }

        /// <summary>
        /// 删除信息记录表
        /// </summary>
        /// cais    16.05.25
        /// <param name="recordID">主键</param>
        /// <returns></returns>
        public bool DeleteByrecordID(int reportID)
        {
            return inforRecordMapper.DeleteByRecordId(reportID) > 0;
        }

        /// <summary>
        /// 根据reportid 查找单个
        /// </summary>
        /// cais    16.05.25
        /// <param name="reportid"></param>
        /// <returns></returns>
        public InformationRecordInfo GetByRecordId(int RecordID)
        {
            return inforRecordMapper.Find(RecordID);
        }

        /// <summary>
        /// list
        /// </summary>
        /// cais    16.05.25
        /// <returns></returns>
        public DataTable GetAll(int reportFileID)
        {
            return inforRecordMapper.FindInformationRecord(reportFileID);
        }

        /// <summary>
        /// 根据记录ID获取信息记录集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="reportId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> GetByReportId(int reportId)
        {
            return inforRecordMapper.FindByReportId(reportId);
        }
        /// <summary>
        /// 根据信息记录类型查询保存的信息记录
        /// </summary>
        /// yand    16.09.22
        /// <param name="InfoTypeId"></param>
        /// <returns></returns>
        public List<InformationRecordInfo> GetByInfoTypeId(int InfoTypeId)
        {
            return inforRecordMapper.FindByInfoTypeId(InfoTypeId);
        }
    }
}