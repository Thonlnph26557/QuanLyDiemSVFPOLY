using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DAL.Configurations;
using System.Collections.Generic;
using System.Reflection.Emit;
//using QLDSVFPOLY.DAL.Extensions;

namespace QLDSVFPOLY.DAL.Entities.EF
{
    public class QLSVDbContext : DbContext
    {
        public QLSVDbContext()
        {
        }

        public QLSVDbContext(DbContextOptions options) : base(options)
        {
        }

        //Config
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DaoTaoConfigurations());
            modelBuilder.ApplyConfiguration(new MonHocConfigurations());
            modelBuilder.ApplyConfiguration(new ChuyenNganhConfigurations());
            modelBuilder.ApplyConfiguration(new SinhVienConfigurations());
            modelBuilder.ApplyConfiguration(new GiangVienConfigurations());
            modelBuilder.ApplyConfiguration(new KiHocConfigurations());
            modelBuilder.ApplyConfiguration(new ChiTietLopHocConfigurations());
            modelBuilder.ApplyConfiguration(new DiemSoConfigurations());
            modelBuilder.ApplyConfiguration(new ChiTietDiemSoConfigurations());
            modelBuilder.ApplyConfiguration(new ChuyenNganhMonHocConfigurations());
            modelBuilder.ApplyConfiguration(new NhanVienDaoTaoConfigurations());
            //modelBuilder.SeedData();
        }

        //thay đổi đường dẫn để kết nối SQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=DESKTOP-CCPL472;DATABASE=DA1_DB;Integrated Security=True;Encrypt=False;");
        }


        //DbSet
        public DbSet<DaoTao> DaoTaos { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<KiHoc> KiHocs { get; set; }
        public DbSet<ChiTietDiemSo> ChiTietDiemSos { get; set; }
        public DbSet<DiemSo> DiemSos { get; set; }
        public DbSet<ChiTietLopHoc> ChiTietLopHocs { get; set; }
        public DbSet<ChuyenNganhMonHoc> ChuyenNganhMonHocs { get; set; }
        public DbSet<NhanVienDaoTao> NhanVienDaoTaos { get; set; }
    }
}

