using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
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
    public class MonHocServices : IMonHocServices
    {
        //
        IMonHocRepository _repos;
        List<MonHoc> _listMonHoc;

        //
        public MonHocServices()
        {
            _repos = new MonHocRepository();
        }

        //
        private async Task GetListMonHocAsync()
        {
            _listMonHoc = await _repos.GetAllAsync();
        }

        //
        public async Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM obj)
        {
            await GetListMonHocAsync();

            List<MonHocVM> listMonHocVM = new List<MonHocVM>();

            foreach (var temp in _listMonHoc)
            {
                listMonHocVM.Add(new MonHocVM()
                {
                    Id = temp.Id,
                    Ma = temp.Ma,
                    Ten = temp.Ten,
                    DuongDanAnh = temp.DuongDanAnh,
                    NgayTao = temp.NgayTao,
                    TrangThai = temp.TrangThai,
                    IdChuyenNganh = temp.IdChuyenNganh,
                });
            }

            if (obj == null)
            {
                return listMonHocVM;
            }
            return listMonHocVM.Where(c => c.Ma == obj.Ma).ToList();
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM obj)
        {
            await GetListMonHocAsync();

            List<MonHocVM> listMonHocVM = new List<MonHocVM>();

            foreach(var temp in _listMonHoc)
            {
                //Kiểm tra TrangThai
                if(temp.TrangThai != 0)
                {
                    listMonHocVM.Add(new MonHocVM()
                    {
                        Id = temp.Id,
                        Ma = temp.Ma,
                        Ten = temp.Ten,
                        DuongDanAnh = temp.DuongDanAnh,
                        NgayTao = temp.NgayTao,
                        TrangThai = temp.TrangThai,
                        IdChuyenNganh = temp.IdChuyenNganh,
                    });
                }
            }
            if(obj == null)
            {
                return listMonHocVM;
            }
            return listMonHocVM.Where(c =>c.Ma == obj.Ma).ToList();
        }

        //
        public async Task<MonHocVM> GetByIdAsync(Guid id)
        {
            await GetListMonHocAsync();

            MonHoc temp = _listMonHoc.FirstOrDefault(c => c.Id == id);

            MonHocVM result = new MonHocVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                Ten = temp.Ten,
                DuongDanAnh = temp.DuongDanAnh,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
                IdChuyenNganh = temp.IdChuyenNganh,
            };
            return result;
        }

        //
        public async Task<bool> CreateAsync(MonHocCreateVM obj)
        {
            var temp = new MonHoc()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                Ten = obj.Ten,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai,
                IdChuyenNganh = obj.IdChuyenNganh,
            };

            await _repos.CreateAsync(temp);
            await _repos.SaveChangesAsync();

            var listMonHoc = await _repos.GetAllAsync();

            if (listMonHoc.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, MonHocUpdateVM obj)
        {
            var listMonHoc = await _repos.GetAllAsync();

            if (!listMonHoc.Any(c => c.Id == id)) return false;

            var temp = new MonHoc()
            {
                Ma = obj.Ma,
                Ten = obj.Ten,
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
            var listMonHoc = await _repos.GetAllAsync();

            if (!listMonHoc.Any(c => c.Id == id)) return false;

            await _repos.RemoveAsync(id);
            await _repos.SaveChangesAsync();

            return true;
        }

    }
}
