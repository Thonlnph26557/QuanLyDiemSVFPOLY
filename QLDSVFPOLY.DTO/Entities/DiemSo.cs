using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class DiemSo
    {
        public DiemSo()
        {
        }

        public DiemSo(Guid id, double trongSo, double tenDiemSo, DateTime ngayTao, int trangThai)
        {
            Id = id;
            TrongSo = trongSo;
            TenDiemSo = tenDiemSo;
            NgayTao = ngayTao;
            TrangThai = trangThai;
        }

        public Guid Id { get; set; }
        public double TrongSo { get; set; }
        public double TenDiemSo { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public List<ChiTietDiemSo> ChiTietDiemSos { get; set; }
    }
}
