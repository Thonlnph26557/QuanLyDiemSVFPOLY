using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class ChuyenNganh
    {
        public ChuyenNganh()
        {
        }

        public ChuyenNganh(Guid id, string ma, string tenNganhHoc, string duongDanAnh, DateTime ngayTao, int trangThai, Guid idChuyenNganh, Guid idDaoTao)
        {
            Id = id;
            Ma = ma;
            TenNganhHoc = tenNganhHoc;
            DuongDanAnh = duongDanAnh;
            NgayTao = ngayTao;
            TrangThai = trangThai;
            IdChuyenNganh = idChuyenNganh;
            IdDaoTao = idDaoTao;
        }

        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenNganhHoc { get; set; }
        public string DuongDanAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }

        public Guid? IdChuyenNganh { get; set; }
        public Guid IdDaoTao { get; set; }

        public DaoTao DaoTao { get; set; }

        public List<SinhVien> SinhViens { get; set; }
        public List<MonHoc> MonHocs { get; set; }

        //phần này sử dụng cho đệ quy
        public List<ChuyenNganh> ChuyenNganhs { get; set; }
        public ChuyenNganh ChuyenNganhDQ { get; set; }
    }
}
