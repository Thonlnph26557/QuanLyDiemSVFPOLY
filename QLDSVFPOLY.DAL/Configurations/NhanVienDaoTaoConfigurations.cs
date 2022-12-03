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
    public class NhanVienDaoTaoConfigurations : IEntityTypeConfiguration<NhanVienDaoTao>
    {
        public void Configure(EntityTypeBuilder<NhanVienDaoTao> builder)
        {
            builder.ToTable("NhanVienDaoTao");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ma);

            builder.Property(x => x.Ho);
            builder.Property(x => x.TenDem);
            builder.Property(x => x.Ten);
            builder.Property(x => x.GioiTinh);
            builder.Property(x => x.NgaySinh);
            builder.Property(x => x.DiaChi);
            builder.Property(x => x.SoDienThoai);
            builder.Property(x => x.Email);
            builder.Property(x => x.TenDangNhap);
            builder.Property(x => x.MatKhau);
            builder.Property(x => x.NgayTao);
            builder.Property(x => x.DuongDanAnh);
            builder.Property(x => x.TrangThai);

            builder.HasOne(x => x.DaoTao).WithMany(x => x.NhanVienDaoTaos).HasForeignKey(x => x.IdDaoTao);
        }
    }
}
