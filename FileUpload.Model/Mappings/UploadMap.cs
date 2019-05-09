using FileUpload.Model.Entities;

namespace FileUpload.Model.Mappings {
    public class UploadMap : BaseEntityMap<Upload> {
        public UploadMap() {
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.Path).HasColumnName("Path");
            Property(s => s.ContentType).HasColumnName("ContentType");
            Property(s => s.CreateDate).HasColumnName("CreateDate");
        }
    }
}
