using QLDSVFPOLY.BUS.ViewModels.NguoiDung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface INguoiDungServices
    {
        Task<List<NguoiDungVM>> GetAllAsync();
        Task<List<NguoiDungVM>> GetAllActiveAsync();
        Task<NguoiDungVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(NguoiDungCreateVM obj);
        Task<bool> UpdateAsync(Guid id, NguoiDungUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
