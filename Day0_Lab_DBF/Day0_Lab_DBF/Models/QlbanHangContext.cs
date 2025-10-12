using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Day0_Lab_DBF.Models;

public partial class QlbanHangContext : DbContext
{
    public QlbanHangContext()
    {
    }

    public QlbanHangContext(DbContextOptions<QlbanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CthoaDon> CthoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<QuanTri> QuanTris { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TblChatlieu> TblChatlieus { get; set; }

    public virtual DbSet<TblChiTietHdban> TblChiTietHdbans { get; set; }

    public virtual DbSet<TblHang> TblHangs { get; set; }

    public virtual DbSet<TblHdban> TblHdbans { get; set; }

    public virtual DbSet<TblKhach> TblKhaches { get; set; }

    public virtual DbSet<TblNhanvien> TblNhanviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=QLBanHang;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CthoaDon>(entity =>
        {
            entity.ToTable("CTHoaDon");

            entity.HasIndex(e => e.HoaDonId, "IX_CTHoaDon_HoaDonID");

            entity.HasIndex(e => e.SanPhamId, "IX_CTHoaDon_SanPhamID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGiaMua).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.HoaDon).WithMany(p => p.CthoaDons).HasForeignKey(d => d.HoaDonId);

            entity.HasOne(d => d.SanPham).WithMany(p => p.CthoaDons).HasForeignKey(d => d.SanPhamId);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.ToTable("HoaDon");

            entity.HasIndex(e => e.KhachHangId, "IX_HoaDon_KhachHangID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");
            entity.Property(e => e.TongTriGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.HoaDons).HasForeignKey(d => d.KhachHangId);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.ToTable("KhachHang");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.ToTable("LoaiSanPham");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<QuanTri>(entity =>
        {
            entity.ToTable("QuanTri");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.ToTable("SanPham");

            entity.HasIndex(e => e.LoaiSanPhamId, "IX_SanPham_LoaiSanPhamID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoaiSanPhamId).HasColumnName("LoaiSanPhamID");

            entity.HasOne(d => d.LoaiSanPham).WithMany(p => p.SanPhams).HasForeignKey(d => d.LoaiSanPhamId);
        });

        modelBuilder.Entity<TblChatlieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu).HasName("PK__tblChatl__453995BCCE5CBD96");

            entity.ToTable("tblChatlieu");

            entity.Property(e => e.MaChatLieu).HasMaxLength(10);
            entity.Property(e => e.TenChatLieu).HasMaxLength(50);
        });

        modelBuilder.Entity<TblChiTietHdban>(entity =>
        {
            entity.HasKey(e => new { e.MaHdban, e.MaHang }).HasName("PK__tblChiTi__828C639B1728D3F8");

            entity.ToTable("tblChiTietHDBan");

            entity.Property(e => e.MaHdban)
                .HasMaxLength(10)
                .HasColumnName("MaHDBan");
            entity.Property(e => e.MaHang).HasMaxLength(10);
            entity.Property(e => e.GiamGia)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ThanhTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.TblChiTietHdbans)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTiet_Hang");

            entity.HasOne(d => d.MaHdbanNavigation).WithMany(p => p.TblChiTietHdbans)
                .HasForeignKey(d => d.MaHdban)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTiet_HDBan");
        });

        modelBuilder.Entity<TblHang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__tblHang__19C0DB1D4277419E");

            entity.ToTable("tblHang");

            entity.Property(e => e.MaHang).HasMaxLength(10);
            entity.Property(e => e.Anh).HasMaxLength(255);
            entity.Property(e => e.DonGiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaChatLieu).HasMaxLength(10);
            entity.Property(e => e.TenHang).HasMaxLength(100);

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.TblHangs)
                .HasForeignKey(d => d.MaChatLieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hang_ChatLieu");
        });

        modelBuilder.Entity<TblHdban>(entity =>
        {
            entity.HasKey(e => e.MaHdban).HasName("PK__tblHDBan__43106E2A5BCB7518");

            entity.ToTable("tblHDBan");

            entity.Property(e => e.MaHdban)
                .HasMaxLength(10)
                .HasColumnName("MaHDBan");
            entity.Property(e => e.MaKhach).HasMaxLength(10);
            entity.Property(e => e.MaNhanvien).HasMaxLength(10);
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaKhachNavigation).WithMany(p => p.TblHdbans)
                .HasForeignKey(d => d.MaKhach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HDBan_Khach");

            entity.HasOne(d => d.MaNhanvienNavigation).WithMany(p => p.TblHdbans)
                .HasForeignKey(d => d.MaNhanvien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HDBan_Nhanvien");
        });

        modelBuilder.Entity<TblKhach>(entity =>
        {
            entity.HasKey(e => e.MaKhach).HasName("PK__tblKhach__D0CB8DDD69FF5D98");

            entity.ToTable("tblKhach");

            entity.Property(e => e.MaKhach).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.TenKhach).HasMaxLength(100);
        });

        modelBuilder.Entity<TblNhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNhanvien).HasName("PK__tblNhanv__81C97F057E3F6DC0");

            entity.ToTable("tblNhanvien");

            entity.Property(e => e.MaNhanvien).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.TenNhanvien).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
