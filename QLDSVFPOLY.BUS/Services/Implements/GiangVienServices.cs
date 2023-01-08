using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSVFPOLY.BUS.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class GiangVienServices : IGiangVienServices
    {
        IGiangVienRepository _iGiangVienRepository;

        List<GiangVien> _listGiangViens;
        private readonly IMapper _mapper;

        public GiangVienServices(IMapper mapper)
        {
            _iGiangVienRepository = new GiangVienRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        private async Task GetListGiangVienAsync()
        {
            _listGiangViens = await _iGiangVienRepository.GetAllAsync();
        }

        public async Task<bool> CreateAsync(GiangVienCreateVM obj)
        {
            var temp = new GiangVien()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                IdDaoTao = obj.IdDaoTao,
                Ho = obj.Ho,
                TenDem = obj.TenDem,
                Ten = obj.Ten,
                GioiTinh = obj.GioiTinh,
                NgaySinh = obj.NgaySinh,
                DiaChi = obj.DiaChi,
                SoDienThoai = obj.SoDienThoai,
                Email = obj.Email,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai,
            };
            await _iGiangVienRepository.CreateAsync(temp);
            await _iGiangVienRepository.SaveChangesAsync();

            var listGiangViens = await _iGiangVienRepository.GetAllAsync();
            if (listGiangViens.Any(c => c.Id == temp.Id)) return true;
            return false;
        }

        public async Task<List<GiangVienVM>> GetAllActiveAsync()
        {
            await GetListGiangVienAsync();

            List<GiangVienVM> listObjectVM = _listGiangViens.AsQueryable().ProjectTo<GiangVienVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

            return listObjectVM;
        }

        public async Task<List<GiangVienVM>> GetAllAsync()
        {
            await GetListGiangVienAsync();

            List<GiangVienVM> listObjectVM = _listGiangViens.AsQueryable().ProjectTo<GiangVienVM>(_mapper.ConfigurationProvider).ToList();

            return listObjectVM;
        }

        public async Task<GiangVienVM> GetByIdAsync(Guid id)
        {
            await GetListGiangVienAsync();
            GiangVien temp = _listGiangViens.FirstOrDefault(c => c.Id == id);

            GiangVienVM objVM = new GiangVienVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                Ho = temp.Ho,
                TenDem = temp.TenDem,
                Ten = temp.Ten,
                GioiTinh = temp.GioiTinh,
                NgaySinh = temp.NgaySinh,
                DiaChi = temp.DiaChi,
                SoDienThoai = temp.SoDienThoai,
                Email = temp.Email,
                DuongDanAnh = temp.DuongDanAnh,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };
            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listGiangViens = await _iGiangVienRepository.GetAllAsync();
            if (!_listGiangViens.Any(c => c.Id == id)) return false;
            await _iGiangVienRepository.RemoveAsync(id);
            await _iGiangVienRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM obj)
        {
            var _listGiangViens = await _iGiangVienRepository.GetAllAsync();

            if (!_listGiangViens.Any(c => c.Id == id)) return false;

            var temp = _listGiangViens.FirstOrDefault(temp => temp.Id == id);
            temp.Ma = obj.Ma;
            temp.Ho = obj.Ho;
            temp.TenDem = obj.TenDem;
            temp.Ten = obj.Ten;
            temp.GioiTinh = obj.GioiTinh;
            temp.NgaySinh = obj.NgaySinh;
            temp.DiaChi = obj.DiaChi;
            temp.SoDienThoai = obj.SoDienThoai;
            temp.Email = obj.Email;
            temp.DuongDanAnh = obj.DuongDanAnh;
            temp.NgayTao = obj.NgayTao;
            temp.TrangThai = obj.TrangThai;

            await _iGiangVienRepository.UpdateAsync(temp);
            await _iGiangVienRepository.SaveChangesAsync();
            return true;
        }
    }
}
