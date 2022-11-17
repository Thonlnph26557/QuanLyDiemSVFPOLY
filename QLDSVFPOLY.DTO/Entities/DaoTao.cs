using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class DaoTao
    {
        public DaoTao()
        {
        }

        public DaoTao(Guid id, string ma, string diaChi, string soDienThoai, string email, string tenDangNhap, string matKhau, DateTime ngayTao, int trangThai)
        {
            Id = id;
            Ma = ma;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            NgayTao = ngayTao;
            TrangThai = trangThai;
        }

        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public List<ChuyenNganh> ChuyenNganhs { get; set; }
        public List<LopHoc> LopHocs { get; set; }
        public List<GiangVien> GiangViens { get; set; }
    }
}
