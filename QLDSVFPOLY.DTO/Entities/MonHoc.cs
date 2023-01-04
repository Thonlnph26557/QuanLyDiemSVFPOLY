using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class MonHoc
    {
        public MonHoc()
        {
        }

        public MonHoc(Guid id, string ma, string ten, string duongDanAnh, DateTime ngayTao, int trangThai, Guid idChuyenNganh)
        {
            Id = id;
            Ma = ma;
            Ten = ten;
            DuongDanAnh = duongDanAnh;
            NgayTao = ngayTao;
            TrangThai = trangThai;
            IdChuyenNganh = idChuyenNganh;
        }

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
