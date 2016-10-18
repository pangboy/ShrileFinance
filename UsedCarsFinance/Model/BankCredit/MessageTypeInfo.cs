using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BankCredit
{
    /// <summary>
    /// 报文表
    /// </summary>
    public class MessageTypeInfo
    {
        [Alias("BMT_ID")]
        public int MessageTypeId { get; set; }

        public string BMP_Code { get; set; }

        public string Describe { get; set; }

        [Alias("BMF_ID")]
        public int MessageFileId { get; set; }

        public List<InfoTypeInfo> InfoTypeList { get; set; }

    }
}
