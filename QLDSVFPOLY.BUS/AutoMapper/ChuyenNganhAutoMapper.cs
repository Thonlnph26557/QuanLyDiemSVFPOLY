using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class ChuyenNganhAutoMapper : Profile
    {
        public ChuyenNganhAutoMapper()
        {
            CreateMap<ChuyenNganhVM, ChuyenNganh>().ReverseMap();
        }
    }
}
