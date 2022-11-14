using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities.EF
{
    public class Startup : IDesignTimeDbContextFactory<QLSVDbContext>
    {
        QLSVDbContext IDesignTimeDbContextFactory<QLSVDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QLSVDbContext>();

            optionsBuilder.UseSqlServer(@"SERVER=FX580VN\SQLEXPRESS;DATABASE=QLSV_DB;Integrated Security=True;Encrypt=False;");

            return new QLSVDbContext(optionsBuilder.Options);
            //Source=FX580VN\SQLEXPRESS;Persist Security Info=True;User ID=thaoph;Password=***********
            //Server=myServerAddress;Database=myDataBase;Trusted_Connection=True
        }
    }
}
