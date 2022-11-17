using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class SinhVien
    {
        public SinhVien()
        {
        }

        public SinhVien(Guid id, string ma, string ho, string tenDem, string ten, int gioiTinh, DateTime ngaySinh, string diaChi, string soDienThoai, string email, string tenDangNhap, string matKhau, string duongDanAnh, DateTime ngayTao, int trangThai, Guid idChuyenNganh)
        {
            Id = id;
            Ma = ma;
            Ho = ho;
            TenDem = tenDem;
            Ten = ten;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            DuongDanAnh = duongDanAnh;
            NgayTao = ngayTao;
            TrangThai = trangThai;
            IdChuyenNganh = idChuyenNganh;
        }

        public Guid Id { get; set; }
        public string Ma { get; set; }
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

        public Guid IdChuyenNganh { get; set; }

        public ChuyenNganh ChuyenNganh { get; set; }
        public List<ChiTietDiemSo> ChiTietDiemSos { get; set; }
    }
}
