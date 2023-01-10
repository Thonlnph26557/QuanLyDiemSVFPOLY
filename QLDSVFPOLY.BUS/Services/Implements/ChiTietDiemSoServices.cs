using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using Microsoft.EntityFrameworkCore;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class ChiTietDiemSoServices : IChiTietDiemSoServices
    {
        IMapper _mapper;
        IChiTietDiemSoRepository _repo;
        List<ChiTietDiemSo> _listObj;

        public ChiTietDiemSoServices(IMapper mapper)
        {
            _repo = new ChiTietDiemSoRepository();
            _mapper = mapper;
        }

        private async Task GetListAsync()
        {
            _listObj = await _repo.GetAllAsync();
        }

        public async Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM obj)
        {
            await GetListAsync();
            List<ChiTietDiemSoVM> listVM = _listObj.AsQueryable().ProjectTo<ChiTietDiemSoVM>(_mapper.ConfigurationProvider).ToList();
            return listVM;
        }

        public async Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM obj)
        {
            await GetListAsync();
            List<ChiTietDiemSoVM> listVM = _listObj.AsQueryable().ProjectTo<ChiTietDiemSoVM>(_mapper.ConfigurationProvider).Where(c => c.TrangThai != 0).ToList();
            return listVM;
        }

        public async Task<ChiTietDiemSoVM> GetByIdAsync(Guid idCTLH, Guid idSinhVien, Guid idDiemSo)
        {
            await GetListAsync();
            var obj = _listObj.FirstOrDefault(c => c.IdDiemSo == idDiemSo && c.IdSinhVien == idSinhVien && c.IdDiemSo == idDiemSo);
            var objVM = _mapper.Map<ChiTietDiemSoVM>(obj);
            return objVM;
        }

        public async Task<bool> CreateAsync(ChiTietDiemSoCreateVM obj)
        {
            var temp = new ChiTietDiemSo()
            {
                IdChiTietLopHoc = obj.IdChiTietLopHoc,
                IdSinhVien = obj.IdSinhVien,
                IdDiemSo = obj.IdDiemSo,
                Diem = obj.Diem,
                TrongSo = obj.TrongSo,
                DiemToiThieu = obj.DiemToiThieu,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai
            };

            await _repo.CreateAsync(temp);
            await _repo.SaveChangesAsync();

            await GetListAsync();
            if (_listObj.Any(c => c.IdChiTietLopHoc == temp.IdChiTietLopHoc && c.IdSinhVien == temp.IdSinhVien && c.IdDiemSo == temp.IdDiemSo)) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid idCTLH, Guid idSinhVien, Guid idDiemSo, ChiTietDiemSoUpdateVM obj)
        {
            await GetListAsync();
            if (!_listObj.Any(c => c.IdChiTietLopHoc == idCTLH && c.IdSinhVien == idSinhVien && c.IdDiemSo == idDiemSo)) return false;

            var temp = _listObj.FirstOrDefault(c => c.IdChiTietLopHoc == idCTLH && c.IdSinhVien == idSinhVien && c.IdDiemSo == idDiemSo);

            temp.Diem = obj.Diem;
            temp.TrongSo = obj.TrongSo;
            temp.DiemToiThieu = obj.DiemToiThieu;
            temp.TrangThai = obj.TrangThai;

            await _repo.UpdateAsync(temp);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveAsync(Guid idCTLH, Guid idSinhVien, Guid idDiemSo)
        {
            await GetListAsync();
            if (!_listObj.Any(c => c.IdChiTietLopHoc == idCTLH && c.IdSinhVien == idSinhVien && c.IdDiemSo == idDiemSo)) return false;

            await _repo.RemoveAsync(idDiemSo, idCTLH, idSinhVien);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveByUpdateAsync(Guid idCTLH, Guid idSinhVien, Guid idDiemSo)
        {
            await GetListAsync();
            if (!_listObj.Any(c => c.IdChiTietLopHoc == idCTLH && c.IdSinhVien == idSinhVien && c.IdDiemSo == idDiemSo)) return false;

            var temp = _listObj.FirstOrDefault(c => c.IdChiTietLopHoc == idCTLH && c.IdSinhVien == idSinhVien && c.IdDiemSo == idDiemSo);

            temp.TrangThai = 0;

            await _repo.UpdateAsync(temp);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
