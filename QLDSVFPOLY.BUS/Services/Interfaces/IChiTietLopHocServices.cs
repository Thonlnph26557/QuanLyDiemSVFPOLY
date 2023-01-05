using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IChiTietLopHocServices
    {

        Task<List<ChiTietLopHocVM>> GetAllAsync(ChiTietLopHocSearchVM obj);
        Task<List<ChiTietLopHocVM>> GetAllActiveAsync(ChiTietLopHocSearchVM obj);
        Task<ChiTietLopHocVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(ChiTietLopHocCreateVM obj);
        Task<bool> UpdateAsync(Guid id, ChiTietLopHocUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
