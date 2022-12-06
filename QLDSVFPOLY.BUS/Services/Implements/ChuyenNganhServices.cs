using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class ChuyenNganhServices : IChuyenNganhServices
    {
        IChuyenNganhRepository _repos;

        List<ChuyenNganh> _listChuyenNganh;

        public ChuyenNganhServices()
        {
            _repos = new ChuyenNganhRepository();
        }

        private async Task GetListChuyenNganhAsync()
        {
            _listChuyenNganh = await _repos.GetAllAsync();
        }

        public async Task<List<ChuyenNganhVM>> GetAllAsync(ChuyenNganhSearchVM obj)
        {
            await GetListChuyenNganhAsync();

            List<ChuyenNganhVM> listChuyenNganhVM = _listChuyenNganh.Select(c => new ChuyenNganhVM
            {
                Id = c.Id,
                Ma = c.Ma,
                TenNganhHoc = c.TenNganhHoc,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
                IdChuyenNganh = c.IdChuyenNganh,
                IdDaoTao = c.IdDaoTao
            }).ToList();

            if (obj.Ma == null 
                && obj.TenNganhHoc == null
                && obj.TrangThai == 0)
            {
                return listChuyenNganhVM;
            }
            return listChuyenNganhVM.Where(c => 
            c.Ma.Contains(obj.Ma)
            || c.TenNganhHoc.Contains(obj.TenNganhHoc)
            || c.TrangThai == obj.TrangThai).ToList();
        }


        //Active = (TrangThai != 0)
        public async Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM obj)
        {
            await GetListChuyenNganhAsync();

            List<ChuyenNganhVM> listChuyenNganhVM = _listChuyenNganh.Select(c => new ChuyenNganhVM
            {
                Id = c.Id,
                Ma = c.Ma,
                TenNganhHoc = c.TenNganhHoc,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
                IdChuyenNganh = c.IdChuyenNganh,
                IdDaoTao = c.IdDaoTao
            }).Where(c => c.TrangThai != 0).ToList();

            if (obj.Ma == null
                && obj.TenNganhHoc == null
                && obj.TrangThai == 0)
            {
                return listChuyenNganhVM;
            }
            return listChuyenNganhVM.Where(c =>
            c.Ma.Contains(obj.Ma)
            || c.TenNganhHoc.Contains(obj.TenNganhHoc)
            || c.TrangThai == obj.TrangThai).ToList();
        }

        public async Task<ChuyenNganhVM> GetByIdAsync(Guid id)
        {
            await GetListChuyenNganhAsync();

            ChuyenNganh temp = _listChuyenNganh.FirstOrDefault(c => c.Id == id);

            ChuyenNganhVM result = new ChuyenNganhVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                TenNganhHoc = temp.TenNganhHoc,
                DuongDanAnh = temp.DuongDanAnh,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
                IdChuyenNganh = temp.IdChuyenNganh,
                IdDaoTao = temp.IdDaoTao,
            };

            return result;
        }


        public async Task<bool> CreateAsync(ChuyenNganhCreateVM obj)
        {
            obj.Id = Guid.NewGuid();
            var temp = new ChuyenNganh()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                TenNganhHoc = obj.TenNganhHoc,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = obj.NgayTao,
                TrangThai = obj.TrangThai,
                IdChuyenNganh = obj.IdChuyenNganh,
                IdDaoTao = obj.IdDaoTao,
            };
            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();
            var listChuyenNganh = await _repos.GetAllAsync();
            if (listChuyenNganh.Any(c => obj.Id == c.Id)) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM obj)
        {
            var listChuyenNganh = await _repos.GetAllAsync();
            if (!listChuyenNganh.Any(c => c.Id == id)) return false;

            var temp = listChuyenNganh.FirstOrDefault(c => c.Id == id);

            temp.Ma = obj.Ma;
            temp.TenNganhHoc = obj.TenNganhHoc;
            temp.DuongDanAnh = obj.DuongDanAnh;
            temp.TrangThai = obj.TrangThai;
            temp.IdChuyenNganh = obj.IdChuyenNganh;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveAsync(Guid id)
        {
            var listChuyenNganh = await _repos.GetAllAsync();
            if (!listChuyenNganh.Any(c => c.Id == id)) return false;
            await _repos.RemoveAsync(id);
            await _repos.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateChuyenNganhHep(ChuyenNganhCreateVM obj, Guid idChuyenNganh)
        {
            var temp = new ChuyenNganh()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                TenNganhHoc = obj.TenNganhHoc,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = obj.NgayTao,
                TrangThai = obj.TrangThai,
                IdChuyenNganh = idChuyenNganh,
                IdDaoTao = obj.IdDaoTao,
            };
            await _repos.CreateChuyenNganhHep(temp, idChuyenNganh);
            await _repos.SaveChangesAsync();
            var listChuyenNganh = await _repos.GetAllAsync();
            //if (listChuyenNganh.Any(c => c.Id == idChuyenNganh)) return true;

            if (listChuyenNganh.Any(c => c.Id == obj.Id)) return true;
            return false;
        }

        //lấy ra list ChuyenNganhHep có IdChuyenNganh == id
        //Lấy 1 vm thôi, nhưng mà cũng giống cái get by id trên
        public async Task<ChuyenNganhVM> GetChuyenNganhHepById(Guid id)
        {
            await GetListChuyenNganhAsync();

            ChuyenNganh temp = _listChuyenNganh.FirstOrDefault(c => c.Id == id);

            ChuyenNganhVM result = new ChuyenNganhVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                TenNganhHoc = temp.TenNganhHoc,
                DuongDanAnh = temp.DuongDanAnh,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
                IdChuyenNganh = temp.IdChuyenNganh,
                IdDaoTao = temp.IdDaoTao,
            };

            return result;
        }
    }
}
