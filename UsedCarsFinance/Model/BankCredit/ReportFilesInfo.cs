using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
    public class ReportFilesInfo
    {
        public int FileID { get; set; }

        public int ReportState { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime SendTime { get; set; }

        public int ServiceObj { get; set; }

        public string ReportTextName { get; set; }
        public string Remarks { get; set; }
        public string Operator { get; set; }
        public string FilesName { get; set; }
        public int MessageFileId { get; set; }

    }
}
