﻿using QLDSVFPOLY.BUS.ViewModels.NguoiDungChucVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface INguoiDungChucVuServices
    {
        Task<List<NguoiDungChucVuVM>> GetAllAsync();
        Task<List<NguoiDungChucVuVM>> GetAllActiveAsync();
        Task<NguoiDungChucVuVM> GetByIdAsync(Guid idNguoiDung, Guid idChucVu);
        Task<bool> CreateAsync(NguoiDungChucVuCreateVM obj,Guid idNguoiDung, Guid idChucVu);
        Task<bool> UpdateAsync(Guid idNguoiDung, Guid idChucVu, NguoiDungChucVuUpdateVM obj);
        Task<bool> DeleteAsync(Guid idNguoiDung, Guid idChucVu);
    }
}
