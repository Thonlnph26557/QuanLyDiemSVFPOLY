using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class ChiTietLopHoc
    {

        public ChiTietLopHoc()
        {

        }

        public ChiTietLopHoc(Guid id, Guid idLopHoc, Guid idMonHoc, Guid idGiangVien, Guid idKiHoc, int soLuongSinhVien, DateTime ngayTao, int trangThai)
        {
            Id = id;
            IdLopHoc = idLopHoc;
            IdMonHoc = idMonHoc;
            IdGiangVien = idGiangVien;
            IdKiHoc = idKiHoc;
            SoLuongSinhVien = soLuongSinhVien;
            NgayTao = ngayTao;
            TrangThai = trangThai;
        }


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

        public SinhVien SinhVien { get; set; }

        public List<DiemSo> DiemSos { get; set; }
    }
}
