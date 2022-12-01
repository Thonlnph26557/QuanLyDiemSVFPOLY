using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IDiemSoServices
    {
        //bool Create(DiemSoCreateViewModel obj);
        //bool Update(DiemSoUpdateViewModel obj);
        //bool Delete(Guid id);
        //List<DiemSoViewModel> GetAll(DiemSoSearchViewModel dsSearch);
        //List<DiemSoViewModel> GetAllActive();
        //DiemSoViewModel GetById(Guid id);

        Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM obj);
        Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM obj);
        Task<DiemSoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(DiemSoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
