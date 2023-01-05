using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Entities
{
    public class DaoTao
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public List<ChuyenNganh> ChuyenNganhs { get; set; }
        public List<ChiTietLopHoc> ChiTietLopHocs { get; set; }
        public List<GiangVien> GiangViens { get; set; }
    }
}
