using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Net.WebSockets;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class DiemSoServices : IDiemSoServices
    {
        IMapper _mapper;
        IDiemSoRepository _repo;
        List<DiemSo> _listObj;

        public DiemSoServices(IMapper mapper)
        {
            _repo = new DiemSoRepository();
            _mapper = mapper;
        }

        private async Task GetListAsync()
        {
            _listObj = await _repo.GetAllAsync();
        }

        public async Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM obj)
        {
            await GetListAsync();
            List<DiemSoVM> listVM = _listObj.AsQueryable().ProjectTo<DiemSoVM>(_mapper.ConfigurationProvider).ToList();
            return listVM;
        }

        public async Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM obj)
        {
            await GetListAsync();
            List<DiemSoVM> listVM = _listObj.AsQueryable().ProjectTo<DiemSoVM>(_mapper.ConfigurationProvider).Where(c => c.TrangThai != 0).ToList();
            return listVM;
        }

        public async Task<DiemSoVM> GetByIdAsync(Guid id)
        {
            await GetListAsync();
            var obj = _listObj.FirstOrDefault(c => c.Id == id);
            var objVM = _mapper.Map<DiemSoVM>(obj);
            return objVM;
        }

        public async Task<bool> CreateAsync(DiemSoCreateVM obj)
        {
            var temp = new DiemSo()
            {
                Id = Guid.NewGuid(),
                IdMonHoc = obj.IdMonHoc,
                TrongSo = obj.TrongSo,
                DiemToiThieu = obj.DiemToiThieu,
                TenDauDiem = obj.TenDauDiem,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai,
            };

            await _repo.CreateAsync(temp);
            await _repo.SaveChangesAsync();

            await GetListAsync();
            if (_listObj.Any(c => c.Id == temp.Id)) return true;
            return false;

        }

        public async Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM obj)
        {
            await GetListAsync();
            if (!_listObj.Any(c => c.Id == id)) return false;

            var temp = _listObj.FirstOrDefault(c => c.Id == id);

            temp.TrongSo = obj.TrongSo;
            temp.DiemToiThieu = obj.DiemToiThieu;
            temp.TenDauDiem = obj.TenDauDiem;
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
