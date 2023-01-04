using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Configurations
{
    public class GiangVienConfigurations : IEntityTypeConfiguration<GiangVien>
    {
        public void Configure(EntityTypeBuilder<GiangVien> builder)
        {
            builder.ToTable("GiangVien");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ma).IsUnicode(false).HasMaxLength(10);

            builder.Property(x => x.Ho).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.TenDem).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.Ten).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.GioiTinh).IsRequired();
            builder.Property(x => x.NgaySinh).IsRequired();
            builder.Property(x => x.DiaChi).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.SoDienThoai).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.TenDangNhap).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.MatKhau).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.DuongDanAnh).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(x => x.TrangThai).IsRequired();

            builder.HasOne(dt => dt.DaoTao).WithMany(gv => gv.GiangViens).HasForeignKey(gv => gv.IdDaoTao).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
