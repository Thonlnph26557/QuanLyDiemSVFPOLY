using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChucVu
{
    public class ChucVuVM
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
