using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using System.Net.WebSockets;
using System.ComponentModel;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class DaoTaoServices : IDaoTaoServices
    {
        //
        IDaoTaoRepository _repos;

        List<DaoTao> _listDaoTaos;

        //
        public DaoTaoServices()
        {
            _repos = new DaoTaoRepository();
        }

        public Task<bool> CreateAsync(DaoTaoCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<DaoTaoVM>> GetAllActiveAsync(DaoTaoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<DaoTaoVM>> GetAllAsync(DaoTaoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<DaoTaoVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
