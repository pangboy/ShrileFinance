using System;

namespace Models.Sys
{
    /// <summary>
    /// 文件信息
    /// </summary>
    /// qiy		16.03.07
    public class FileInfo
    {
        [Alias("FL_ID")]
        public int FileId { get; set; }
        public Guid ReferenceId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string OldName { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string NewName { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string ExtName { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string FilePath { get; set; }
        public DateTime AddDate { get; set; }

        public string FileName { get { return OldName + ExtName; } }
        public string FullName { get { return FilePath + NewName + ExtName; } }
    }
}
