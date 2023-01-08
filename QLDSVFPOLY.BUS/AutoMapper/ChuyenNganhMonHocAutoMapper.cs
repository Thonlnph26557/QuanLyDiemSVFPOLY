using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class ChuyenNganhMonHocAutoMapper : Profile
    {
        public ChuyenNganhMonHocAutoMapper()
        {
            CreateMap<ChuyenNganhMonHoc, ChuyenNganhMonHocVM>().ReverseMap();
        }
    }
}
