﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao
{
    public class NhanVienDaoTaoSearchVM
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string? Ho { get; set; }
        public string? TenDem { get; set; }
        public string? Ten { get; set; }
        public int? GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string Email { get; set; }
        public int? TrangThai { get; set; }
    }
}