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
    public class KiHocConfigurations : IEntityTypeConfiguration<KiHoc>
    {
        public void Configure(EntityTypeBuilder<KiHoc> builder)
        {
            builder.ToTable("KiHoc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ten).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.NamHoc).IsRequired();
            builder.Property(x => x.NgayBatDau).IsRequired();
            builder.Property(x => x.NgayKetThuc).IsRequired();
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();

        }
    }
}
