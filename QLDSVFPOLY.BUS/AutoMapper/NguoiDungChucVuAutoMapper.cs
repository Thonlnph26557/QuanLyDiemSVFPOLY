using AutoMapper;
using QLDSVFPOLY.BUS.ViewModels.NguoiDungChucVu;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.AutoMapper
{
    public class NguoiDungChucVuAutoMapper:Profile
    {
        public NguoiDungChucVuAutoMapper()
        {
            CreateMap<NguoiDungChucVuVM, NguoiDungChucVu>().ReverseMap();
        }
    }
}
