using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class GiangVienAutoMapper : Profile
    {
        public GiangVienAutoMapper()
        {
            CreateMap<GiangVienVM, GiangVien>().ReverseMap();
        }
    }
}
