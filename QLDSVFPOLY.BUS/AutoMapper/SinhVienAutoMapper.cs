using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class SinhVienAutoMapper : Profile
    {
        public SinhVienAutoMapper()
        {
            CreateMap<SinhVienVM, SinhVien>().ReverseMap();
        }
    }
}
