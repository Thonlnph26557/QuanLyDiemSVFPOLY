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
    public class KiHocViewmodel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = ("Tên kì học tối đa 50 kí tự"))]
        public string? Ten { get; set; }
        public int NamHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
