namespace WcfServiceLibrary1Demo2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PYS_demo : DbContext
    {
        public PYS_demo()
            : base("name=PYS_demo")
        {
        }

        public virtual DbSet<AltGorev> AltGorev { get; set; }
        public virtual DbSet<DegerlendirmeDurumu> DegerlendirmeDurumu { get; set; }
        public virtual DbSet<DetayliDegerlendirme> DetayliDegerlendirme { get; set; }
        public virtual DbSet<DokumanGorev> DokumanGorev { get; set; }
        public virtual DbSet<DokumanProje> DokumanProje { get; set; }
        public virtual DbSet<FileManagement> FileManagement { get; set; }
        public virtual DbSet<FolderManagement> FolderManagement { get; set; }
        public virtual DbSet<Gorev> Gorev { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Mesaj> Mesaj { get; set; }
        public virtual DbSet<Proje> Proje { get; set; }
        public virtual DbSet<ProjectMessage> ProjectMessage { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<SayfaAltYetkiler> SayfaAltYetkiler { get; set; }
        public virtual DbSet<SayfaIslemler> SayfaIslemler { get; set; }
        public virtual DbSet<Sayfalar> Sayfalar { get; set; }
        public virtual DbSet<SayfaYetkiler> SayfaYetkiler { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserFriend> UserFriend { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltGorev>()
                .Property(e => e.Durum)
                .IsFixedLength();

            modelBuilder.Entity<DegerlendirmeDurumu>()
                .HasMany(e => e.DetayliDegerlendirme)
                .WithRequired(e => e.DegerlendirmeDurumu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FolderManagement>()
                .HasMany(e => e.FolderManagement1)
                .WithOptional(e => e.FolderManagement2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Gorev>()
                .HasMany(e => e.DegerlendirmeDurumu)
                .WithRequired(e => e.Gorev)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.DegerlendirmeDurumu)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Mesaj)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Proje)
                .WithRequired(e => e.Kullanici)
                .HasForeignKey(e => e.YoneticiKullaniciId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.UserFriend)
                .WithRequired(e => e.Kullanici)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.UserFriend1)
                .WithRequired(e => e.Kullanici1)
                .HasForeignKey(e => e.UserJobFriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proje>()
                .HasMany(e => e.DokumanProje)
                .WithRequired(e => e.Proje)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proje>()
                .HasMany(e => e.Gorev)
                .WithRequired(e => e.Proje)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proje>()
                .HasMany(e => e.ProjectMessage)
                .WithOptional(e => e.Proje)
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Kullanici)
                .WithRequired(e => e.Rol)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.SayfaAltYetkiler)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.SayfaYetkiler)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SayfaIslemler>()
                .HasMany(e => e.SayfaAltYetkiler)
                .WithRequired(e => e.SayfaIslemler)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sayfalar>()
                .HasMany(e => e.SayfaIslemler)
                .WithRequired(e => e.Sayfalar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sayfalar>()
                .HasMany(e => e.SayfaYetkiler)
                .WithRequired(e => e.Sayfalar)
                .WillCascadeOnDelete(false);
        }
    }
}
