using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL.BankCredit
{
    public class MessageType
    {
        private readonly static DAL.BankCredit.MessageTypeMapper messageTypeMapper = new DAL.BankCredit.MessageTypeMapper();

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="fileId"></param>
        /// <returns></returns>
        public List<ComboInfo> GetComList(int fileId)
        {
            return messageTypeMapper.FindComList(fileId);
        }

        /// <summary>
        /// 通过文件类型获取下拉框列表
        /// </summary>
        /// yaoy    16.07.06
        /// <param name="fileType"></param>
        /// <returns></returns>
        public List<ComboInfo> GetComListByFileType(int fileType)
        {
            return messageTypeMapper.FindComListByFileType(fileType);
        }
        /// <summary>
        /// 根据MessageTypeID获取信息记录类型列表
        /// </summary>
        /// yand    16.07.11
        /// <param name="messageTypeID">信息记录类型ID</param>
        /// <returns></returns>
        public List<ComboInfo> GetList(int messageTypeID)
        {
            return new DAL.BankCredit.MessageTypeMapper().FindList(messageTypeID);
        }

    }
}
