using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BankCredit;

namespace BLL.BankCredit
{
    public class SegmentRuleRelation
    {
        private DAL.BankCredit.SegmentRuleRelationMapper SegmentRuleRelationMapper = new DAL.BankCredit.SegmentRuleRelationMapper();

        /// <summary>
        /// 根据信息类型ID获取数据段规则集合
        /// </summary>
        /// yaoy    16.09.21
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<SegmentRuleRelationInfo> GetByInfoTypeId(int infoTypeId)
        {
            return SegmentRuleRelationMapper.FindByInfoTypeId(infoTypeId);
        }

        /// <summary>
        /// 根据信息类型ID和分组ID获取数据段规则集合
        /// </summary>
        /// yaoy    16.09.21
        /// <param name="infoTypeId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<SegmentRuleRelationInfo> GetByInfoTypeIdAndGroupId(int infoTypeId,int groupId)
        {
            return SegmentRuleRelationMapper.FindByInfoTypeIdAndGroupId(infoTypeId, groupId);
        }

        /// <summary>
        /// 根据信息类型ID获取所属的所有分组ID
        /// </summary>
        /// yaoy    16.09.21
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<int> GetGroupId(int infoTypeId)
        {
            return SegmentRuleRelationMapper.FindGroupId(infoTypeId);
        }
    }
}
