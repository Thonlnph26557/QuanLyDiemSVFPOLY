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
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class MonHocServices : IMonHocServices
    {
        //
        IMonHocRepository _repos;
        List<MonHoc> _listMonHocs;

        //
        public MonHocServices()
        {
            _repos = new MonHocRepository();
        }

        //
        private async Task GetListMonHocAsync()
        {
            _listMonHocs = await _repos.GetAllAsync();
        }

        //
        public async Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM obj)
        {
            await GetListMonHocAsync();

            List<MonHocVM> listMonHocVM = new List<MonHocVM>();

            listMonHocVM = _listMonHocs.Select(c => new MonHocVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                Ten = c.Ten,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
            }).ToList();

                return listMonHocVM;
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM obj)
        {
            await GetListMonHocAsync();

            List<MonHocVM> listMonHocVM = new List<MonHocVM>();

            //Kiểm tra TrangThai
            listMonHocVM = _listMonHocs.Where(c => c.TrangThai != 0).Select(c => new MonHocVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                Ten = c.Ten,
                DuongDanAnh = c.DuongDanAnh,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai,
            }).ToList();

            //        if (obj.Ma != null ||
            //            obj.Ten != null
            //            )
            //        {
            //            return listMonHocVM.Where(c => 
            //                c.Ma.Contains(obj.Ma)
            //                || c.Ten.Contains(obj.Ten)
            //            ).ToList();
            //}
            //        else
            //        {
            return listMonHocVM;
            //        }

        }

        //
        public async Task<MonHocVM> GetByIdAsync(Guid id)
        {
            await GetListMonHocAsync();

            MonHoc temp = _listMonHocs.FirstOrDefault(c => c.Id == id);

            MonHocVM result = new MonHocVM()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                Ten = temp.Ten,
                DuongDanAnh = temp.DuongDanAnh,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
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

            var temp = listMonHoc.FirstOrDefault(c => c.Id == id);

                temp.Ma = obj.Ma;
                temp.Ten = obj.Ten;
                temp.DuongDanAnh = obj.DuongDanAnh;
                temp.TrangThai = obj.TrangThai;

            await _repos.UpdateAsync(temp);
            await _repos.SaveChangesAsync();

            return true;
        }


        //
        public async Task<bool> UpdateRemoveAsync(Guid id)
        {
            var listMonHoc = await _repos.GetAllAsync();

            if (!listMonHoc.Any(c => c.Id == id)) return false;

            var temp = listMonHoc.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

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
