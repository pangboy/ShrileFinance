using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit
{
    public class DynamicLoad
    {
        private static readonly DAL.BankCredit.DataSegmentMapper dataSegmentMapper = new DAL.BankCredit.DataSegmentMapper();//数据段
        private static readonly DAL.BankCredit.SegmentRulesMapper segmentRuleMapper = new DAL.BankCredit.SegmentRulesMapper();
        private static readonly DAL.BankCredit.MetaMapper metaMapper = new DAL.BankCredit.MetaMapper();
        /// <summary>
        /// 根据信息记录ID获取页面实体
        /// </summary>
        /// yand    16.07.01
        /// <param name="InfoTypeId"></param>
        /// <returns></returns>
        public PageInfo GetPageInfo(int InfoTypeId)
        {
            PageInfo pageInfo = new PageInfo();
            InfoTypeInfo InfoTypeInfo = new DAL.BankCredit.InfoTypeMapper().Find(InfoTypeId);//获取信息记录实体

            pageInfo.PageName = InfoTypeInfo.InfoName;
            pageInfo.FieldsetList = FieldsetList(InfoTypeId);
            return pageInfo;
        }

        /// <summary>
        /// 段实体赋值
        /// </summary>
        /// yand    16.07.04
        /// <param name="infoTypeId">信息记录ID</param>
        /// <returns></returns>
        public List<FieldsetInfo> FieldsetList(int infoTypeId)
        {
            List<FieldsetInfo> fieldsetList = new List<FieldsetInfo>();

            // 获取数据段
            List<DataSegmentInfo> dataSegmentInfo = dataSegmentMapper.FindByInfoTypeId(infoTypeId);
            for (int i = 0; i < dataSegmentInfo.Count; i++)
            {
                FieldsetInfo fieldsetInfo = new FieldsetInfo();
                fieldsetInfo.Id = dataSegmentInfo[i].DataSegmentId;
                fieldsetInfo.Title = dataSegmentInfo[i].ParagraphName;
                fieldsetInfo.Min = Convert.ToInt32(dataSegmentInfo[i].times.Substring(0, 1));
                fieldsetInfo.Max = dataSegmentInfo[i].times.Substring(2, 1);
                fieldsetInfo.ParagraphCode = dataSegmentInfo[i].ParagraphCode;
                fieldsetInfo.Status = dataSegmentInfo[i].BRC_Status;
                // 根据段ID获取段中数据元信息
                fieldsetInfo.ComponentList = ComponentList(dataSegmentInfo[i].DataSegmentId);

                fieldsetList.Add(fieldsetInfo);
            }
            return fieldsetList;
        }

        /// <summary>
        /// 根据段ID获取段中元素实体
        /// </summary>
        /// yand    16.07.04
        /// zouql   16.09.20    新增RuleType
        /// <param name="DataSegmentId">段ID</param>
        /// <returns></returns>
        public List<ComponentInfo> ComponentList(int DataSegmentId)
        {
            List<ComponentInfo> componentList = new List<ComponentInfo>();

            // 获取数据段规则
            List<SegmentRulesInfo> segmentRulesList = segmentRuleMapper.List(DataSegmentId);
            List<MetaInfo> metaList = new List<MetaInfo>();
            for (int i = 0; i < segmentRulesList.Count; i++)
            {
                // 获取数据元
                MetaInfo metaInfo = metaMapper.Find(segmentRulesList[i].MetaCode);
                metaInfo.RuleType = new RuleType().Get(metaInfo.RuleType.RuleTypeId);
             
                // 获取HTML标签
                List<HtmlElementInfo> htmlElementList = new DAL.BankCredit.HtmlElementMapper().Find(segmentRulesList[i].MetaCode);
                MetaComponentsInfo GetMetaComponentsInfoByCode = new DataRule().GetMetaComponentsInfoByCode(segmentRulesList[i].MetaCode);
                // 一个数据元可能对应多个标签
                for (int j = 0; j < htmlElementList.Count; j++)
                {
                    ComponentInfo componentInfo = new ComponentInfo();
                    componentInfo.HtmlElement = htmlElementList[j].Html;
                    componentInfo.HtmlelementId = htmlElementList[j].HtmlElementID;
                    componentInfo.Type = GetMetaComponentsInfoByCode.Type;
                    componentInfo.IsRequired = segmentRulesList[i].IsRequired;
                    componentInfo.Length = metaInfo.DatasLength;
                    componentInfo.MetaName = metaInfo.Name;
                    componentInfo.DataType = metaInfo.DataType;
                    componentInfo.MetaCode = metaInfo.MetaCode;
                    componentInfo.SegmentRulesId = segmentRulesList[i].SegmentRulesId;
                    componentInfo.Description = segmentRulesList[i].Description;
                    componentInfo.RuleType = metaInfo.RuleType??new RuleTypeInfo();
                    componentList.Add(componentInfo);
                }
            }

            return componentList;
        }

    }
}