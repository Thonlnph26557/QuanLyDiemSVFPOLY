using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChuyenNganh
{
    public class ChuyenNganhUpdateVM
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Mã chuyên ngành không được để trống")]
        [MaxLength(10, ErrorMessage = "Mã chuyên ngành không qua 10 tự")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Không điền các kí tự đặc biệt")]
        public string? Ma { get; set; }

        [Required(ErrorMessage = "Tên chuyên ngành không được để trống")]
        [MaxLength(50, ErrorMessage = "Tên chuyên ngành không qua 50 tự")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Không điền các kí tự đặc biệt")]
        public string? TenChuyenNganh { get; set; }

        public string? DuongDanAnh { get; set; }

        [Required(ErrorMessage = "Hãy chọn Trạng Thái")]
        public int TrangThai { get; set; }

        public Guid? IdChuyenNganh { get; set; }
    }
}
