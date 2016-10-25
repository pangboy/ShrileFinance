using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
    /// <summary>
    /// 报文文件表
    /// cais    16.05.25
    /// </summary>
    public class MessageFileInfo
    {
        [Alias("BMF_ID")]
        public int MessageFileId { get; set; }
        public string FileName { get; set; }

        [Alias("MFT_ID")]
        public int MessageFileTypeId { get; set; }

        public List<MessageTypeInfo> MessageTypeList { get; set; }
    }
}
