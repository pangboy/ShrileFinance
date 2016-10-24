using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit
{
    public class Meta
    {
        private static readonly DAL.BankCredit.MetaMapper metaMapper = new DAL.BankCredit.MetaMapper();

        /// <summary>
        /// 查找单个
        /// </summary>
        /// yangj    16.07.05
        /// <param name="metaCode">数据元标识</param>
        /// <returns></returns>
        public MetaInfo Find(int metaCode)
        {
            return metaMapper.Find(metaCode);
        }

        /// <summary>
        /// 查列表
        /// </summary>
        /// yangj    16.07.05
        /// <param name="metaCode">数据元标识</param> 
        /// <returns></returns>
        public DataTable List(Models.Pagination page, NameValueCollection filter)
        {
            return metaMapper.List(page, filter);
        }

        /// <summary>
        /// 增加一条数据元
        /// </summary>
        /// yangj    16.07.05
        /// <param name="value">数据元实体</param>
        /// <returns></returns>
        public bool Add(MetaInfo value)
        {
            metaMapper.Insert(value);

            return value.MetaCode > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yangj    16.07.05
        /// <param name="value">数据元实体</param>
        /// <returns></returns>
        public bool Modify(MetaInfo value)
        {
            return metaMapper.Update(value) > 0;
        }

        /// <summary>
        /// 根据数据元标识和服务对象作为复合主键，验证重复性
        /// </summary>
        /// yangj    16.07.07
        /// <param name="metaCode">数据元标识</param>
        /// <param name="type">服务对象</param>
        /// <returns></returns>
        public MetaInfo FindByPK(int metaCode, int type)
        {
            return metaMapper.FindByPK(metaCode,type);
        }

        /// <summary>
        /// 根据信息记录类型ID和数据段规则ID获取数据元实体
        /// </summary>
        /// yaoy    16.09.28
        /// <param name="infoTypeId"></param>
        /// <param name="segmentRulesId"></param>
        /// <returns></returns>
        public MetaInfo GetByInfoTypeIdAndSegmentRulesId(int infoTypeId,int segmentRulesId)
        {
            return metaMapper.FindByInfoTypeIdAndSegmentRulesId(infoTypeId, segmentRulesId);
        }
    }
}
