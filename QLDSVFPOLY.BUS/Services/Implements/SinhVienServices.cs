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
    public class SinhVienServices: ISinhVienServices
    {
        //
        ISinhVienRepository _repos;
        List<SinhVien> _listSinhVien;

        //
        public SinhVienServices()
        {
            _repos = new SinhVienRepository();
        }

        //
        private async Task GetListSinhVienAsync()
        {
            _listSinhVien = await _repos.GetAllAsync();
        }

        //
        public async Task<List<SinhVienVM>> GetAllAsync(SinhVienSearchVM obj)
        {
            await GetListSinhVienAsync();

            List<SinhVienVM> listSinhVienVM = new List<SinhVienVM>();

            foreach (var temp in _listSinhVien)
            {
                listSinhVienVM.Add(new SinhVienVM()
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
                });
            }

            if (obj == null)
            {
                return listSinhVienVM;
            }
            return listSinhVienVM.Where(c => c.Ma == obj.Ma).ToList();
        }

        //
        public async Task<List<SinhVienVM>> GetAllActiveAsync(SinhVienSearchVM obj)
        {
            await GetListSinhVienAsync();

            List<SinhVienVM> listSinhVienVM = new List<SinhVienVM>();

            foreach (var temp in _listSinhVien)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listSinhVienVM.Add(new SinhVienVM()
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
                    });
                }
            }
            if (obj == null)
            {
                return listSinhVienVM;
            }
            return listSinhVienVM.Where(c => c.Ma == obj.Ma).ToList();
        }

        //
        public async Task<SinhVienVM> GetByIdAsync(Guid id)
        {
            await GetListSinhVienAsync();

            SinhVien temp = _listSinhVien.FirstOrDefault(c => c.Id == id);

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

            var temp = new SinhVien()
            {
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
                TrangThai = obj.TrangThai,
                IdChuyenNganh = obj.IdChuyenNganh,
            };
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
