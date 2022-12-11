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
                TenChuyenNganh = c.TenNganhHoc,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
                IdChuyenNganh = c.IdChuyenNganh,
                IdDaoTao = c.IdDaoTao
            }).ToList();

            //if (obj.Ma == null
            //    && obj.TenChuyenNganh == null
            //    )
            //{
            //    return listChuyenNganhVM;
            //}
            //return listChuyenNganhVM.Where(c => c.Ma.Contains(obj.Ma)
            //                                || c.TenChuyenNganh.Contains(obj.TenChuyenNganh)).ToList();

            return listChuyenNganhVM;
        }


        //Active = (TrangThai != 0)
        public async Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM obj)
        {
            await GetListChuyenNganhAsync();

            List<ChuyenNganhVM> listChuyenNganhVM = _listChuyenNganh.Select(c => new ChuyenNganhVM
            {
                Id = c.Id,
                Ma = c.Ma,
                TenChuyenNganh = c.TenNganhHoc,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
                IdChuyenNganh = c.IdChuyenNganh,
                IdDaoTao = c.IdDaoTao
            }).Where(c => c.TrangThai != 0).ToList();

            //if (obj.Ma != null
            //    || obj.TenChuyenNganh != null)
            //{
            //    return listChuyenNganhVM.Where(c => c.Ma.Contains(obj.Ma)
            //                                    || c.TenChuyenNganh.Contains(obj.TenChuyenNganh)).ToList();
            //}
            return listChuyenNganhVM;
        }

        public async Task<ChuyenNganhVM> GetByIdAsync(Guid id)
        {
            await GetListChuyenNganhAsync();

            ChuyenNganh temp = _listChuyenNganh.FirstOrDefault(c => c.Id == id);

            ChuyenNganhVM result = new ChuyenNganhVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                TenChuyenNganh = temp.TenNganhHoc,
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
            var temp = new ChuyenNganh()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                TenNganhHoc = obj.TenChuyenNganh,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = DateTime.Now,
                IdChuyenNganh = obj.IdChuyenNganh,
                TrangThai = obj.TrangThai,
                IdDaoTao = obj.IdDaoTao,
            };

            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();
            var listChuyenNganh = await _repos.GetAllAsync();
            if (listChuyenNganh.Any(c => temp.Id == c.Id)) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM obj)
        {
            var listChuyenNganh = await _repos.GetAllAsync();
            if (!listChuyenNganh.Any(c => c.Id == id)) return false;

            var temp = listChuyenNganh.FirstOrDefault(c => c.Id == id);

            temp.Ma = obj.Ma;
            temp.TenNganhHoc = obj.TenChuyenNganh;
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


        //lấy ra list ChuyenNganhHep có IdChuyenNganh == id
        public async Task<List<ChuyenNganhVM>> GetChuyenNganhHepById(Guid id)
        {
            await GetListChuyenNganhAsync();

            List<ChuyenNganhVM> listChuyenNganhVM = new List<ChuyenNganhVM>();

            foreach (var temp in _listChuyenNganh)
            {
                listChuyenNganhVM.Add(new ChuyenNganhVM()
                {
                    Id = temp.Id,
                    Ma = temp.Ma,
                    TenChuyenNganh = temp.TenNganhHoc,
                    DuongDanAnh = temp.DuongDanAnh,
                    NgayTao = temp.NgayTao,
                    TrangThai = temp.TrangThai,
                    IdChuyenNganh = temp.IdChuyenNganh,
                    IdDaoTao = temp.IdDaoTao,
                });
            }

            return listChuyenNganhVM.Where(c => c.IdChuyenNganh == id).ToList();
        }

        public async Task<bool> UpdateTrangThaiAsync(Guid id)
        {
            var listChuyenNganh = await _repos.GetAllAsync();
            if (!listChuyenNganh.Any(c => c.Id == id)) return false;

            var temp = listChuyenNganh.FirstOrDefault(c => c.Id == id);


            temp.TrangThai = 0;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();
            return true;
        }
    }
}
