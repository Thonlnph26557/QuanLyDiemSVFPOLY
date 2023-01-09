using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.ChucVu;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class ChucVuAutoMapper : Profile
    {
        public ChucVuAutoMapper()
        {
            CreateMap<ChucVuVM, ChucVu>().ReverseMap();
        }
    }
}
