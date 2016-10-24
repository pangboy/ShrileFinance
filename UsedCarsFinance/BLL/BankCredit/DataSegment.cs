using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.BankCredit;

namespace BLL.BankCredit
{
    public class DataSegment
    {
        private static readonly DAL.BankCredit.DataSegmentMapper dataSegmentMapper = new DAL.BankCredit.DataSegmentMapper();

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public List<ComboInfo> GetComList(int messageTypeId)
        {
            return dataSegmentMapper.FindComList(messageTypeId);
        }

        /// <summary>
        /// 根据信息记录ID获取段列表
        /// </summary>
        /// yand 16.05.25
        /// <param name="InfoTypeId">信息记录ID</param>
        /// <returns></returns>
        public List<DataSegmentInfo> GetByInfoTypeId(int InfoTypeId)
        {
            return dataSegmentMapper.FindByInfoTypeId(InfoTypeId);
        }

        /// <summary>
        /// 获取数据段实体
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="dataSegmentId"></param>
        /// <returns></returns>
        public DataSegmentInfo Get(int dataSegmentId)
        {
            return dataSegmentMapper.Find(dataSegmentId);
        }

        /// <summary>
        /// 获取数据段集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<DataSegmentInfo> List(int infoTypeId)
        {
            return dataSegmentMapper.List(infoTypeId);
        }

        /// <summary>
        /// 获取数据段必填项集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<DataSegmentInfo> GetMustList(int infoTypeId)
        {
            return dataSegmentMapper.FindMustList(infoTypeId);
        }

        /// <summary>
        /// 根据信息类型ID和段编码获取实体
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSegmentInfo GetByInfoTypeIdAndCode(int infoTypeId, string code)
        {
            return dataSegmentMapper.FindByInfoTypeAndCode(infoTypeId, code);
        }

        /// <summary>
        /// 根据信息类型ID和数据段规则ID获取数据段实体
        /// </summary>
        /// yaoy    16.09.28
        /// <param name="infoTypeId"></param>
        /// <param name="segmentRulesId"></param>
        /// <returns></returns>
        public DataSegmentInfo GetByInfoTypeIdAndSegmentRulesId(int infoTypeId,int segmentRulesId)
        {
            return dataSegmentMapper.FindByInfoTypeIdAndSegmentRulesId(infoTypeId, segmentRulesId);
        }
    }
}
