using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
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
    public class ChiTietLopHocServices : IChiTietLopHocServices
    {
        //
        IChiTietLopHocRepositories _iChiTietLopHocRepositories;
        IGiangVienRepository _iGiangVienRepositories;
        IKiHocRepositories _iKiHocRepositories;
        ILopHocRepository _iLopHocRepositories;

        List<ChiTietLopHoc> _listChiTietLopHocs;


        //
        public ChiTietLopHocServices()
        {
            _iChiTietLopHocRepositories = new ChiTietLopHocRepositories();
            _iGiangVienRepositories = new GiangVienRepository();
            _iKiHocRepositories = new KiHocRepositories();
            _iLopHocRepositories = new LopHocRepository();
        }

        public Task<bool> CreateAsync(ChiTietLopHocCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietLopHocVM>> GetAllActiveAsync(ChiTietLopHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietLopHocVM>> GetAllAsync(ChiTietLopHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<ChiTietLopHocVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, ChiTietLopHocUpdateVM obj)
        {
            throw new NotImplementedException();
        }
    }
}
