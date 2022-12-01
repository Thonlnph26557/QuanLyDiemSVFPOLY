using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Entities
{
    public class ChuyenNganh
    {
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

        //de day de deej quy
        public List<ChuyenNganh> ChuyenNganhs { get; set; }
        public ChuyenNganh ChuyenNganhDQ { get; set; }

    }
}
