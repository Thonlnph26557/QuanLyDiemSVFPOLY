using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;
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
    public class NhanVienDaoTaoServices : INhanVienDaoTaoServices
    {
        //
        INhanVienDaoTaoRepository _repos;
        List<NhanVienDaoTao> _list;

        //
        public NhanVienDaoTaoServices()
        {
            _repos = new NhanVienDaoTaoRepository();
        }

        //
        private async Task GetListNhanVienDaoTaoAsync()
        {
            _list = await _repos.GetAllAsync();
        }

        //
        public async Task<bool> CreateAsync(NhanVienDaoTaoCreateVM obj)
        {
            //obj.Id = Guid.NewGuid();
            var temp = new NhanVienDaoTao()
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
                TenDangNhap = obj.TenDangNhap,
                MatKhau = obj.MatKhau,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai,
            };
            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();
            var listNhanVienDaoTao = await _repos.GetAllAsync();
            if (listNhanVienDaoTao.Any(c => temp.Id == c.Id)) return true;
            return false;
        }

        //
        public async Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj)
        {
            await GetListNhanVienDaoTaoAsync();

            List<NhanVienDaoTaoVM> listNhanVienDaoTaoVM = new List<NhanVienDaoTaoVM>();

            listNhanVienDaoTaoVM = _list.Where(c => c.TrangThai != 0).Select(c => new NhanVienDaoTaoVM()
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
                TrangThai = c.TrangThai,
            }).ToList();

            //if (obj.Ma != null ||
            //    obj.Ho != null ||
            //    obj.TenDem != null ||
            //    obj.Ten != null ||
            //    obj.GioiTinh != 0 ||
            //    obj.DiaChi != null ||
            //    obj.SoDienThoai != null ||
            //    obj.Email != null ||
            //    obj.TrangThai != 0
            //    )
            //{
            //    return listNhanVienDaoTaoVM.Where(c => c.Ma.Contains(obj.Ma)
            //                                        || c.Ho.Contains(obj.Ho)
            //                                        || c.TenDem.Contains(obj.TenDem)
            //                                        || c.Ten.Contains(obj.Ten)
            //                                        || c.GioiTinh==(obj.GioiTinh)
            //                                        || c.DiaChi.Contains(obj.DiaChi)
            //                                        || c.SoDienThoai.Contains(obj.SoDienThoai)
            //                                        || c.Email.Contains(obj.Email)
            //                                        || c.TrangThai == (obj.TrangThai)
            //                                        ).ToList();
            //}
            //else
            //{
                return listNhanVienDaoTaoVM;
            //}
        }

        //
        public async Task<List<NhanVienDaoTaoVM>> GetAllAsync(NhanVienDaoTaoSearchVM obj)
        {
            await GetListNhanVienDaoTaoAsync();

            List<NhanVienDaoTaoVM> listNhanVienDaoTaoVM = new List<NhanVienDaoTaoVM>();

            listNhanVienDaoTaoVM = _list.Select(c => new NhanVienDaoTaoVM()
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
                TrangThai = c.TrangThai,
            }).ToList();

            //if (obj.Ma != null ||
            //    obj.Ho != null ||
            //    obj.TenDem != null ||
            //    obj.Ten != null ||
            //    obj.GioiTinh != 0 ||
            //    obj.DiaChi != null ||
            //    obj.SoDienThoai != null ||
            //    obj.Email != null ||
            //    obj.TrangThai != 0
            //    )
            //{
            //    return listNhanVienDaoTaoVM.Where(c => c.Ma.Contains(obj.Ma)
            //                                        || c.Ho.Contains(obj.Ho)
            //                                        || c.TenDem.Contains(obj.TenDem)
            //                                        || c.Ten.Contains(obj.Ten)
            //                                        || c.GioiTinh == (obj.GioiTinh)
            //                                        || c.DiaChi.Contains(obj.DiaChi)
            //                                        || c.SoDienThoai.Contains(obj.SoDienThoai)
            //                                        || c.Email.Contains(obj.Email)
            //                                        || c.TrangThai == (obj.TrangThai)
            //                                        ).ToList();
            //}
            //else
            //{
                return listNhanVienDaoTaoVM;
            //}
        }

        //
        public async Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id)
        {
            await GetListNhanVienDaoTaoAsync();

            NhanVienDaoTao temp = _list.FirstOrDefault(c => c.Id == id);

            NhanVienDaoTaoVM result = new NhanVienDaoTaoVM()
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
                NgayTao = temp.NgayTao,
                DuongDanAnh = temp.DuongDanAnh,
                TrangThai = temp.TrangThai,
            };
            return result;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var listNhanVienDaoTao = await _repos.GetAllAsync();
            if (!listNhanVienDaoTao.Any(c => c.Id == id)) return false;

            await _repos.RemoveAsync(id);
            await _repos.SaveChangesAsync();

            return true;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj)
        {
            var listNhanVienDaoTao = await _repos.GetAllAsync();

            if (!listNhanVienDaoTao.Any(c => c.Id == id)) return false;

            var temp = listNhanVienDaoTao.FirstOrDefault(c=>c.Id==id);

            temp.Ma = obj.Ma;
            temp.IdDaoTao = obj.IdDaoTao;
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
            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();
            return true;
        }

        //
        public async Task<bool> UpdateRemoveAsync(Guid id)
        {
            var listNhanVienDaoTao = await _repos.GetAllAsync();

            if (!listNhanVienDaoTao.Any(c => c.Id == id)) return false;

            var temp = listNhanVienDaoTao.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();

            return true;
        }

    }
}
    
