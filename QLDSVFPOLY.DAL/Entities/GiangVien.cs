using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Entities
{
    public class GiangVien
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }
        public Guid IdDaoTao { get; set; }
        public string Ho { get; set; }
        public string TenDem { get; set; }
        public string Ten { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string DuongDanAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        // relationship 

        public DaoTao DaoTao { get; set; }
        public List<ChiTietLopHoc> ChiTietLopHoc { get; set; }
    }
}
