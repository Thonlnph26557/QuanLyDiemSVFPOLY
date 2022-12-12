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

        public async Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj, Guid idChuyenNganh, Guid idMonHoc)
        {
            obj.IdChuyenNganh = idChuyenNganh;
            obj.IdMonHoc = idMonHoc;

            var temp = new ChuyenNganhMonHoc()
            {
                IdChuyenNganh = obj.IdChuyenNganh,
                IdMonHoc = obj.IdMonHoc,
                NgayTao = obj.NgayTao,
                TrangThai = obj.TrangThai,
            };
            await _iChuyenNganhMonHocRepository.CreateAsync(temp);
            await _iChuyenNganhMonHocRepository.SaveChangesAsync();

            var listChuyenNganhMH = await _iChuyenNganhMonHocRepository.GetAllAsync();

            if (listChuyenNganhMH.Any(c => temp.IdChuyenNganh == c.IdChuyenNganh
            && temp.IdMonHoc == c.IdMonHoc)) return true;
            return false;
        }

        public async Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM obj)
        {
            await GetListChuyenNganhMonHocAsync();

            List<ChuyenNganhMonHocVM> listChuyenNganhMonHocVM = _listChuyenNganhMonHoc.Where(c => c.TrangThai != 0).Select(c => new ChuyenNganhMonHocVM()
            {
                IdChuyenNganh = c.IdChuyenNganh,
                IdMonHoc = c.IdMonHoc,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
            }).ToList();


            return listChuyenNganhMonHocVM;
        }

        private async Task GetListChuyenNganhMonHocAsync()
        {
            _listChuyenNganhMonHoc = await _iChuyenNganhMonHocRepository.GetAllAsync();
        }


        public async Task<List<ChuyenNganhMonHocVM>> GetAllAsync(ChuyenNganhMonHocSearchVM obj)
        {
            await GetListChuyenNganhMonHocAsync();

            List<ChuyenNganhMonHocVM> listChuyenNganhMonHocVM = _listChuyenNganhMonHoc.Select(c => new ChuyenNganhMonHocVM()
            {
                IdChuyenNganh = c.IdChuyenNganh,
                IdMonHoc = c.IdMonHoc,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
            }).ToList();


            return listChuyenNganhMonHocVM;
        }

        public async Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            await GetListChuyenNganhMonHocAsync();

            ChuyenNganhMonHoc temp = _listChuyenNganhMonHoc.FirstOrDefault(c => c.IdChuyenNganh == idChuyenNganh
            && c.IdMonHoc == idMonHoc);

            ChuyenNganhMonHocVM result = new ChuyenNganhMonHocVM()
            {
                IdChuyenNganh = idChuyenNganh,
                IdMonHoc = idMonHoc,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        public async Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var listChuyenNganhMH = await _iChuyenNganhMonHocRepository.GetAllAsync();

            if (!listChuyenNganhMH.Any(c => c.IdChuyenNganh == idChuyenNganh
            && c.IdMonHoc == idMonHoc)) return false;

            await _iChuyenNganhMonHocRepository.DeleteAsync(idChuyenNganh, idMonHoc);
            await _iChuyenNganhMonHocRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTrangThaiAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var listChuyenNganhMH = await _iChuyenNganhMonHocRepository.GetAllAsync();
            if (!listChuyenNganhMH.Any(c => c.IdChuyenNganh == idChuyenNganh && c.IdMonHoc == idMonHoc)) return false;

            var temp = listChuyenNganhMH.FirstOrDefault(c => c.IdChuyenNganh == idChuyenNganh && c.IdMonHoc == idMonHoc);

            temp.TrangThai = 0;

            await _iChuyenNganhMonHocRepository.UpdateAsync(temp);
            await _iChuyenNganhMonHocRepository.SaveChangesAsync();
            return true;
        }
    }
}
