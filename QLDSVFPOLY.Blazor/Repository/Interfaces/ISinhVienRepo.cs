﻿//using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface ISinhVienRepo
    {
        Task<List<SinhVienVM>> GetAllAsync();
        Task<List<SinhVienVM>> GetAllActiveAsync();
        Task<SinhVienVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(SinhVienCreateVM obj);
        Task<bool> UpdateAsync(Guid id, SinhVienUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
