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

        public DiemSo(Guid idChiTietLopHoc, Guid idSinhVien, string tenDiemSo, double trongSo, double diem, DateTime ngayTao, int trangThai)
        {
            IdChiTietLopHoc = idChiTietLopHoc;
            IdSinhVien = idSinhVien;
            TenDiemSo = tenDiemSo;
            TrongSo = trongSo;
            Diem = diem;
            NgayTao = ngayTao;
            TrangThai = trangThai;
        }

        public Guid IdChiTietLopHoc { get; set; }
        public Guid IdSinhVien { get; set; }
        public string TenDiemSo { get; set; }
        public double TrongSo { get; set; }
        public double Diem { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }


        public SinhVien SinhVien { get; set; }
        public ChiTietLopHoc ChiTietLopHoc { get; set; }
    }
}
