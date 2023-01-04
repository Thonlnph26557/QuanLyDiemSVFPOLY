using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;
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
    public class ChuyenNganhMonHocServices : IChuyenNganhMonHocServices
    {
        IChuyenNganhMonHocRepository _iChuyenNganhMonHocRepository;

        List<ChuyenNganhMonHoc> _listChuyenNganhMonHoc;

        public ChuyenNganhMonHocServices()
        {
            _iChuyenNganhMonHocRepository = new ChuyenNganhMonHocRepository();
        }

        public Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj, Guid idChuyenNganh, Guid idMonHoc)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhMonHocVM>> GetAllAsync(ChuyenNganhMonHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrangThaiAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            throw new NotImplementedException();
        }
    }
}
