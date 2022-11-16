﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Configurations
{
    public class DiemSoConfigurations : IEntityTypeConfiguration<DiemSo>
    {
        public void Configure(EntityTypeBuilder<DiemSo> builder)
        {
            builder.ToTable("DiemSo");
            builder.HasKey(x => new { x.IdSinhVien, x.IdChiTietLopHoc });
            builder.Property(x => x.TenDiemSo).IsUnicode(true).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TrongSo).IsRequired();
            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();

            builder.HasOne(sv => sv.SinhVien).WithMany(ds => ds.DiemSos).HasForeignKey(x => x.IdSinhVien).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(sv => sv.ChiTietLopHoc).WithMany(ds => ds.DiemSos).HasForeignKey(x => x.IdChiTietLopHoc).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
