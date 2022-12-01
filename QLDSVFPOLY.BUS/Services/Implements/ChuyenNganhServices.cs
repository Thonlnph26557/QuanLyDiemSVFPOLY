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

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class ChuyenNganhServices  : IChuyenNganhServices
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

            List<ChuyenNganhVM> listChuyenNganhVM = new List<ChuyenNganhVM>();

            foreach (var temp in _listChuyenNganh)
            {
                listChuyenNganhVM.Add(new ChuyenNganhVM()
                {
                    Id = temp.Id,
                    Ma = temp.Ma,
                    TenNganhHoc = temp.TenNganhHoc,
                    DuongDanAnh = temp.DuongDanAnh,
                    NgayTao = temp.NgayTao,
                    TrangThai = temp.TrangThai,
                    IdChuyenNganh = temp.IdChuyenNganh,
                    IdDaoTao = temp.IdDaoTao,
                });
            }

            if (obj == null)
            {
                return listChuyenNganhVM;
            }
            //Tìm kiếm theo mã || tên
            return listChuyenNganhVM.Where(c => c.Ma == obj.Ma || c.TenNganhHoc == obj.TenNganhHoc).ToList();
        }


        //Active = (TrangThai != 0)
        public async Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM obj)
        {
            await GetListChuyenNganhAsync();

            List<ChuyenNganhVM> listChuyenNganhVM = new List<ChuyenNganhVM>();

            foreach (var temp in _listChuyenNganh)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listChuyenNganhVM.Add(new ChuyenNganhVM()
                    {
                        Id = temp.Id,
                        Ma = temp.Ma,
                        TenNganhHoc = temp.TenNganhHoc,
                        DuongDanAnh = temp.DuongDanAnh,
                        NgayTao = temp.NgayTao,
                        TrangThai = temp.TrangThai,
                        IdChuyenNganh = temp.IdChuyenNganh,
                        IdDaoTao = temp.IdDaoTao,
                    });
                }
            }

            if (obj == null)
            {
                return listChuyenNganhVM;
            }
            //Tìm kiếm theo Mã || Tên
            return listChuyenNganhVM.Where(c => c.Ma == obj.Ma || c.TenNganhHoc == obj.TenNganhHoc).ToList();
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
    }
}
