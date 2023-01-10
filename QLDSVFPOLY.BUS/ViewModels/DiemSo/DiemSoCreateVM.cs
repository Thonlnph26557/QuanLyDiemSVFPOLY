using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.DiemSo
{
    public class DiemSoCreateVM
    {
        public Guid IdMonHoc { get; set; }
        public double TrongSo { get; set; }
        public double DiemToiThieu { get; set; }
        public string TenDauDiem { get; set; }
        public int TrangThai { get; set; }
    }
}
