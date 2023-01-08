using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.NguoiDungChucVu
{
    public class NguoiDungChucVuCreateVM
    {
        public Guid IdNguoiDung { get; set; }
        public Guid IdChucVu { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
