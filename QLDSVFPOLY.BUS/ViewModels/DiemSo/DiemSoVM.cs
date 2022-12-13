using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.DiemSo
{
    public class DiemSoVM
    {
        public Guid Id { get; set; }
        public Guid IdMonHoc { get; set; }
        public double TrongSo { get; set; }
        [Required (ErrorMessage ="Tên điểm số không được để trống")]
        [MaxLength(50, ErrorMessage = "Tên điểm số tối đa 50 kí tự")]
        public string TenDauDiem { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
