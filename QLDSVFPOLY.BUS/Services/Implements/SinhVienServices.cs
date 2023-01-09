using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
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

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class SinhVienServices : ISinhVienServices
    {
        //
        ISinhVienRepository _iSinhVienRepository;

        List<SinhVien> _listSinhViens;

        private readonly IMapper _mapper;
        //
        public SinhVienServices(IMapper mapper)
        {
            _iSinhVienRepository = new SinhVienRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private async Task GetListSinhVienAsync()
        {
            _listSinhViens = await _iSinhVienRepository.GetAllAsync();
        }

        public async Task<bool> CreateAsync(SinhVienCreateVM obj)
        {
            var temp = new SinhVien()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
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
                IdChuyenNganh = obj.IdChuyenNganh,
            };
            await _iSinhVienRepository.CreateAsync(temp);
            await _iSinhVienRepository.SaveChangesAsync();

            var listSinhViens = await _iSinhVienRepository.GetAllAsync();
            if (listSinhViens.Any(c => c.Id == temp.Id)) return true;
            return false;
        }

        public async Task<List<SinhVienVM>> GetAllActiveAsync()
        {
            await GetListSinhVienAsync();

            List<SinhVienVM> listObjectVM = _listSinhViens.AsQueryable().ProjectTo<SinhVienVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

            return listObjectVM;
        }

        public async Task<List<SinhVienVM>> GetAllAsync()
        {
            await GetListSinhVienAsync();

            List<SinhVienVM> listObjectVM = _listSinhViens.AsQueryable().ProjectTo<SinhVienVM>(_mapper.ConfigurationProvider).ToList();

            return listObjectVM;
        }

        public async Task<SinhVienVM> GetByIdAsync(Guid id)
        {
            try
            {
                await GetListSinhVienAsync();
                var obj = _listSinhViens.FirstOrDefault(c => c.Id == id);
                var objVM = _mapper.Map<SinhVienVM>(obj);
                return objVM;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listSinhViens = await _iSinhVienRepository.GetAllAsync();

            if (!_listSinhViens.Any(c => c.Id == id)) return false;

            var temp = _listSinhViens.FirstOrDefault(temp => temp.Id == id);
           
            temp.TrangThai = 0;
           
            await _iSinhVienRepository.UpdateAsync(temp);
            await _iSinhVienRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, SinhVienUpdateVM obj)
        {
            var _listSinhViens = await _iSinhVienRepository.GetAllAsync();

            if (!_listSinhViens.Any(c => c.Id == id)) return false;

            var temp = _listSinhViens.FirstOrDefault(temp => temp.Id == id);
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
            temp.IdChuyenNganh = obj.IdChuyenNganh;

            await _iSinhVienRepository.UpdateAsync(temp);
            await _iSinhVienRepository.SaveChangesAsync();
            return true;
        }
    }
}
