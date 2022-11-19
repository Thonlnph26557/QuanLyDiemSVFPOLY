using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class MonHoc
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string DuongDanAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public Guid IdChuyenNganh { get; set; }


        public ChuyenNganh ChuyenNganh { get; set; }
        public List<ChiTietLopHoc> ChiTietLopHocs { get; set; }
    }
}
