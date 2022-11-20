using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DTO.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Configurations
{
    public class ChuyenNganhConfigurations : IEntityTypeConfiguration<ChuyenNganh>
    {
        public void Configure(EntityTypeBuilder<ChuyenNganh> builder)
        {
            builder.ToTable("ChuyenNganh");

            builder.HasKey(t => t.Id);
            builder.Property(x => x.Ma).IsUnicode(false).IsRequired().HasMaxLength(10);
            builder.Property(x => x.TenNganhHoc).IsUnicode().IsRequired().HasMaxLength(50);
            builder.Property(x => x.DuongDanAnh).HasColumnType("varchar(max)").IsRequired();
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();

            builder.Property(x => x.IdChuyenNganh);

            builder.HasOne(dt => dt.DaoTao).WithMany(cn => cn.ChuyenNganhs).HasForeignKey(cn => cn.IdDaoTao).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(cn1 => cn1.ChuyenNganhDQ).WithMany(cn => cn.ChuyenNganhs).HasForeignKey(cn => cn.IdChuyenNganh).OnDelete(DeleteBehavior.NoAction);

            //
        }
    }
}
