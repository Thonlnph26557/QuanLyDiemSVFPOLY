using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.TaiKhoan
{
    public class DoiMatKhauVM
    {
        [Required(ErrorMessage = ("Trường này không được để trống"))]
        public string? TaiKhoan { get; set; }
        [Required(ErrorMessage =("Trường này không được để trống"))]
        public string? MatKhau { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        [Compare(nameof(MatKhau), ErrorMessage = ("Nhập lại mật khẩu không đúng"))]
        public string? NhapLaiMatKhau { get; set; }
        public string ChucVu { get; set; }
    }
}
