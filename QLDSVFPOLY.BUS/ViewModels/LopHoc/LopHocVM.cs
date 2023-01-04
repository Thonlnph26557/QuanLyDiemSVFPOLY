using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Đổi tên namespace đúng model

namespace QLDSVFPOLY.BUS.ViewModels.LopHoc
{
    //> public
    public class LopHocVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Mã lớp học không được để trống")]
        [MaxLength(50, ErrorMessage = "Mã lớp học tối đa 10 kí tự")]
        public string? Ma { get; set; }
        public Guid? IdDaoTao { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
