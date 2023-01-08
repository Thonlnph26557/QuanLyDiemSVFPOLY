using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class KiHocAutoMapper : Profile
    {
        public KiHocAutoMapper()
        {
            CreateMap<KiHocVM, KiHoc>().ReverseMap();
        }
    }
}
