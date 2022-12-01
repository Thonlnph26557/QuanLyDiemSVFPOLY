using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Entities
{
    public class DiemSo
    {
        public Guid Id { get; set; }
        public double TrongSo { get; set; }
        public string TenDauDiem { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public List<ChiTietDiemSo> ChiTietDiemSos { get; set; }
    }
}