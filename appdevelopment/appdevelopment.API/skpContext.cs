using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace appdevelopment.API
{
    public partial class skpContext : DbContext
    {
        public skpContext()
        {
        }

        public skpContext(DbContextOptions<skpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<User> Users { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=144.91.122.78;user=forceskp;password=ForceSKP;database=skp", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.25-mariadb"));
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("File");

                entity.HasIndex(e => e.UserId, "FK_File_Users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FilenName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UploadDate).HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_File_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
