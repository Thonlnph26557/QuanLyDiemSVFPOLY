using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Đổi tên namespace đúng model
namespace QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc
{
    //> public
    public class ChiTietLopHocSearchVM
    {
        //public Guid Id { get; set; }
        public Guid IdLopHoc { get; set; }
        public Guid IdMonHoc { get; set; }
        public Guid IdGiangVien { get; set; }
        public Guid IdKiHoc { get; set; }
        public int SoLuongSinhVien { get; set; }
        //public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
