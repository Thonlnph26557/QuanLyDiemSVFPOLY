using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class MonHocServices : IMonHocServices
    {
        //
        IMonHocRepository _repos;
        List<MonHoc> _listMonHocs;

        //
        public MonHocServices()
        {
            _repos = new MonHocRepository();
        }

        public Task<bool> CreateAsync(MonHocCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<MonHocVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, MonHocUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
