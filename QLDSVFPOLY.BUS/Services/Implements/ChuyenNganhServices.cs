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
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class ChuyenNganhServices : IChuyenNganhServices
    {
        IChuyenNganhRepository _repos;

        List<ChuyenNganh> _listChuyenNganh;
        private readonly IMapper _mapper;


        public ChuyenNganhServices(IMapper mapper)
        {
            _repos = new ChuyenNganhRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<bool> CreateAsync(ChuyenNganhCreateVM obj)
        {
            var temp = new ChuyenNganh()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                TenNganhHoc = obj.TenNganhHoc,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = DateTime.Now,
                IdChuyenNganh = obj.IdChuyenNganh,
                TrangThai = obj.TrangThai,
                IdDaoTao = obj.IdDaoTao,
            };

            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();
            var listChuyenNganh = await _repos.GetAllAsync();
            if (listChuyenNganh.Any(c => temp.Id == c.Id)) return true;
            return false;
        }

        public async Task<List<ChuyenNganhVM>> GetAllActiveAsync()
        {
            try
            {
                await GetListChuyenNganhAsync();

                List<ChuyenNganhVM> listObjectVM = _listChuyenNganh.AsQueryable().ProjectTo<ChuyenNganhVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

                return listObjectVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ChuyenNganhVM>> GetAllAsync()
        {
            try
            {
                await GetListChuyenNganhAsync();

                List<ChuyenNganhVM> listObjectVM = _listChuyenNganh.AsQueryable().ProjectTo<ChuyenNganhVM>(_mapper.ConfigurationProvider).ToList();

                return listObjectVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ChuyenNganhVM> GetByIdAsync(Guid id)
        {
            try
            {
                var obj = _listChuyenNganh.FirstOrDefault(c => c.Id == id);
                var objVM = _mapper.Map<ChuyenNganhVM>(obj);
                return objVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ChuyenNganhVM>> GetChuyenNganhHepById(Guid id)
        {
            try
            {
                await GetListChuyenNganhAsync();

                List<ChuyenNganhVM> listObjectVM = _listChuyenNganh.AsQueryable().ProjectTo<ChuyenNganhVM>(_mapper.ConfigurationProvider).Where(c => c.IdChuyenNganh == id).ToList();

                return listObjectVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var listChuyenNganh = await _repos.GetAllAsync();
            if (!listChuyenNganh.Any(c => c.Id == id)) return false;
            await _repos.RemoveAsync(id);
            await _repos.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM obj)
        {
            var listChuyenNganh = await _repos.GetAllAsync();
            if (!listChuyenNganh.Any(c => c.Id == id)) return false;

            var temp = listChuyenNganh.FirstOrDefault(c => c.Id == id);

            temp.Ma = obj.Ma;
            temp.TenNganhHoc = obj.TenNganhHoc;
            temp.DuongDanAnh = obj.DuongDanAnh;
            temp.TrangThai = obj.TrangThai;
            temp.IdChuyenNganh = obj.IdChuyenNganh;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTrangThaiAsync(Guid id)
        {

            var listChuyenNganh = await _repos.GetAllAsync();
            if (!listChuyenNganh.Any(c => c.Id == id)) return false;

            var temp = listChuyenNganh.FirstOrDefault(c => c.Id == id);


            temp.TrangThai = 0;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();
            return true;
        }

        private async Task GetListChuyenNganhAsync()
        {
            _listChuyenNganh = await _repos.GetAllAsync();
        }

    }
}
