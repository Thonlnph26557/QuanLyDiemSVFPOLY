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
    public class DiemSoConfigurations : IEntityTypeConfiguration<DiemSo>
    {
        public void Configure(EntityTypeBuilder<DiemSo> builder)
        {
            builder.ToTable("DiemSo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenDauDiem).IsUnicode(true).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DiemToiThieu);
            builder.Property(x => x.TrongSo).IsRequired();
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();

            builder.HasOne(x => x.MonHoc).WithMany(x => x.DiemSos).HasForeignKey(x => x.IdMonHoc);
        }
    }
}