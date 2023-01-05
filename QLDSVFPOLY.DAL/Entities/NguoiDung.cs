using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Entities
{
    public class NguoiDung
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public List<NguoiDungChucVu> NguoiDungChucVus { get; set; }
    }
}
