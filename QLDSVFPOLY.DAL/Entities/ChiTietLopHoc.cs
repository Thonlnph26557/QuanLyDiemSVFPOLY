using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Entities
{
    public class ChiTietLopHoc
    {
        public Guid Id { get; set; }
        public Guid IdDaoTao { get; set; }
        public Guid IdMonHoc { get; set; }
        public Guid IdGiangVien { get; set; }
        public Guid IdKiHoc { get; set; }
        public string Ten { get; set; }
        public int SoLuongSinhVien { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        // relationship 

        public GiangVien GiangVien { get; set; }

        public MonHoc MonHoc { get; set; }

        public DaoTao DaoTao { get; set; }

        public KiHoc KiHoc { get; set; }

        public List<ChiTietDiemSo> ChiTietDiemSos { get; set; }
    }
}
