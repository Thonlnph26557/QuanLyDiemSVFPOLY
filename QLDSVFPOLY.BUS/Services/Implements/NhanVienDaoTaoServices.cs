using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class NhanVienDaoTaoServices : INhanVienDaoTaoServices
    {
        //
        INhanVienDaoTaoRepository _repos;
        List<NhanVienDaoTao> _list;

        //
        public NhanVienDaoTaoServices()
        {
            _repos = new NhanVienDaoTaoRepository();
        }

        public Task<bool> CreateAsync(NhanVienDaoTaoCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<NhanVienDaoTaoVM>> GetAllAsync(NhanVienDaoTaoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
    
