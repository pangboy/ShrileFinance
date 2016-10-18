using System.Transactions;
using DAL.BankCredit;
using Model.BankCredit;

namespace BLL.BankCredit
{
    public class TempRecord
    {
        private static readonly TempRecordMapper TempInfoMapper = new TempRecordMapper();

        /// <summary>
        /// 增加一条临时数据记录
        /// </summary>
        /// yangj    16.09.21
        /// <param name="values">临时数据实体</param>
        /// <returns></returns>
        public bool Add(TempRecordInfo values)
        {
            // 获取当前用户ID
            int userId = new BLL.User.User().CurrentUser().UserId;
            values.UserId = userId;
            TempInfoMapper.Insert(values);

            return values.TempInfoId > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yangj    16.09.21
        /// <param name="value">临时数据实体</param>
        /// <returns></returns>
        public bool Modify(TempRecordInfo value)
        {
            // 获取当前用户ID
            int userId = new BLL.User.User().CurrentUser().UserId;
            value.UserId = userId;

            return TempInfoMapper.Update(value) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// yangj    16.09.21
        /// <param name="infoTypeId">信息记录类型标识</param>
        /// <param name="reportId">报文标识</param>
        /// <returns></returns>
        public bool DeleteByInfoTypeIdAndReportId(int infoTypeId, int reportId)
        {
            // 获取当前用户ID
            int userId = new BLL.User.User().CurrentUser().UserId;

            return TempInfoMapper.Delete(infoTypeId, reportId, userId) > 0;
        }

        /// <summary>
        ///  查找单条临时数据记录
        /// </summary>
        /// yangj    16.09.21
        /// <param name="infoTypeId">信息记录类型标识</param>
        /// <param name="reportId">报文标识</param>
        /// <returns></returns>
        public TempRecordInfo Get(int infoTypeId, int reportId)
        {
            // 获取当前用户ID
            int userId = new BLL.User.User().CurrentUser().UserId;

            return TempInfoMapper.Find(infoTypeId, reportId, userId);
        }

        /// <summary>
        /// 信息记录保存为草稿
        /// </summary>
        /// yangj    16.09.21
        /// <param name="tempRecordInfo">临时数据实体</param>
        /// <returns></returns>
        public bool SaveAsTemp(TempRecordInfo tempRecordInfo)
        {
            bool result = true;

            // 如果记录不存在，则新添记录，否则修改原有记录
            if (tempRecordInfo.TempInfoId != 0)
            {
                result &= Modify(tempRecordInfo);
            }
            else
            {
                result &= Add(tempRecordInfo);
            }

            return result;
        }
    }
}