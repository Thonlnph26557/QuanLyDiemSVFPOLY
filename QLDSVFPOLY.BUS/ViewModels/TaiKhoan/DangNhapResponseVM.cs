using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.TaiKhoan
{
    public class DangNhapResponseVM
    {
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? NhapLaiMatKhau { get; set; }
        public string? ChucVu { get; set; }
        public string? TenHienThi { get; set; }
        public Guid? Id { get; set; }
        public Guid IdDaoTao { get; set; }
        public string Token { get; set; }
    }
}
