using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class ChiTietLopHocProfile : Profile
    {
        public ChiTietLopHocProfile()
        {
            CreateMap<ChiTietLopHoc, ChiTietLopHocVM>().ReverseMap();
        }
    }
}
