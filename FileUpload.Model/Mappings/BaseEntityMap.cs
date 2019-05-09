using FileUpload.Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FileUpload.Model.Mappings {
    public class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity {
        public BaseEntityMap() {
            ToTable(typeof(T).Name);

            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("Id");
            Property(s => s.ConcurrencyId).HasColumnName("ConcurrencyId")
                .IsConcurrencyToken();
        }
    }
}
