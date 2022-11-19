using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class ChiTietLopHoc
    {
        public Guid Id { get; set; }
        public Guid IdLopHoc { get; set; }
        public Guid IdMonHoc { get; set; }
        public Guid IdGiangVien { get; set; }
        public Guid IdKiHoc { get; set; }
        public int SoLuongSinhVien { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        // relationship 

        public GiangVien GiangVien { get; set; }

        public MonHoc MonHoc { get; set; }

        public LopHoc LopHoc { get; set; }

        public KiHoc KiHoc { get; set; }

        public List<ChiTietDiemSo> ChiTietDiemSos { get; set; }
    }
}
