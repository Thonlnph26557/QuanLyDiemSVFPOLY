using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
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
    public class KiHocServices : IKiHocServices
    {
        //
        IKiHocRepositories _iKiHocRepositories;

        List<KiHoc> _listKiHocs;


        //
        public KiHocServices()
        {
            _iKiHocRepositories = new KiHocRepositories();
        }

        public Task<bool> CreateAsync(KiHocCreateViewmodel obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<KiHocViewmodel>> GetAllActiveAsync(KiHocSearchViewmodel obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<KiHocViewmodel>> GetAllAsync(KiHocSearchViewmodel obj)
        {
            throw new NotImplementedException();
        }

        public Task<KiHocViewmodel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, KiHocUpdateViewmodel obj)
        {
            throw new NotImplementedException();
        }
    }
}
