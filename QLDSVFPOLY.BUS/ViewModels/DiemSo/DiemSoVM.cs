using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo
{
    public class DiemSoVM
    {
        public Guid Id { get; set; }
        public double TrongSo { get; set; }
        public string TenDiemSo { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
