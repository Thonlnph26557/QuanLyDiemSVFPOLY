using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class GiangVien
    {

        public GiangVien()
        {

        }

        public GiangVien(Guid id, string ma, Guid idDaoTao, string ho, string tenDem, string ten, int gioiTinh, DateTime ngaySinh, string diaChi, string soDienThoai, string email, string tenDangNhap, string matKhau, string duongDanAnh, DateTime ngayTao, int trangThai)
        {
            Id = id;
            Ma = ma;
            IdDaoTao = idDaoTao;
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
        }

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
