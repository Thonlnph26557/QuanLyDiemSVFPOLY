using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Đổi tên namespace đúng model
namespace QLDSVFPOLY.BUS.ViewModels.LopHoc
{
    //> public
    public class LopHocSearchViewmodel
    {
        //public Guid Id { get; set; }
        public string? Ma { get; set; }

        //public Guid IdDaoTao { get; set; }
        //public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
