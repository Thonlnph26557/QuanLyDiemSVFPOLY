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
    public class LopHocConfigurations : IEntityTypeConfiguration<LopHoc>
    {
        public void Configure(EntityTypeBuilder<LopHoc> builder)
        {
            builder.ToTable("LopHoc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ma).IsUnicode(false).HasMaxLength(10);

            builder.Property(x => x.NgayTao).IsRequired();
            builder.Property(x => x.TrangThai).IsRequired();

            builder.HasOne(dt => dt.DaoTao).WithMany(lh => lh.LopHocs).HasForeignKey(lh => lh.IdDaoTao).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
