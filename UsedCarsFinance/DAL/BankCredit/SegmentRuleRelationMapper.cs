using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models.BankCredit;

namespace DAL.BankCredit
{
    public class SegmentRuleRelationMapper: BankAbstractMapper<SegmentRuleRelationInfo>
    {
        /// <summary>
        /// 根据信息类型ID和分组ID获取所有数据段关系
        /// </summary>
        ///  yaoy    16.09.21
        /// <param name="infoTypeId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<SegmentRuleRelationInfo> FindByInfoTypeIdAndGroupId(int infoTypeId,int groupId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_SegmentRuleRelation WHERE InfoTypeId=@InfoTypeId AND GroupId = @GroupId
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@GroupId", SqlDbType.Int, groupId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据信息类型获取所有数据段规则关系
        /// </summary>
        ///  yaoy    16.09.21
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<SegmentRuleRelationInfo> FindByInfoTypeId(int infoTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_SegmentRuleRelation WHERE InfoTypeId=@InfoTypeId
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据信息类型获取所有分组
        /// </summary>
        /// yaoy    16.09.21
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<int> FindGroupId(int infoTypeId)
        {
            List<int> list = new List<int>();

            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT DISTINCT(GroupId) FROM BANK_SegmentRuleRelation WHERE InfoTypeId=@InfoTypeId
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(Convert.ToInt32(dr["GroupId"].ToString()));
                }
            }

            return list;
        }
    }
}
