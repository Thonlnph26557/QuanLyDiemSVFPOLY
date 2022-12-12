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

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class SinhVienServices : ISinhVienServices
    {
        //
        ISinhVienRepository _repos;
        List<SinhVien> _listSinhViens;

        //
        public SinhVienServices()
        {
            _repos = new SinhVienRepository();
        }

        //
        private async Task GetListSinhVienAsync()
        {
            _listSinhViens = await _repos.GetAllAsync();
        }

        //
        public async Task<List<SinhVienVM>> GetAllAsync(SinhVienSearchVM obj)
        {
            await GetListSinhVienAsync();

            List<SinhVienVM> listSinhVienVM = new List<SinhVienVM>();

            listSinhVienVM = _listSinhViens.Select(c => new SinhVienVM()
            {
                Id = c.Id,
                Ma = c.Ma,
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
                TrangThai = c.TrangThai,
                IdChuyenNganh = c.IdChuyenNganh,
            }).ToList();



                return listSinhVienVM;
        }


        //
        //Active = (TrangThai != 0)
        public async Task<List<SinhVienVM>> GetAllActiveAsync(SinhVienSearchVM obj)
        {
            await GetListSinhVienAsync();

            List<SinhVienVM> listSinhVienVM = new List<SinhVienVM>();

            //Kiểm tra TrangThai
            listSinhVienVM = _listSinhViens.Where(c => c.TrangThai != 0).Select(c => new SinhVienVM()
            {
                Id = c.Id,
                Ma = c.Ma,
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
                TrangThai = c.TrangThai,
                IdChuyenNganh = c.IdChuyenNganh,
            }).ToList();


                return listSinhVienVM;
        }

        //
        public async Task<SinhVienVM> GetByIdAsync(Guid id)
        {
            await GetListSinhVienAsync();

            SinhVien temp = _listSinhViens.FirstOrDefault(c => c.Id == id);

            SinhVienVM result = new SinhVienVM()
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
                TenDangNhap = temp.TenDangNhap,
                MatKhau = temp.MatKhau,
                DuongDanAnh = temp.DuongDanAnh,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
                IdChuyenNganh = temp.IdChuyenNganh,
            };
            return result;
        }

        //
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
                TenDangNhap = obj.TenDangNhap,
                MatKhau = obj.MatKhau,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai,
                IdChuyenNganh = obj.IdChuyenNganh,
            };

            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();

            var listSinhVien = await _repos.GetAllAsync();

            if (listSinhVien.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, SinhVienUpdateVM obj)
        {
            var listSinhVien = await _repos.GetAllAsync();

            if (!listSinhVien.Any(c => c.Id == id)) return false;

            var temp = listSinhVien.FirstOrDefault(c => c.Id == id);

            temp.Ma = obj.Ma;
            temp.Ho = obj.Ho;
            temp.TenDem = obj.TenDem;
            temp.Ten = obj.Ten;
            temp.GioiTinh = obj.GioiTinh;
            temp.NgaySinh = obj.NgaySinh;
            temp.DiaChi = obj.DiaChi;
            temp.SoDienThoai = obj.SoDienThoai;
            temp.Email = obj.Email;
            temp.TenDangNhap = obj.TenDangNhap;
            temp.MatKhau = obj.MatKhau;
            temp.DuongDanAnh = obj.DuongDanAnh;
            temp.TrangThai = obj.TrangThai;
            temp.IdChuyenNganh = obj.IdChuyenNganh;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();
            return true;
        }

        //
        public async Task<bool> UpdateRemoveAsync(Guid id)
        {
            var listSinhVien = await _repos.GetAllAsync();

            if (!listSinhVien.Any(c => c.Id == id)) return false;

            var temp = listSinhVien.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();
            return true;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var listSinhVien = await _repos.GetAllAsync();

            if (!listSinhVien.Any(c => c.Id == id)) return false;

            await _repos.RemoveAsync(id);
            await _repos.SaveChangesAsync();

            return true;
        }

    }
}
