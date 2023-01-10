using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class DiemSoProfile : Profile
    {
        public DiemSoProfile()
        {
            CreateMap<DiemSo, DiemSoVM>().ReverseMap();
            //CreateMap<DiemSo, DiemSoCreateVM>().ReverseMap();
            //CreateMap<DiemSo, DiemSoUpdateVM>().ReverseMap();
            //CreateMap<DiemSo, DiemSoSearchVM>().ReverseMap();
        }
    }
}
