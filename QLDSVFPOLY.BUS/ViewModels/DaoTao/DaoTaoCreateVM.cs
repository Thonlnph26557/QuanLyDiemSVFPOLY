using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Đổi tên namespace đúng model
namespace QLDSVFPOLY.BUS.ViewModels.DaoTao
{
    //> public
    public class DaoTaoCreateVM
    {
        public string Ma { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
