using System;
using System.Collections.Generic;
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
        public string TenDauDiem { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
