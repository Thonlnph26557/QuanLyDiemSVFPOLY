using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class DaoTaoAutoMapper : Profile
    {
        public DaoTaoAutoMapper()
        {
            CreateMap<DaoTaoVM, DaoTao>().ReverseMap();
        }
    }
}
