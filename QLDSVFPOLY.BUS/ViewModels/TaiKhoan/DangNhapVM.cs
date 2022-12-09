using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.TaiKhoan
{
    public class DangNhapVM
    {
        [Required(ErrorMessage = ("Trường này không được để trống"))]
        public string? TaiKhoan { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        public string? MatKhau { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        public string? NhapLaiMatKhau { get; set; }
        public string? ChucVu { get; set; }
        public string? TenHienThi { get; set; }
        public Guid IdDaoTao { get; set;}
    }
}
