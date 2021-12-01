using System;
using System.Collections.Generic;

#nullable disable

namespace appdevelopment.API
{
    public partial class File
    {
        public int Id { get; set; }
        public string FilenName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
