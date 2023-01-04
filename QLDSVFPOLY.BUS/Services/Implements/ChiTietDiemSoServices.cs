using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class ChiTietDiemSoServices : IChiTietDiemSoServices
    {
        IChiTietDiemSoRepository _iChiTietDiemSoRepository;

        List<ChiTietDiemSo> _listCTDiemSo;


        public ChiTietDiemSoServices()
        {
            _iChiTietDiemSoRepository = new ChiTietDiemSoRepository();
        }

        public Task<bool> CreateAsync(ChiTietDiemSoCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<ChiTietDiemSoVM> GetByIdAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien, ChiTietDiemSoUpdateVM obj)
        {
            throw new NotImplementedException();
        }
    }
}
