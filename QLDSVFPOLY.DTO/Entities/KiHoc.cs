using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class KiHoc
    {

        public KiHoc()
        {

        }

        public KiHoc(Guid id, string ten, int namHoc, DateTime ngayBatDau, DateTime ngayKetThuc, DateTime ngayTao, int trangThai)
        {
            Id = id;
            Ten = ten;
            NamHoc = namHoc;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            NgayTao = ngayTao;
            TrangThai = trangThai;
        }

        public Guid Id { get; set; }
        public string Ten { get; set; }
        public int NamHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }



        // relationship 

        public List<ChiTietLopHoc> ChiTietLopHocs { get; set; }
    }
}
