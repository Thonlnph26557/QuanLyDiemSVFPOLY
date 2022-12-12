using QLDSVFPOLY.BUS.Services.Interfaces;
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
    public class LopHocServices : ILopHocServices
    {
        ILopHocRepository _iLopHocRepositories;

        List<LopHoc> _listLopHocs;

        //
        public LopHocServices()
        {
            _iLopHocRepositories = new LopHocRepository();
        }
        //
        private async Task GetListLopHocAsync()
        {
            _listLopHocs = await _iLopHocRepositories.GetAllAsync();
        }
        //
        public async Task<List<LopHocVM>> GetAllAsync(LopHocSearchVM searchVm)
        {
            await GetListLopHocAsync();

            List<LopHocVM> listLopHocViewmodel = _listLopHocs.Select(c => new LopHocVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                IdDaoTao = c.IdDaoTao,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();


            return listLopHocViewmodel;
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<LopHocVM>> GetAllActiveAsync(LopHocSearchVM searchVm)
        {
            await GetListLopHocAsync();

            List<LopHocVM> listLopHocViewmodel = _listLopHocs.Where(c => c.TrangThai != 0).Select(c => new LopHocVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                IdDaoTao = c.IdDaoTao,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();


            return listLopHocViewmodel;
        }

        //
        public async Task<LopHocVM> GetByIdAsync(Guid id)
        {
            await GetListLopHocAsync();

            LopHoc temp = _listLopHocs.FirstOrDefault(c => c.Id == id);

            LopHocVM result = new LopHocVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                IdDaoTao = temp.IdDaoTao,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        //
        public async Task<bool> CreateAsync(LopHocCreateVM createVm)
        {
            var temp = new LopHoc()
            {
                Id = Guid.NewGuid(),
                Ma = createVm.Ma,
                IdDaoTao = createVm.IdDaoTao,
                TrangThai = createVm.TrangThai,
                NgayTao = DateTime.Now
            };

            await _iLopHocRepositories.CreateAsync(temp);
            await _iLopHocRepositories.SaveChangesAsync();

            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();
            if (_listLopHocs.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, LopHocUpdateVM updateVm)
        {
            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();
            if (!_listLopHocs.Any(c => c.Id == id)) return false;

            var temp = _listLopHocs.FirstOrDefault(c => c.Id == id);
            temp.Ma = updateVm.Ma;
            temp.TrangThai = updateVm.TrangThai;

            await _iLopHocRepositories.UpdateAsync(temp);
            await _iLopHocRepositories.SaveChangesAsync();

            return true;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();

            if (!_listLopHocs.Any(c => c.Id == id)) return false;

            await _iLopHocRepositories.RemoveAsync(id);
            await _iLopHocRepositories.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateTrangThaiAsync(Guid id, LopHocUpdateVM obj)
        {
            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();
            if (!_listLopHocs.Any(c => c.Id == id)) return false;

            var temp = _listLopHocs.FirstOrDefault(c => c.Id == id);
            temp.TrangThai = obj.TrangThai;

            await _iLopHocRepositories.UpdateAsync(temp);
            await _iLopHocRepositories.SaveChangesAsync();
            return true;
        }
    }
}
