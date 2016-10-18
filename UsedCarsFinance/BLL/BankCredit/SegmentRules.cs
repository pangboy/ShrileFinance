using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using Model;
using Model.BankCredit;

namespace BLL.BankCredit
{
    public class SegmentRules
    {
        private static readonly DAL.BankCredit.SegmentRulesMapper SegmentRulesMapper = new DAL.BankCredit.SegmentRulesMapper();

        /// <summary>
        /// 查询实体
        /// </summary>
        /// yaoy    16.07.04
        /// <param name="segmentRulesId"></param>
        /// <returns></returns>
        public SegmentRulesInfo Get(int segmentRulesId)
        {
            return SegmentRulesMapper.Find(segmentRulesId);
        }

        /// <summary>
        /// 查询集合
        /// </summary>
        /// yaoy    16.07.04
        /// <param name="dataSegmentId"></param>
        /// <returns></returns>
        public List<SegmentRulesInfo> List(int dataSegmentId)
        {
            return SegmentRulesMapper.List(dataSegmentId);
        }

        /// <summary>
        /// 获取段规则列表
        /// </summary>
        /// zouql 16.07.06
        /// <param name="pagination">Pagination</param>
        /// <param name="filter">NameValueCollection</param>
        /// <returns>DataTable</returns>
        public DataTable PageList(Pagination pagination, NameValueCollection filter)
        {
            return SegmentRulesMapper.PageList(pagination, filter);
        }

        /// <summary>
        /// 根据信息记录类型ID和数据元ID获取数据段规则集合
        /// </summary>
        /// yaoy    16.09.21
        /// <param name="infoTypeId"></param>
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public List<SegmentRulesInfo> GetByInfoTypeIdAndMetaCode(int infoTypeId, int metaCode)
        {
            return SegmentRulesMapper.FindByInfoTypeIdAndMetaCode(infoTypeId, metaCode);
        }

        /// <summary>
        /// 根据信息记录类型ID和数据段编码获取数据段规则集合
        /// </summary>
        /// yaoy    16.09.23
        /// <param name="infoTypeId">信息记录类型ID</param>
        /// <param name="code">数据段编码</param>
        /// <returns></returns>
        public List<SegmentRulesInfo> GetSegmentRulesIdByInfoTypeIdAndCode(int infoTypeId, string code)
        {
            return SegmentRulesMapper.FindSegmentRulesByInfoTypeIdAndCode(infoTypeId, code);
        }

        /// <summary>
        /// 根据信息类型ID、数据元ID和数据段名称获取数据段规则
        /// </summary>
        /// yaoy    16.09.23
        /// <param name="infoTypeId"></param>
        /// <param name="metaCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public SegmentRulesInfo GetSegmentRulesByInfoTypeIdAndMetaCodeAndCode(int infoTypeId, int metaCode, string code)
        {
            return SegmentRulesMapper.FindSegmentRulesByInfoTypeIdAndMetaCodeAndCode(infoTypeId, metaCode, code);
        }

        /// <summary>
        /// 添加段规则
        /// </summary>
        /// zouql 16.07.06
        /// <param name="sr">段规则实体</param>
        /// <param name="messages">消息</param>
        /// <returns>结果</returns>
        public bool Create(SegmentRulesInfo sr, out string messages)
        {
            messages = string.Empty;

            bool b = false;

            if (CheckSeed(sr))
            {
                b = SegmentRulesMapper.Create(sr) > 0;
            }
            else
            {
                messages = "该记录已存在！";
            }

            return b;
        }

        /// <summary>
        /// 修改段规则
        /// </summary>
        /// zouql 16.07.06
        /// <param name="sr">段规则实体</param>
        /// <returns>结果</returns>
        public bool Modify(SegmentRulesInfo sr)
        {
            return SegmentRulesMapper.Modify(sr) > 0;
        }

        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="bsrId">主键ID</param>
        /// <param name="metaCode">数据元ID</param>
        /// <returns>实体</returns>
        public SegmentRulesInfo Get(string bsrId, string metaCode)
        {
            return SegmentRulesMapper.Get(bsrId, metaCode);
        }

        /// <summary>
        /// 检查种子是否已被使用
        /// </summary>
        /// zouql 16.07.06
        /// <param name="sr">实体</param>
        /// <returns>结果</returns>
        public bool CheckSeed(SegmentRulesInfo sr)
        {
            var p = SegmentRulesMapper.CheckSeed(sr);

            return p == null ? true : false;
        }

        /// <summary>
        /// 获取元代码名称列表
        /// </summary>
        /// zouql 16.07.07
        /// <returns>列表集合</returns>
        public List<ComboInfo> GetComListMateName()
        {
            return SegmentRulesMapper.GetComListMateName();
        }

        /// <summary>
        /// 获取元代码名称列表
        /// </summary>
        /// zouql 16.07.07
        /// <param name="type">类型</param>
        /// <returns>列表集合</returns>
        public List<ComboInfo> GetComListMateName(string type)
        {
            return SegmentRulesMapper.GetComListMateName(type);
        }

        /// <summary>
        /// 获取元代码名称列表
        /// </summary>
        /// zouql 16.07.07
        /// <param name="value">查询值</param>
        /// <param name="type">类型</param>
        /// <returns>集合</returns>
        public List<ComboInfo> GetComListMateName(string value, string type)
        {
            return SegmentRulesMapper.GetComListMateName(value, type);
        }

        /// <summary>
        /// 根据元数据ID获取数据段规则集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public List<SegmentRulesInfo> GetSegmentRulesByMetaCode(int metaCode)
        {
            return SegmentRulesMapper.FindSegmentRulesByMetaCode(metaCode);
        }

        /// <summary>
        /// 根据信息记录ID和固定位置获取数据段规则ID
        /// </summary>
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public SegmentRulesInfo GetSegmentRulesIdByInfoTypeIdAndPosition(int infoTypeId)
        {
            return SegmentRulesMapper.FindSegmentRulesIdByInfoTypeIdAndPosition(infoTypeId);
        }

        /// <summary>
        /// 获取段规则标识
        /// </summary>
        /// zouql   16.09.27
        /// <param name="infoTypeId">信息记录Id</param>
        /// <param name="metaCode">数据元Id</param>
        /// <param name="paragraphCode">段Id</param>
        /// <returns>段规则标识</returns>
        public string GetIdByMetaAndInfoType(int infoTypeId, int metaCode, string paragraphCode)
        {
            return SegmentRulesMapper.FindIdByMetaAndInfoType(infoTypeId, metaCode, paragraphCode);
        }

        /// <summary>
        /// 获取数据（段Code，段Id，数据元Code，必填）
        /// </summary>
        /// zouql   16.09.27
        /// <param name="infoTypeId">信息记录Id</param>
        /// <returns>段规则标识</returns>
        public Dictionary<string, string> GetDataByMetaId(int infoTypeId)
        {
            // 返回数据
            return SegmentRulesMapper.FindDataByMetaId(infoTypeId);
        }
    }
}
