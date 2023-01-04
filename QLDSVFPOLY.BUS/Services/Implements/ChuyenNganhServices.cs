using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class ChuyenNganhServices : IChuyenNganhServices
    {
        IChuyenNganhRepository _repos;

        List<ChuyenNganh> _listChuyenNganh;

        public ChuyenNganhServices()
        {
            _repos = new ChuyenNganhRepository();
        }

        public Task<bool> CreateAsync(ChuyenNganhCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhVM>> GetAllAsync(ChuyenNganhSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<ChuyenNganhVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhVM>> GetChuyenNganhHepById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrangThaiAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
