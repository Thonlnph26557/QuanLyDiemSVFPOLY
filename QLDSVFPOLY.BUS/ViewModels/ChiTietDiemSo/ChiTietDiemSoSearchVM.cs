﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo
{
    public class ChiTietDiemSoSearchVM
    {
        public Guid IdChiTietLopHoc { get; set; }
        public Guid IdSinhVien { get; set; }
        public Guid IdDiemSo { get; set; }
        public double Diem { get; set; }
        public double TrongSo { get; set; }
        public double DiemToiThieu { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
