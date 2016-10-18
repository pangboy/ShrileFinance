using System.Collections.Generic;

namespace Model.BankCredit
{
    /// <summary>
    /// 报文段实体
    /// </summary>
    /// yand    16.06.01
    public class MessageInfo
    {
        public List<Dictionary<string, string>> A { get; set; }
        public List<Dictionary<string, string>> B { get; set; }

        public List<Dictionary<string, string>> C { get; set; }

        public List<Dictionary<string, string>> D { get; set; }

        public List<Dictionary<string, string>> E { get; set; }

        public List<Dictionary<string, string>> F { get; set; }

        public List<Dictionary<string, string>> G { get; set; }

        public List<Dictionary<string, string>> H { get; set; }

        public List<Dictionary<string, string>> I { get; set; }
        public List<Dictionary<string, string>> J { get; set; }

        public List<Dictionary<string, string>> K { get; set; }

    }

    /// <summary>
    /// 前台报文传值
    /// </summary>
    /// yand    16.06.01
    /// yangj   16.09.21    新增临时数据标识
    public class PostMessage
    {
        //标识报文中信息种类
        public int InfoTypeId { get; set; }

        //报文类型
        public int ReportId { get; set; }

        //报文体数据
        public string Value { get; set; }
        public int recordID { get; set; }
        public int messageTypeID { get; set; }
        //// 临时数据标识
        //public int TempInfoId { get; set; }
    }
}
