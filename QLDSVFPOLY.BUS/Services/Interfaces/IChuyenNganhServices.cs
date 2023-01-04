using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IChuyenNganhServices
    {
        Task<List<ChuyenNganhVM>> GetAllAsync(ChuyenNganhSearchVM obj);
        Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM obj);
        Task<ChuyenNganhVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ChuyenNganhCreateVM obj);
        Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateTrangThaiAsync(Guid id);
        Task<List<ChuyenNganhVM>> GetChuyenNganhHepById(Guid id);
    }
}
