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
    public class ChiTietDiemSoConfigurations : IEntityTypeConfiguration<ChiTietDiemSo>
    {
        public void Configure(EntityTypeBuilder<ChiTietDiemSo> builder)
        {
            builder.ToTable("ChiTietDiemSo");
            builder.HasKey(x => new { x.IdChiTietLopHoc, x.IdDiemSo, x.IdSinhVien });

            builder.Property(x => x.Diem).IsRequired();
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();


            builder.HasOne(x => x.DiemSo).WithMany(x => x.ChiTietDiemSos).HasForeignKey(x => x.IdDiemSo).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SinhVien).WithMany(x => x.ChiTietDiemSos).HasForeignKey(x => x.IdSinhVien).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ChiTietLopHoc).WithMany(x => x.ChiTietDiemSos).HasForeignKey(x => x.IdChiTietLopHoc).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
