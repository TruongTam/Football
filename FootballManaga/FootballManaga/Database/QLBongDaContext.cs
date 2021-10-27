using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FootballManaga.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FootballManaga.Database
{
    public partial class QLBongDaContext : DbContext
    {
        public QLBongDaContext()
        {
        }

        public QLBongDaContext(DbContextOptions<QLBongDaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bangxh> Bangxh { get; set; }
        public virtual DbSet<Caulacbo> Caulacbo { get; set; }
        public virtual DbSet<Cauthu> Cauthu { get; set; }
        public virtual DbSet<HlvClb> HlvClb { get; set; }
        public virtual DbSet<Huanluyenvien> Huanluyenvien { get; set; }
        public virtual DbSet<Quocgia> Quocgia { get; set; }
        public virtual DbSet<Sanvd> Sanvd { get; set; }
        public virtual DbSet<Tinh> Tinh { get; set; }
        public virtual DbSet<Trandau> Trandau { get; set; }
        public virtual DbSet<Username> Username { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=TRUONGTAM\\SQLEXPRESS01;Initial Catalog=QLBongDa;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bangxh>(entity =>
            {
                entity.HasKey(e => new { e.Maclb, e.Nam, e.Vong });

                entity.ToTable("BANGXH");

                entity.Property(e => e.Maclb)
                    .HasColumnName("MACLB")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Nam).HasColumnName("NAM");

                entity.Property(e => e.Vong).HasColumnName("VONG");

                entity.Property(e => e.Diem).HasColumnName("DIEM");

                entity.Property(e => e.Hang).HasColumnName("HANG");

                entity.Property(e => e.Hieuso)
                    .IsRequired()
                    .HasColumnName("HIEUSO")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Hoa).HasColumnName("HOA");

                entity.Property(e => e.Sotran).HasColumnName("SOTRAN");

                entity.Property(e => e.Thang).HasColumnName("THANG");

                entity.Property(e => e.Thua).HasColumnName("THUA");

                entity.HasOne(d => d.MaclbNavigation)
                    .WithMany(p => p.Bangxh)
                    .HasForeignKey(d => d.Maclb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BANGXH_CAULACBO");
            });

            modelBuilder.Entity<Caulacbo>(entity =>
            {
                entity.HasKey(e => e.Maclb)
                    .HasName("PK_CAULACBO_MACLB");

                entity.ToTable("CAULACBO");

                entity.Property(e => e.Maclb)
                    .HasColumnName("MACLB")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Masan)
                    .IsRequired()
                    .HasColumnName("MASAN")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Matinh)
                    .IsRequired()
                    .HasColumnName("MATINH")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Tenclb)
                    .IsRequired()
                    .HasColumnName("TENCLB")
                    .HasMaxLength(100);

                entity.HasOne(d => d.MasanNavigation)
                    .WithMany(p => p.Caulacbo)
                    .HasForeignKey(d => d.Masan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAULACBO_SANVD");

                entity.HasOne(d => d.MatinhNavigation)
                    .WithMany(p => p.Caulacbo)
                    .HasForeignKey(d => d.Matinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAULACBO_TINH");
            });

            modelBuilder.Entity<Cauthu>(entity =>
            {
                entity.HasKey(e => e.Mact)
                    .HasName("PK_CAUTHU_MACT");

                entity.ToTable("CAUTHU");

                entity.Property(e => e.Mact)
                    .HasColumnName("MACT")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(200);

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("HOTEN")
                    .HasMaxLength(100);

                entity.Property(e => e.Maclb)
                    .IsRequired()
                    .HasColumnName("MACLB")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Maqg)
                    .IsRequired()
                    .HasColumnName("MAQG")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("datetime");

                entity.Property(e => e.So).HasColumnName("SO");

                entity.Property(e => e.Vitri)
                    .IsRequired()
                    .HasColumnName("VITRI")
                    .HasMaxLength(20);

                entity.HasOne(d => d.MaclbNavigation)
                    .WithMany(p => p.Cauthu)
                    .HasForeignKey(d => d.Maclb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAUTHU_CAULACBO");

                entity.HasOne(d => d.MaqgNavigation)
                    .WithMany(p => p.Cauthu)
                    .HasForeignKey(d => d.Maqg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAUTHU_QUOCGIA");
            });

            modelBuilder.Entity<HlvClb>(entity =>
            {
                entity.HasKey(e => new { e.Mahlv, e.Maclb });

                entity.ToTable("HLV_CLB");

                entity.Property(e => e.Mahlv)
                    .HasColumnName("MAHLV")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Maclb)
                    .HasColumnName("MACLB")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Vaitro)
                    .IsRequired()
                    .HasColumnName("VAITRO")
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaclbNavigation)
                    .WithMany(p => p.HlvClb)
                    .HasForeignKey(d => d.Maclb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HLV_CLB_CAULACBO");

                entity.HasOne(d => d.MahlvNavigation)
                    .WithMany(p => p.HlvClb)
                    .HasForeignKey(d => d.Mahlv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HLV_CLB_HUANLUYENVIEN");
            });

            modelBuilder.Entity<Huanluyenvien>(entity =>
            {
                entity.HasKey(e => e.Mahlv)
                    .HasName("PK_HUANLUYENVIEN_MAHLV");

                entity.ToTable("HUANLUYENVIEN");

                entity.Property(e => e.Mahlv)
                    .HasColumnName("MAHLV")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(200);

                entity.Property(e => e.Dienthoai)
                    .HasColumnName("DIENTHOAI")
                    .HasMaxLength(20);

                entity.Property(e => e.Maqg)
                    .IsRequired()
                    .HasColumnName("MAQG")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tenhlv)
                    .IsRequired()
                    .HasColumnName("TENHLV")
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaqgNavigation)
                    .WithMany(p => p.Huanluyenvien)
                    .HasForeignKey(d => d.Maqg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HUANLUYENVIEN_QUOCGIA");
            });

            modelBuilder.Entity<Quocgia>(entity =>
            {
                entity.HasKey(e => e.Maqg)
                    .HasName("PK_QUOCGIA_MAQG");

                entity.ToTable("QUOCGIA");

                entity.Property(e => e.Maqg)
                    .HasColumnName("MAQG")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Tenqg)
                    .IsRequired()
                    .HasColumnName("TENQG")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Sanvd>(entity =>
            {
                entity.HasKey(e => e.Masan)
                    .HasName("PK_SANVD_MASAN");

                entity.ToTable("SANVD");

                entity.Property(e => e.Masan)
                    .HasColumnName("MASAN")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(200);

                entity.Property(e => e.Tensan)
                    .IsRequired()
                    .HasColumnName("TENSAN")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tinh>(entity =>
            {
                entity.HasKey(e => e.Matinh)
                    .HasName("PK_TINH_MATINH");

                entity.ToTable("TINH");

                entity.Property(e => e.Matinh)
                    .HasColumnName("MATINH")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Tentinh)
                    .IsRequired()
                    .HasColumnName("TENTINH")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Trandau>(entity =>
            {
                entity.HasKey(e => e.Matran)
                    .HasName("PK_TRANDAU_MATRAN");

                entity.ToTable("TRANDAU");

                entity.Property(e => e.Matran)
                    .HasColumnName("MATRAN")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Ketqua)
                    .IsRequired()
                    .HasColumnName("KETQUA")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Maclb1)
                    .IsRequired()
                    .HasColumnName("MACLB1")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Maclb2)
                    .IsRequired()
                    .HasColumnName("MACLB2")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Masan)
                    .IsRequired()
                    .HasColumnName("MASAN")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Nam).HasColumnName("NAM");

                entity.Property(e => e.Ngaytd)
                    .HasColumnName("NGAYTD")
                    .HasColumnType("datetime");

                entity.Property(e => e.Vong).HasColumnName("VONG");

                entity.HasOne(d => d.Maclb1Navigation)
                    .WithMany(p => p.TrandauMaclb1Navigation)
                    .HasForeignKey(d => d.Maclb1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANDAU_CAULACBO1");

                entity.HasOne(d => d.Maclb2Navigation)
                    .WithMany(p => p.TrandauMaclb2Navigation)
                    .HasForeignKey(d => d.Maclb2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANDAU_CAULACBO2");

                entity.HasOne(d => d.MasanNavigation)
                    .WithMany(p => p.Trandau)
                    .HasForeignKey(d => d.Masan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANDAU_SANVD");
            });

            modelBuilder.Entity<Username>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username1)
                    .HasColumnName("Username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<FootballManaga.Models.IndexModelsViews> IndexModelsViews { get; set; }
    }
}
