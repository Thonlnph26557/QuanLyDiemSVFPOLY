using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.NguoiDung;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class NguoiDungAutoMapper: Profile
    {
        public NguoiDungAutoMapper()
        {
            CreateMap<NguoiDungVM, NguoiDung>().ReverseMap();
        }
    }
}
