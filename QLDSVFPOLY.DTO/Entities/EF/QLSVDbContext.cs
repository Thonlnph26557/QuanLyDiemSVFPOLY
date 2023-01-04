using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DTO.Configurations;

namespace QLDSVFPOLY.DTO.Entities.EF
{
    public class QLSVDbContext : DbContext
    {
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
            modelBuilder.ApplyConfiguration(new LopHocConfigurations());
            modelBuilder.ApplyConfiguration(new DiemSoConfigurations());
            modelBuilder.ApplyConfiguration(new ChiTietDiemSoConfigurations());
        }

        //DbSet
        public DbSet<DaoTao> DaoTaos { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<KiHoc> KiHocs { get; set; }
        public DbSet<DiemSo> DiemSos { get; set; }
        public DbSet<ChiTietDiemSo> ChiTietDiemSos { get; set; }
        public DbSet<ChiTietLopHoc> ChiTietLopHocs { get; set; }
    }
}

