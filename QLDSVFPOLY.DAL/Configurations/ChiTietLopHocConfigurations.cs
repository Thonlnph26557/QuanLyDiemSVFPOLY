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
    public class ChiTietLopHocConfigurations : IEntityTypeConfiguration<ChiTietLopHoc>
    {
        public void Configure(EntityTypeBuilder<ChiTietLopHoc> builder)
        {
            builder.ToTable("ChiTietLopHoc");
            builder.HasKey(t => t.Id);
            /// builder.HasKey(x => new { x.Id, x.IdLopHoc, x.IdMonHoc, x.IdGiangVien, x.IdKiHoc });

            builder.Property(x => x.SoLuongSinhVien).IsRequired();
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();

            builder.HasOne(x => x.LopHoc).WithMany(x => x.ChiTietLopHoc).HasForeignKey(x => x.IdLopHoc).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.GiangVien).WithMany(x => x.ChiTietLopHoc).HasForeignKey(x => x.IdGiangVien).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.KiHoc).WithMany(x => x.ChiTietLopHocs).HasForeignKey(x => x.IdKiHoc).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MonHoc).WithMany(x => x.ChiTietLopHocs).HasForeignKey(x => x.IdMonHoc).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
