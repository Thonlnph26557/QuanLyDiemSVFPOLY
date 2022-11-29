using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IChiTietLopHocServices
    {

        Task<List<ChiTietLopHocViewmodel>> GetAllAsync(ChiTietLopHocSearchViewmodel obj);
        Task<List<ChiTietLopHocViewmodel>> GetAllActiveAsync(ChiTietLopHocSearchViewmodel obj);
        Task<ChiTietLopHocViewmodel> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(ChiTietLopHocCreateViewmodel obj);
        Task<bool> UpdateAsync(Guid id, ChiTietLopHocUpdateViewmodel obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
