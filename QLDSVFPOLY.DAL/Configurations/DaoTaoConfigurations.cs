using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Configurations
{
    public class DaoTaoConfigurations : IEntityTypeConfiguration<DaoTao>
    {
        public void Configure(EntityTypeBuilder<DaoTao> builder)
        {
            builder.ToTable("DaoTao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).IsRequired().IsUnicode(false).HasMaxLength(10);
            builder.Property(x => x.DiaChi).IsUnicode().HasMaxLength(100);
            builder.Property(x => x.SoDienThoai).IsUnicode(false).HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.TenDangNhap).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.MatKhau).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();
        }
    }
}
