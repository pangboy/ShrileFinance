using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BankCredit
{

    /// <summary>
    /// 报文文种
    /// cais    16.05.25
    /// </summary>
    public class MessageFileTypeInfo
    {
        public int MFT_ID { get; set; }
        public string FileTypeName { get; set; }
        public int FileType { get; set; }
        public List<MessageFileInfo> MessageFileList { get; set; }
    }
}
