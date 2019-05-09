using FileUpload.Model.Entities;
using FileUpload.Model.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FileUpload.Model {
    public class ModelContext : DbContext {
        public ModelContext() : base("FileUpload-VS") {
            //Database.SetInitializer<ModelContext>(null);
            Database.SetInitializer(new CreateDatabase());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Upload> Uploads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UploadMap());
        }
    }

    public class CreateDatabase : DropCreateDatabaseIfModelChanges<ModelContext> { }
}
