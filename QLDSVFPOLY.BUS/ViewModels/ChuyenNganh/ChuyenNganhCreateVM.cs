using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChuyenNganh
{
    public class ChuyenNganhCreateVM
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Mã chuyên ngành không qua 10 tự")]
        public string Ma { get; set; }

        [Required]

        public string TenChuyenNganh { get; set; }

        public string DuongDanAnh { get; set; }

        public DateTime NgayTao { get; set; }

        [Required(ErrorMessage = "Hãy chọn Trạng Thái")]
        public int TrangThai { get; set; }

        public Guid? IdChuyenNganh { get; set; }

        public Guid IdDaoTao { get; set; }
    }
}
