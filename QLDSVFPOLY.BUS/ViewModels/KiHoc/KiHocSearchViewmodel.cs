using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Đổi tên namespace đúng model
namespace QLDSVFPOLY.BUS.ViewModels.KiHoc
{
    //> public
    public class KiHocSearchViewmodel
    {
        //public Guid Id { get; set; }
        public string? Ten { get; set; }
        public int NamHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        //public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
