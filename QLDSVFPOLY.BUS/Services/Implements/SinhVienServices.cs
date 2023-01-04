using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
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
    public class SinhVienServices : ISinhVienServices
    {
        //
        ISinhVienRepository _repos;
        List<SinhVien> _listSinhViens;

        //
        public SinhVienServices()
        {
            _repos = new SinhVienRepository();
        }

        public Task<bool> CreateAsync(SinhVienCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<SinhVienVM>> GetAllActiveAsync(SinhVienSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<SinhVienVM>> GetAllAsync(SinhVienSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<SinhVienVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, SinhVienUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
