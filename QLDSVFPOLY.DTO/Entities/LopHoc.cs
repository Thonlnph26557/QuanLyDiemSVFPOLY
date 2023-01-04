﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Entities
{
    public class LopHoc
    {

        public LopHoc()
        {

        }

        public LopHoc(Guid id, string ma, Guid idDaoTao, DateTime ngayTao, int trangThai)
        {
            Id = id;
            Ma = ma;
            IdDaoTao = idDaoTao;
            NgayTao = ngayTao;
            TrangThai = trangThai;

        }
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public Guid IdDaoTao { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }


        // relationship 

        public DaoTao DaoTao { get; set; }
        public List<ChiTietLopHoc> ChiTietLopHoc { get; set; }
    }
}
