using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChuyenNganh
{
    public class ChuyenNganhUpdateVM
    {
        public string? Ma { get; set; }
        public string? TenNganhHoc { get; set; }
        public string? DuongDanAnh { get; set; }
        public int TrangThai { get; set; }
        public Guid? IdChuyenNganh { get; set; }
    }
}
