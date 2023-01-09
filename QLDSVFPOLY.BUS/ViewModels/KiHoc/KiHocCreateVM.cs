using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Đổi tên namespace đúng model
namespace QLDSVFPOLY.BUS.ViewModels.KiHoc
{
    //> public
    public class KiHocCreateVM
    {

        [Required(ErrorMessage = "Tên kì học không được để trống")]
        [MaxLength(50, ErrorMessage = "Tên kì học tối đa 50 kí tự")]
        public string Ten { get; set; }
        
        [Required(ErrorMessage = "Năm học không được để trống")]
        [RegularExpression(@"^[0-9]*[1-9][0-9]*$", ErrorMessage = "Năm học phải là số nguyên")]
        public int NamHoc { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public DateTime NgayTao { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái")]
        public int TrangThai { get; set; }
    }
}
