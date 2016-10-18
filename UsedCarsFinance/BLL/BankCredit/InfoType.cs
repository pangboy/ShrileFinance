using Model;
using Model.BankCredit;
using System;
using System.Collections.Generic;

namespace BLL.BankCredit
{
    public class InfoType
    {
        private static readonly DAL.BankCredit.InfoTypeMapper InfoTypeMapper = new DAL.BankCredit.InfoTypeMapper();

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public List<ComboInfo> GetComList(int messageTypeId)
        {
            return InfoTypeMapper.GetComList(messageTypeId);
        }

        /// <summary>
        /// 获取信息记录下拉框
        /// </summary>
        /// yand    16.08.02
        /// <param name="infoTypeID"></param>
        /// <returns></returns>
        public List<ComboInfo> GetList(int infoTypeID)
        {
            return InfoTypeMapper.GetList(infoTypeID);
        }

        /// <summary>
        /// 获取信息类型
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public InfoTypeInfo Get(int infoTypeId)
        {
            return InfoTypeMapper.Find(infoTypeId);
        }
    }
}
