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
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class DaoTaoServices : IDaoTaoServices
    {
        //
        IDaoTaoRepository _repos;
        private readonly IMapper _mapper;

        List<DaoTao> _listDaoTaos;

        //
        public DaoTaoServices(IMapper mapper)
        {
            _repos = new DaoTaoRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateAsync(DaoTaoCreateVM obj)
        {
            var temp = new DaoTao()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                SoDienThoai = obj.SoDienThoai,
                Email = obj.Email,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai
            };

            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();

            var listDaoTao = await _repos.GetAllAsync();

            if (listDaoTao.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        public async Task<List<DaoTaoVM>> GetAllActiveAsync()
        {
            await GetListDaoTaoAsync();
            try
            {
                List<DaoTaoVM> listObjectVM = _listDaoTaos.AsQueryable().ProjectTo<DaoTaoVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

                return listObjectVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<DaoTaoVM>> GetAllAsync()
        {
            await GetListDaoTaoAsync();

            try
            {
                List<DaoTaoVM> listObjectVM = _listDaoTaos.AsQueryable().ProjectTo<DaoTaoVM>(_mapper.ConfigurationProvider).ToList();

                return listObjectVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<DaoTaoVM> GetByIdAsync(Guid id)
        {
            await GetListDaoTaoAsync();

            try
            {
                var obj = _listDaoTaos.FirstOrDefault(c => c.Id == id);
                var objVM = _mapper.Map<DaoTaoVM>(obj);
                return objVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var listDaoTao = await _repos.GetAllAsync();

            if (!listDaoTao.Any(c => c.Id == id)) return false;

            await _repos.RemoveAsync(id);
            await _repos.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj)
        {
            var listDaoTao = await _repos.GetAllAsync();

            if (!listDaoTao.Any(c => c.Id == id)) return false;

            var temp = listDaoTao.FirstOrDefault(c => c.Id == id);

            temp.Ma = obj.Ma;
            temp.DiaChi = obj.DiaChi;
            temp.SoDienThoai = obj.SoDienThoai;
            temp.Email = obj.Email;
            temp.TrangThai = obj.TrangThai;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateRemoveAsync(Guid id)
        {
            var listDaoTao = await _repos.GetAllAsync();

            if (!listDaoTao.Any(c => c.Id == id)) return false;

            var temp = listDaoTao.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();

            return true;
        }

        private async Task GetListDaoTaoAsync()
        {
            _listDaoTaos = await _repos.GetAllAsync();
        }
    }
}
