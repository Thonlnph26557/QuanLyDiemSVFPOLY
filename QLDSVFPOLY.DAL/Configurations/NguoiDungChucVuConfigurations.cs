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
    public class NguoiDungChucVuConfigurations : IEntityTypeConfiguration<NguoiDungChucVu>
    {
        public void Configure(EntityTypeBuilder<NguoiDungChucVu> builder)
        {
            builder.ToTable("NguoiDungChucVu");
            builder.HasKey(x => new { x.IdChucVu, x.IdNguoiDung});

            builder.Property(x => x.NgayTao);
            builder.Property(x => x.TrangThai);

            builder.HasOne(x => x.ChucVu).WithMany(x => x.NguoiDungChucVus).HasForeignKey(x => x.IdChucVu);
            builder.HasOne(x => x.NguoiDung).WithMany(x => x.NguoiDungChucVus).HasForeignKey(x => x.IdNguoiDung);
        }
    }
}
