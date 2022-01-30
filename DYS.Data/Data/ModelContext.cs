using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using DYS.Common.VO;
using System.Configuration;

namespace DYS.Data.Data
{
    public class ModelContext : DbContext
    {
        public DbSet<Kullanici> Kullanicis { get; set; }

        public DbSet<Proje> Projes { get; set; }

        public DbSet<Gorev> Gorevs { get; set; }

        public DbSet<Rol> Rols { get; set; }

        public DbSet<SayfaAltYetkiler> SayfaAltYetkilers { get; set; }

        public DbSet<SayfaIslemler> SayfaIslemlers { get; set; }

        public DbSet<Sayfalar> Sayfalars { get; set; }

        public DbSet<SayfaYetkiler> SayfaYetkilers { get; set; }
        public DbSet<Mesaj> Mesajs { get; set; }
        public DbSet<AltGorev> AltGorevs { get; set; }

        public DbSet<DegerlendirmeDurumu> DegerlendirmeDurumus { get; set; }

        public DbSet<DokumanGorev> DokumanGorevs { get; set; }

        public DbSet<DokumanProje> DokumanProjes { get; set; }

        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<ProjectMessage> ProjectMessages { get; set; } 
       // public DbSet<Kullanici> Kullanicis2 { get; set; }

        public DbSet<FileManagement> FileManagements { get; set; }

        public DbSet<FolderManagement> FolderManagements { get; set; }

        public DbSet<DetayliDegerlendirme> DetayliDegerlendirmes { get; set; }
        public DbSet<ReportManagement> ReportManagements { get; set; }
        public DbSet<TagManagement> TagManagements { get; set; }

        #region Constructor

        public ModelContext()
            : base(CS)
        {

        }

        #endregion

        #region Static

        #region  Field
        private static string CS
        {
            get { return ConfigurationManager.ConnectionStrings["cs"].ConnectionString; }
        }
        #endregion

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KullaniciConfiguration());

            modelBuilder.Configurations.Add(new ProjeConfiguration());

            modelBuilder.Configurations.Add(new GorevConfiguration());

            modelBuilder.Configurations.Add(new RolConfiguration());

            modelBuilder.Configurations.Add(new SayfaAltYetkilerConfiguration());

            modelBuilder.Configurations.Add(new SayfaIslemlerConfiguration());

            modelBuilder.Configurations.Add(new SayfalarConfiguration());

            modelBuilder.Configurations.Add(new SayfaYetkilerConfiguration());
            modelBuilder.Configurations.Add(new AltGorevConfiguration());

            modelBuilder.Configurations.Add(new DegerlendirmeDurumuConfiguration());

            modelBuilder.Configurations.Add(new DokumanGorevConfiguration());

            modelBuilder.Configurations.Add(new DokumanProjeConfiguration());
            
            modelBuilder.Configurations.Add(new MesajConfiguration());
            modelBuilder.Configurations.Add(new UserFriendConfiguration());
            modelBuilder.Configurations.Add(new ProjectMessageConfiguration());

            modelBuilder.Configurations.Add(new FileManagementConfiguration());

            modelBuilder.Configurations.Add(new FolderManagementConfiguration());

            modelBuilder.Configurations.Add(new DetayliDegerlendirmeConfiguration());
            modelBuilder.Configurations.Add(new ReportManagementConfiguration());
            modelBuilder.Configurations.Add(new TagManagementConfiguration());

            modelBuilder.Entity<UserFriend>()
                .HasRequired(m => m.Kullanici1)
                .WithMany(t => t.User)
                .HasForeignKey(m => m.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserFriend>()
                .HasRequired(m => m.Kullanici2)
                .WithMany(t => t.UserJobFriend)
                .HasForeignKey(m => m.UserJobFriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mesaj>()
                .HasRequired(m => m.GonderenKullanici)
                .WithMany(t => t.GonderenKullanici)
                . HasForeignKey(m => m.GonderenKullaniciId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<DegerlendirmeDurumu>()
                .HasRequired(m => m.AtayanKullanici)
                .WithMany(t => t.UserAppoint)
                .HasForeignKey(m => m.AtayanKullaniciId)
                .WillCascadeOnDelete(false);

        /*   modelBuilder.Entity<FolderManagement>()
                .HasRequired(m=>m.FolderManagement2)
                .WithMany(t=> t.FolderManagements)
                .HasForeignKey(m =>m.ParentId)
                .WillCascadeOnDelete(false);*/
        


        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public class KullaniciConfiguration : EntityTypeConfiguration<Kullanici>
        {
            public KullaniciConfiguration()
            {
                ToTable("Kullanici");
            }
        }

        public class ProjeConfiguration : EntityTypeConfiguration<Proje>
        {
            public ProjeConfiguration()
            {
                ToTable("Proje");
            }
        }

        public class GorevConfiguration : EntityTypeConfiguration<Gorev>
        {
            public GorevConfiguration()
            {
                ToTable("Gorev");
            }
        }


        public class RolConfiguration : EntityTypeConfiguration<Rol>
        {
            public RolConfiguration()
            {
                ToTable("Rol");
            }
        }

        public class SayfaAltYetkilerConfiguration : EntityTypeConfiguration<SayfaAltYetkiler>
        {
            public SayfaAltYetkilerConfiguration()
            {
                ToTable("SayfaAltYetkiler");
            }
        }

        public class SayfaIslemlerConfiguration : EntityTypeConfiguration<SayfaIslemler>
        {
            public SayfaIslemlerConfiguration()
            {
                ToTable("SayfaIslemler");
            }
        }

        public class SayfalarConfiguration : EntityTypeConfiguration<Sayfalar>
        {
            public SayfalarConfiguration()
            {
                ToTable("Sayfalar");
            }
        }

        public class SayfaYetkilerConfiguration : EntityTypeConfiguration<SayfaYetkiler>
        {
            public SayfaYetkilerConfiguration()
            {
                ToTable("SayfaYetkiler");
            }
        }

        public class AltGorevConfiguration : EntityTypeConfiguration<AltGorev>
        {
            public AltGorevConfiguration()
            {
                ToTable("AltGorev");
            }
        }

        public class DegerlendirmeDurumuConfiguration : EntityTypeConfiguration<DegerlendirmeDurumu>
        {
            public DegerlendirmeDurumuConfiguration()
            {
                ToTable("DegerlendirmeDurumu");
            }
        }

        public class DokumanGorevConfiguration : EntityTypeConfiguration<DokumanGorev>
        {
            public DokumanGorevConfiguration()
            {
                ToTable("DokumanGorev");
            }
        }

        public class DokumanProjeConfiguration : EntityTypeConfiguration<DokumanProje>
        {
            public DokumanProjeConfiguration()
            {
                ToTable("DokumanProje");
            }
        }
       
        public class MesajConfiguration : EntityTypeConfiguration<Mesaj>
        {
            public MesajConfiguration()
            {
                ToTable("Mesaj");
            }
        }
        public class UserFriendConfiguration : EntityTypeConfiguration<UserFriend>
        {
            public UserFriendConfiguration()
            {
                ToTable("UserFriend");
            }
        }
        public class ProjectMessageConfiguration : EntityTypeConfiguration<ProjectMessage>
        {
            public ProjectMessageConfiguration()
            {
                ToTable("ProjectMessage");
            }
        }
        public class FileManagementConfiguration : EntityTypeConfiguration<FileManagement>
        {
            public FileManagementConfiguration()
            {
                ToTable("FileManagement");
            }
        }

        public class FolderManagementConfiguration : EntityTypeConfiguration<FolderManagement>
        {
            public FolderManagementConfiguration()
            {
                ToTable("FolderManagement");
            }
        }
        public class DetayliDegerlendirmeConfiguration : EntityTypeConfiguration<DetayliDegerlendirme>
        {
            public DetayliDegerlendirmeConfiguration()
            {
                ToTable("DetayliDegerlendirme");
            }
        }
        public class ReportManagementConfiguration : EntityTypeConfiguration<ReportManagement>
        {
            public ReportManagementConfiguration()
            {
                ToTable("ReportManagement");
            }
        }
        public class TagManagementConfiguration : EntityTypeConfiguration<TagManagement>
        {
            public TagManagementConfiguration()
            {
                ToTable("TagManagement");
            }
        }
    }
}