using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc
{
    public class ChiTietLopHocUpdateVM
    {
        //public Guid Id { get; set; }
        //public Guid IdDaoTao { get; set; }
        public Guid IdMonHoc { get; set; }
        public Guid IdGiangVien { get; set; }
        public Guid IdKiHoc { get; set; }
        public string Ten { get; set; }
        public int SoLuongSinhVien { get; set; }
        //public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
