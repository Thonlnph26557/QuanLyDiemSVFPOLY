using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc
{
    public class ChuyenNganhMonHocCreateVM
    {
        public Guid IdChuyenNganh { get; set; }
        public Guid IdMonHoc { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
