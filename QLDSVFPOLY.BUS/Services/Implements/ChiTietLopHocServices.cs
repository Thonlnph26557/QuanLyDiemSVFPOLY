using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;
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
        IMapper _mapper;
        IChiTietLopHocRepository _repo;
        List<ChiTietLopHoc> _listObj;

        public ChiTietLopHocServices(IMapper mapper)
        {
            _repo = new ChiTietLopHocRepository();
            _mapper = mapper;
        }

        private async Task GetListAsync()
        {
            _listObj = await _repo.GetAllAsync();
        }

        public async Task<List<ChiTietLopHocVM>> GetAllAsync()
        {
            await GetListAsync();
            List<ChiTietLopHocVM> listVM = _listObj.AsQueryable().ProjectTo<ChiTietLopHocVM>(_mapper.ConfigurationProvider).ToList();
            return listVM;
        }

        public async Task<List<ChiTietLopHocVM>> GetAllActiveAsync()
        {
            await GetListAsync();
            List<ChiTietLopHocVM> listVM = _listObj.AsQueryable().ProjectTo<ChiTietLopHocVM>(_mapper.ConfigurationProvider).Where(c => c.TrangThai != 0).ToList();
            return listVM;
        }

        public async Task<ChiTietLopHocVM> GetByIdAsync(Guid id)
        {
            await GetListAsync();
            var obj = _listObj.FirstOrDefault(c => c.Id == id);
            var objVM = _mapper.Map<ChiTietLopHocVM>(obj);
            return objVM;
        }

        public async Task<bool> CreateAsync(ChiTietLopHocCreateVM obj)
        {
            var temp = new ChiTietLopHoc()
            {
               Id = Guid.NewGuid(),
               IdDaoTao = obj.IdDaoTao,
               IdMonHoc = obj.IdMonHoc,
               IdGiangVien = obj.IdGiangVien,
               IdKiHoc = obj.IdKiHoc,
               Ten = obj.Ten,
               SoLuongSinhVien = obj.SoLuongSinhVien,
               NgayTao = DateTime.Now,
               TrangThai = obj.TrangThai
            };

            await _repo.CreateAsync(temp);
            await _repo.SaveChangesAsync();

            await GetListAsync();
            if (_listObj.Any(c => c.Id == temp.Id)) return true;
            return false;

        }

        public async Task<bool> UpdateAsync(Guid id, ChiTietLopHocUpdateVM obj)
        {
            await GetListAsync();
            if (!_listObj.Any(c => c.Id == id)) return false;

            var temp = _listObj.FirstOrDefault(c => c.Id == id);

            temp.IdMonHoc = obj.IdMonHoc;
            temp.IdGiangVien = obj.IdGiangVien;
            temp.IdKiHoc = obj.IdKiHoc;
            temp.Ten = obj.Ten;
            temp.SoLuongSinhVien = obj.SoLuongSinhVien;
            temp.TrangThai = obj.TrangThai;

            await _repo.UpdateAsync(temp);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await GetListAsync();
            if (!_listObj.Any(c => c.Id == id)) return false;

            await _repo.RemoveAsync(id);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveByUpdateAsync(Guid id)
        {
            await GetListAsync();
            if (!_listObj.Any(c => c.Id == id)) return false;

            var temp = _listObj.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

            await _repo.UpdateAsync(temp);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
