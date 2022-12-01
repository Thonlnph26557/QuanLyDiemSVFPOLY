using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IChiTietDiemSoServices
    {
        //bool Create(ChiTietDiemSoCreateViewModel obj);
        //bool Update(ChiTietDiemSoUpdateViewModel obj);
        //bool Delete(Guid idSinhVien, Guid idDiemSo, Guid idLopHoc);
        //List<ChiTietDiemSoViewModel> GetAll(ChiTietDiemSoSearchViewModel ctDiemSearch);
        //List<ChiTietDiemSoViewModel> GetAllActive();
        //ChiTietDiemSoViewModel GetById(Guid idSinhVien, Guid idDiemSo, Guid idLopHoc);

        Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM obj);
        Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM obj);
        Task<ChiTietDiemSoVM> GetByIdAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
        Task<bool> CreateAsync(ChiTietDiemSoCreateViewModel obj, Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
        Task<bool> UpdateAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien, ChiTietDiemSoUpdateVM obj);
        Task<bool> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
    }
}
