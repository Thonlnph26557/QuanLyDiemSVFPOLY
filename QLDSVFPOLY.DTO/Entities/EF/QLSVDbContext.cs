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
        }

        //DbSet
        public DbSet<DaoTao> DaoTaos { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Thực hiện các ràng buộc kết nối
        //    base.OnConfiguring(optionsBuilder.
        //        UseSqlServer(@"Data Source=FX580VN\SQLEXPRESS;Initial Catalog=DuAn;Persist Security Info=True;User ID=thaoph;Password=123"));
        //}
    }




}

