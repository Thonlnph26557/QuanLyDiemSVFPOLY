using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class ChiTietDiemSoProfile : Profile   
    {
        public ChiTietDiemSoProfile()
        {
            CreateMap<ChiTietDiemSo, ChiTietDiemSoVM>().ReverseMap();
        }
    }
}
