using System;

namespace Models.BankCredit
{
    public class InformationRecordInfo
    {
        public int RecordID { get; set; }

        public string Context { get; set; }

        public DateTime addtime { get; set; }

        public string Describe { get; set; }

        public int InfoTypeID { get; set; }

        public int ReportID { get; set; }
    }
}