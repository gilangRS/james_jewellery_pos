using System;
using Connection.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Connection.AccountModels
{
    public partial class AccountContext : DbContext
    {
        private ConnectionString connectionStrings;
        public AccountContext()
        {
            this.connectionStrings = new ConnectionString();
        }

        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogGantiPassword> LogGantiPasswords { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAccess> RoleAccesses { get; set; }
        public virtual DbSet<UserAccess> UserAccesses { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserApproval> UserApprovals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionStrings.ConnectionStrings.Cnn_AC);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LogGantiPassword>(entity =>
            {
                entity.ToTable("LogGantiPassword");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nik)
                    .HasMaxLength(10)
                    .HasColumnName("NIK");

                entity.Property(e => e.OldPassword).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Menu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Menu");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<RoleAccess>(entity =>
            {
                entity.ToTable("RoleAccess");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idmenu).HasColumnName("IDMenu");

                entity.Property(e => e.Idrole).HasColumnName("IDRole");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAccess>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserAccess");

                entity.Property(e => e.Idmenu).HasColumnName("IDMenu");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("UserAccount");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Blokir).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ImgAccount).IsUnicode(false);

                entity.Property(e => e.ImgPicture).IsUnicode(false);

                entity.Property(e => e.ImgSignature).IsUnicode(false);

                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.Property(e => e.Keterangan)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PassResetKey)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecycleLast).HasColumnType("datetime");

                entity.Property(e => e.SessionId)
                    .IsUnicode(false)
                    .HasColumnName("SessionID");

                entity.Property(e => e.Sms)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("SMS");

                entity.Property(e => e.UserNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserApproval>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserApproval");

                entity.Property(e => e.Approval)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idrole).HasColumnName("IDRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
