using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Configurations
{
    public class ChuyenNganhMonHocConfigurations : IEntityTypeConfiguration<ChuyenNganhMonHoc>
    {
        public void Configure(EntityTypeBuilder<ChuyenNganhMonHoc> builder)
        {
            builder.ToTable("ChuyenNganhMonHoc");
            builder.HasKey(c => new { c.IdMonHoc, c.IdChuyenNganh});

            builder.Property(c => c.NgayTao);
            builder.Property(c => c.TrangThai);

            builder.HasOne(c => c.ChuyenNganh).WithMany(c => c.ChuyenNganhMonHocs).HasForeignKey(c => c.IdChuyenNganh);
            builder.HasOne(c => c.MonHoc).WithMany(c => c.ChuyenNganhMonHocs).HasForeignKey(c => c.IdMonHoc);

        }
    }
}
