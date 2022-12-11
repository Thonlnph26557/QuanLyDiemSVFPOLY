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

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class DaoTaoServices : IDaoTaoServices
    {
        //
        IDaoTaoRepository _repos;

        List<DaoTao> _listDaoTaos;

        //
        public DaoTaoServices()
        {
            _repos = new DaoTaoRepository();
        }

        //
        private async Task GetListDaoTaoAsync()
        {
            _listDaoTaos = await _repos.GetAllAsync();
        }

        //
        public async Task<List<DaoTaoVM>> GetAllAsync(DaoTaoSearchVM obj)
        {
            await GetListDaoTaoAsync();

            List<DaoTaoVM> listDaoTaoVM = new List<DaoTaoVM>();

            listDaoTaoVM = _listDaoTaos.Select(c => new DaoTaoVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                DiaChi = c.DiaChi,
                SoDienThoai = c.SoDienThoai,
                Email = c.Email,
                TenDangNhap = c.TenDangNhap,
                MatKhau = c.MatKhau,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
            }).ToList();

            //if (obj.Ma != null ||
            //    obj.DiaChi != null ||
            //    obj.Email != null ||
            //    obj.TrangThai != null
            //    )
            //{
            //    return listDaoTaoVM.Where(c => c.Ma.Contains(obj.Ma)
            //                                        || c.DiaChi.Contains(obj.DiaChi)
            //                                        || c.Email.Contains(obj.Email)
            //                                        || c.TrangThai == (obj.TrangThai)
            //                                        ).ToList();
            //}
            //else
            //{
            //    return listDaoTaoVM;
            //}
            return listDaoTaoVM;
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<DaoTaoVM>> GetAllActiveAsync(DaoTaoSearchVM obj)
        {
            await GetListDaoTaoAsync();

            List<DaoTaoVM> listDaoTaoVM = new List<DaoTaoVM>();

            //Kiểm tra TrangThai
            listDaoTaoVM = _listDaoTaos.Where(c => c.TrangThai != 0).Select(c => new DaoTaoVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                DiaChi = c.DiaChi,
                SoDienThoai = c.SoDienThoai,
                Email = c.Email,
                TenDangNhap = c.TenDangNhap,
                MatKhau = c.MatKhau,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
            }).ToList();
            return listDaoTaoVM;
            //if (obj.Ma != null ||
            //    obj.DiaChi != null ||
            //    obj.Email != null ||
            //    obj.TrangThai != null
            //    )
            //{
            //    return listDaoTaoVM.Where(c => c.Ma.Contains(obj.Ma)
            //                                        || c.DiaChi.Contains(obj.DiaChi)
            //                                        || c.Email.Contains(obj.Email)
            //                                        || c.TrangThai == (obj.TrangThai)
            //                                        ).ToList();
            //}
            //else
            //{
            //    return listDaoTaoVM;
            //}
        }

        //
        public async Task<DaoTaoVM> GetByIdAsync(Guid id)
        {
            await GetListDaoTaoAsync();

            DaoTao temp = _listDaoTaos.FirstOrDefault(c => c.Id == id);

            DaoTaoVM result = new DaoTaoVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                DiaChi = temp.DiaChi,
                SoDienThoai = temp.SoDienThoai,
                Email = temp.Email,
                TenDangNhap = temp.TenDangNhap,
                MatKhau = temp.MatKhau,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }


        //
        public async Task<bool> CreateAsync(DaoTaoCreateVM obj)
        {
            var temp = new DaoTao()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                SoDienThoai = obj.SoDienThoai,
                Email = obj.Email,
                TenDangNhap = obj.TenDangNhap,
                MatKhau = obj.MatKhau,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai
            };

            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();

            var listDaoTao = await _repos.GetAllAsync();

            if (listDaoTao.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj)
        {
            var listDaoTao = await _repos.GetAllAsync();

            if (!listDaoTao.Any(c => c.Id == id)) return false;

            var temp = listDaoTao.FirstOrDefault(c => c.Id == id);

                temp.Ma = obj.Ma;
                temp.DiaChi = obj.DiaChi;
                temp.SoDienThoai = obj.SoDienThoai;
                temp.Email = obj.Email;
                temp.TenDangNhap = obj.TenDangNhap;
                temp.MatKhau = obj.MatKhau;
                temp.TrangThai = obj.TrangThai;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();

            return true;
        }

        //
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

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var listDaoTao = await _repos.GetAllAsync();

            if (!listDaoTao.Any(c => c.Id == id)) return false;

            await _repos.RemoveAsync(id);
            await _repos.SaveChangesAsync();

            return true;
        }
    }
}
