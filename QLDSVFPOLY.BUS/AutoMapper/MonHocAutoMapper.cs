using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class MonHocAutoMapper : Profile // kế thừa Profile của AutoMapper khi tạo mới
    {
        public MonHocAutoMapper() // tạo Constructor cho Class và Create map tại đây 
        {
            // map từ MonHoc => MonHocVM
            CreateMap<MonHoc, MonHocVM>().ReverseMap();
            // ReverseMap() dùng để map ngược lại từ MonHocVM => MonHoc
        }
    }
}
