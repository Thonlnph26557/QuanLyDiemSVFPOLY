﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.NguoiDung
{
    public class NguoiDungVM
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
    }
}
