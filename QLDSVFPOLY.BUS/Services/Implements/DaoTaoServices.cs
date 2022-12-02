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

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class DaoTaoServices : IDaoTaoServices
    {
        //
        IDaoTaoRepository _repos;

        List<DaoTao> _listDaoTao;

        //
        public DaoTaoServices()
        {
            _repos = new DaoTaoRepository();
        }

        //
        private async Task GetListDaoTaoAsync()
        {
            _listDaoTao = await _repos.GetAllAsync();
        }

        //
        public async Task<List<DaoTaoVM>> GetAllAsync(DaoTaoSearchVM obj)
        {
            await GetListDaoTaoAsync();

            List<DaoTaoVM> listDaoTaoVM = new List<DaoTaoVM>();

            foreach(var temp in _listDaoTao)
            {
                listDaoTaoVM.Add(new DaoTaoVM()
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
                });
            }

            if(obj == null)
            {
                return listDaoTaoVM;
            }
            //Tìm kiếm, tôi chỉ tìm theo Mã trc
            return listDaoTaoVM.Where(c => c.Ma == obj.Ma).ToList();
        }


        //Active = (TrangThai != 0)
        public async Task<List<DaoTaoVM>> GetAllActiveAsync(DaoTaoSearchVM obj)
        {
            await GetListDaoTaoAsync();

            List<DaoTaoVM> listDaoTaoVM = new List<DaoTaoVM>();

            foreach (var temp in _listDaoTao)
            {
                //Kiểm tra TrangThai
                if(temp.TrangThai != 0)
                {
                    listDaoTaoVM.Add(new DaoTaoVM()
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
                    });
                }
            }

            if (obj == null)
            {
                return listDaoTaoVM;
            }
            //Tìm kiếm, tôi chỉ tìm theo Mã trc
            return listDaoTaoVM.Where(c => c.Ma == obj.Ma).ToList();
        }

        public async Task<DaoTaoVM> GetByIdAsync(Guid id)
        {
            await GetListDaoTaoAsync();

            DaoTao temp = _listDaoTao.FirstOrDefault(c => c.Id == id);

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
                TrangThai = obj.TrangThai,
            };

            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();

            var listDaoTao = await _repos.GetAllAsync();

            if (listDaoTao.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj)
        {
            var listDaoTao = await _repos.GetAllAsync();

            if (!listDaoTao.Any(c => c.Id == id)) return false;

            var temp = new DaoTao()
            {
                Ma = obj.Ma,
                DiaChi = obj.DiaChi,
                SoDienThoai = obj.SoDienThoai,
                Email = obj.Email,
                TenDangNhap = obj.TenDangNhap,
                MatKhau = obj.MatKhau,
                TrangThai = obj.TrangThai,
            };

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();

            return true;
        }
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
