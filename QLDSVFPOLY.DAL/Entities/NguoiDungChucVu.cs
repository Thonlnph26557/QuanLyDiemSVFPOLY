using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Entities
{
    public class NguoiDungChucVu
    {
        public Guid IdNguoiDung { get; set; }
        public Guid IdChucVu { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public ChucVu ChucVu { get; set; }
        public NguoiDung NguoiDung { get; set; }
    }
}
