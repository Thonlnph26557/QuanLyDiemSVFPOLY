using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSVFPOLY.DTO.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QLDSVFPOLY.DTO.Configurations
{
    public class MonHocConfigurations : IEntityTypeConfiguration<MonHoc>
    {
        public void Configure(EntityTypeBuilder<MonHoc> builder)
        {
            builder.ToTable("MonHoc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ma).IsUnicode(false).IsRequired().HasMaxLength(10);
            builder.Property(x => x.DuongDanAnh).HasColumnType("varchar(max)").IsRequired();
            builder.Property(x => x.Ten).IsUnicode().IsRequired().HasMaxLength(50);
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();
            builder.Property(x => x.IdChuyenNganh).IsRequired();

            builder.HasOne(cn => cn.ChuyenNganh).WithMany(mh => mh.MonHocs).HasForeignKey(mh => mh.IdChuyenNganh);
        }
    }
}
