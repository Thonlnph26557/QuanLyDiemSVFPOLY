using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Configurations
{
    public class SinhVienConfigurations : IEntityTypeConfiguration<SinhVien>
    {
        public void Configure(EntityTypeBuilder<SinhVien> builder)
        {
            builder.ToTable("SinhVien");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).IsUnicode(false).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Ho).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(x => x.TenDem).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(x => x.Ten).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(x => x.GioiTinh).IsRequired();
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.NgaySinh).IsRequired();
            builder.Property(x => x.DiaChi).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(x => x.SoDienThoai).IsUnicode(false).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).IsUnicode(false).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TenDangNhap).IsUnicode(false).HasMaxLength(50).IsRequired();
            builder.Property(x => x.MatKhau).IsUnicode(false).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();
            builder.Property(x => x.DuongDanAnh).HasColumnType("varchar(max)").IsRequired();
            builder.Property(x => x.IdChuyenNganh).IsRequired();

            builder.HasOne(dt => dt.ChuyenNganh).WithMany(sv => sv.SinhViens).HasForeignKey(cn => cn.IdChuyenNganh);
        }
    }
}
