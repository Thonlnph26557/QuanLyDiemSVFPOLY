using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class ChiTietDiemSo
    {
        public ChiTietDiemSo()
        {
        }

        public ChiTietDiemSo(Guid idChiTietLopHoc, Guid idSinhVien, Guid idDiemSo, double diem, DateTime ngayTao, int trangThai)
        {
            IdChiTietLopHoc = idChiTietLopHoc;
            IdSinhVien = idSinhVien;
            IdDiemSo = idDiemSo;
            Diem = diem;
            NgayTao = ngayTao;
            TrangThai = trangThai;
        }

        public Guid IdChiTietLopHoc { get; set; }
        public Guid IdSinhVien { get; set; }
        public Guid IdDiemSo { get; set; }
        public double Diem { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public SinhVien SinhVien { get; set; }
        public ChiTietLopHoc ChiTietLopHoc { get; set; }
        public DiemSo DiemSo { get; set; }
    }
}