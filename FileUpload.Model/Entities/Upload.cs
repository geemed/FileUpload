using System;

namespace FileUpload.Model.Entities {
    public class Upload : BaseEntity {
        public string Name { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
