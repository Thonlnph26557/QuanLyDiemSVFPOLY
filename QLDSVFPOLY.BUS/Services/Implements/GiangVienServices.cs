using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSVFPOLY.BUS.Services.Interfaces;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class GiangVienServices : IGiangVienServices
    {
        IGiangVienRepository _iGiangVienRepositories;

        List<GiangVien> _listGiangViens;

        public GiangVienServices()
        {
            _iGiangVienRepositories = new GiangVienRepository();
        }

        public Task<bool> CreateAsync(GiangVienCreateVM createVm)
        {
            throw new NotImplementedException();
        }

        public Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienSearchVM searchVm)
        {
            throw new NotImplementedException();
        }

        public Task<List<GiangVienVM>> GetAllAsync(GiangVienSearchVM searchVm)
        {
            throw new NotImplementedException();
        }

        public Task<GiangVienVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM updateVm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrangThaiAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
