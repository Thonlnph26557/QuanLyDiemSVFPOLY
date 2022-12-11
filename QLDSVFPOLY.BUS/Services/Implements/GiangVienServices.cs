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

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class GiangVienServices : IGiangVienServices
    {
        IGiangVienRepository _iGiangVienRepositories;

        List<GiangVien> _listGiangViens;

        public GiangVienServices()
        {
            _iGiangVienRepositories = new GiangVienRepository();
        }

        //
        private async Task GetListAsync()
        {
            _listGiangViens = await _iGiangVienRepositories.GetAllAsync();
        }
        //
        public async Task<List<GiangVienVM>> GetAllAsync(GiangVienSearchVM searchVm)
        {
            await GetListAsync();

            List<GiangVienVM> listGiangVienViewmodel = new List<GiangVienVM>();
            listGiangVienViewmodel = _listGiangViens.Select(c => new GiangVienVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                IdDaoTao = c.IdDaoTao,
                Ho = c.Ho,
                TenDem = c.TenDem,
                Ten = c.Ten,
                GioiTinh = c.GioiTinh,
                NgaySinh = c.NgaySinh,
                DiaChi = c.DiaChi,
                SoDienThoai = c.SoDienThoai,
                Email = c.Email,
                TenDangNhap = c.TenDangNhap,
                MatKhau = c.MatKhau,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();

            if (searchVm.Ma != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.Ma.Contains(searchVm.Ma)).ToList();
            }
            if (searchVm.Ho != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.Ho.Contains(searchVm.Ho)).ToList();
            }
            if (searchVm.Ten != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.Ten.Contains(searchVm.Ten)).ToList();
            }
            if (searchVm.TenDem != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.TenDem.Contains(searchVm.TenDem)).ToList();
            }
            if (searchVm.Email != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.Email.Contains(searchVm.Email)).ToList();
            }

            return listGiangVienViewmodel;
        }

        //Active = (TrangThai != 0)
        public async Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienSearchVM searchVm)
        {
            await GetListAsync();

            List<GiangVienVM> listGiangVienViewmodel = new List<GiangVienVM>();
            listGiangVienViewmodel = _listGiangViens.Where(c => c.TrangThai != 0).Select(c => new GiangVienVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                IdDaoTao = c.IdDaoTao,
                Ho = c.Ho,
                TenDem = c.TenDem,
                Ten = c.Ten,
                GioiTinh = c.GioiTinh,
                NgaySinh = c.NgaySinh,
                DiaChi = c.DiaChi,
                SoDienThoai = c.SoDienThoai,
                Email = c.Email,
                TenDangNhap = c.TenDangNhap,
                MatKhau = c.MatKhau,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();

            if (searchVm.Ma != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.Ma.Contains(searchVm.Ma)).ToList();
            }
            if (searchVm.Ho != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.Ho.Contains(searchVm.Ho)).ToList();
            }
            if (searchVm.Ten != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.Ten.Contains(searchVm.Ten)).ToList();
            }
            if (searchVm.TenDem != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.TenDem.Contains(searchVm.TenDem)).ToList();
            }
            if (searchVm.Email != null)
            {
                listGiangVienViewmodel = listGiangVienViewmodel.Where(c => c.Email.Contains(searchVm.Email)).ToList();
            }

            return listGiangVienViewmodel;
        }

        //
        public async Task<GiangVienVM> GetByIdAsync(Guid id)
        {
            await GetListAsync();

            GiangVien temp = _listGiangViens.FirstOrDefault(c => c.Id == id);

            GiangVienVM result = new GiangVienVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                IdDaoTao = temp.IdDaoTao,
                Ho = temp.Ho,
                TenDem = temp.TenDem,
                Ten = temp.Ten,
                GioiTinh = temp.GioiTinh,
                NgaySinh = temp.NgaySinh,
                DiaChi = temp.DiaChi,
                SoDienThoai = temp.SoDienThoai,
                Email = temp.Email,
                TenDangNhap = temp.TenDangNhap,
                MatKhau = temp.MatKhau,
                DuongDanAnh = temp.DuongDanAnh,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        //
        public async Task<bool> CreateAsync(GiangVienCreateVM createVm)
        {
            createVm.Id = Guid.NewGuid();

            var temp = new GiangVien()
            {
                Id = createVm.Id,
                Ma = createVm.Ma,
                IdDaoTao = createVm.IdDaoTao,
                Ho = createVm.Ho,
                TenDem = createVm.TenDem,
                Ten = createVm.Ten,
                GioiTinh = createVm.GioiTinh,
                NgaySinh = createVm.NgaySinh,
                DiaChi = createVm.DiaChi,
                SoDienThoai = createVm.SoDienThoai,
                Email = createVm.Email,
                TenDangNhap = createVm.TenDangNhap,
                MatKhau = createVm.MatKhau,
                DuongDanAnh = createVm.DuongDanAnh,
                NgayTao = createVm.NgayTao,
                TrangThai = createVm.TrangThai
            };

            await _iGiangVienRepositories.CreateAsync(temp);
            await _iGiangVienRepositories.SaveChangesAsync();

            var _listGiangViens = await _iGiangVienRepositories.GetAllAsync();
            if (_listGiangViens.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM updateVm)
        {
            var _listGiangViens = await _iGiangVienRepositories.GetAllAsync();
            if (!_listGiangViens.Any(c => c.Id == id)) return false;

            var temp = _listGiangViens.FirstOrDefault(c => c.Id == id);

            temp.Ma = updateVm.Ma;
            temp.IdDaoTao = updateVm.IdDaoTao;
            temp.GioiTinh = updateVm.GioiTinh;
            temp.NgaySinh = updateVm.NgaySinh;
            temp.DiaChi = updateVm.DiaChi;
            temp.SoDienThoai = updateVm.SoDienThoai;
            //temp.MatKhau = updateVm.MatKhau;
            temp.DuongDanAnh = updateVm.DuongDanAnh;
            temp.NgayTao = updateVm.NgayTao;
            temp.TrangThai = updateVm.TrangThai;

            await _iGiangVienRepositories.UpdateAsync(temp);
            await _iGiangVienRepositories.SaveChangesAsync();
            return true;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listGiangViens = await _iGiangVienRepositories.GetAllAsync();

            if (!_listGiangViens.Any(c => c.Id == id)) return false;

            await _iGiangVienRepositories.RemoveAsync(id);
            await _iGiangVienRepositories.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateTrangThaiAsync(Guid id)
        {
            var _listGiangViens = await _iGiangVienRepositories.GetAllAsync();
            if (!_listGiangViens.Any(c => c.Id == id)) return false;

            var temp = _listGiangViens.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

            await _iGiangVienRepositories.UpdateAsync(temp);
            await _iGiangVienRepositories.SaveChangesAsync();
            return true;
        }
    }
}
