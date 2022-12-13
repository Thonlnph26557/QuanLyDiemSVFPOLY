using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.SinhVien
{
    public class SinhVienCreateVM
    {
        //public Guid Id { get; set; }
        [Required(ErrorMessage = ("Trường này không được để trống"))]
        [MaxLength(10, ErrorMessage = "Mã sinh viên không nhập quá 10 ký tự")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Không điền các kí tự đặc biệt")]
        public string? Ma { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        [MaxLength(50, ErrorMessage = "Họ sinh viên không nhập quá 50 ký tự")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Không điền các kí tự đặc biệt")]
        public string? Ho { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        [MaxLength(50, ErrorMessage = "Tên đệm sinh viên không nhập quá 50 ký tự")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Không điền các kí tự đặc biệt")]
        public string? TenDem { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        [MaxLength(50, ErrorMessage = "Tên giảng viên không nhập quá 50 ký tự")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Không điền các kí tự đặc biệt")]
        public string? Ten { get; set; }

        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        [MaxLength(50, ErrorMessage = "Địa chỉ không nhập quá 50 ký tự")]
        public string? DiaChi { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        [MaxLength(11, ErrorMessage = "Số điện thoại không nhập quá 11 ký tự")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Số điện thoại phải là số tự nhiên")]
        public string? SoDienThoai { get; set; }

        [Required(ErrorMessage = ("Trường này không được để trống"))]
        [MaxLength(50, ErrorMessage = "Email không nhập quá 50 ký tự")]
        public string? Email { get; set; }

        //[Required(ErrorMessage = ("Trường này không được để trống"))]
        //[MaxLength(50)]
        public string? TenDangNhap { get; set; }
        //[Required(ErrorMessage = ("Trường này không được để trống"))]
        //[MaxLength(50)]
        public string? MatKhau { get; set; }
        public string? DuongDanAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public Guid IdChuyenNganh { get; set; }
    }
}
