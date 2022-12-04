using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
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
    public class KiHocServices : IKiHocServices
    {
        //
        IKiHocRepositories _iKiHocRepositories;

        List<KiHoc> _listKiHocs;


        //
        public KiHocServices()
        {
            _iKiHocRepositories = new KiHocRepositories();
        }

        //
        private async Task GetListKiHocAsync()
        {
            _listKiHocs = await _iKiHocRepositories.GetAllAsync();
        }

        //
        public async Task<List<KiHocViewmodel>> GetAllAsync(KiHocSearchViewmodel obj)
        {
            await GetListKiHocAsync();

            List<KiHocViewmodel> listKiHocViewmodel = new List<KiHocViewmodel>();

            foreach (var temp in _listKiHocs)
            {
                listKiHocViewmodel.Add(new KiHocViewmodel()
                {
                    Id = temp.Id,
                    Ten = temp.Ten,
                    NamHoc = temp.NamHoc,
                    NgayBatDau = temp.NgayBatDau,
                    NgayKetThuc = temp.NgayKetThuc,
                    NgayTao = temp.NgayTao,
                    TrangThai = temp.TrangThai,
                });
            }
            return listKiHocViewmodel;

            //if (obj == null)
            //{
            //    return listKiHocViewmodel;
            //}
            ////Tìm kiếm, tôi chỉ tìm theo Mã trc
            //return listKiHocViewmodel.Where(c => c.Id == obj.Id).ToList();
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<KiHocViewmodel>> GetAllActiveAsync(KiHocSearchViewmodel obj)
        {
            await GetListKiHocAsync();

            List<KiHocViewmodel> listKiHocViewmodel = new List<KiHocViewmodel>();

            foreach (var temp in _listKiHocs)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listKiHocViewmodel.Add(new KiHocViewmodel()
                    {
                        Id = temp.Id,
                        Ten = temp.Ten,
                        NamHoc = temp.NamHoc,
                        NgayBatDau = temp.NgayBatDau,
                        NgayKetThuc = temp.NgayKetThuc,
                        NgayTao = temp.NgayTao,
                        TrangThai = temp.TrangThai,
                    });
                }
            }
            return listKiHocViewmodel;

            //if (obj == null)
            //{
            //    return listKiHocViewmodel;
            //}
            ////Tìm kiếm, tôi chỉ tìm theo Mã trc
            //return listKiHocViewmodel.Where(c => c.Id == obj.Id).ToList();
        }

        //
        public async Task<KiHocViewmodel> GetByIdAsync(Guid id)
        {
            await GetListKiHocAsync();

            KiHoc temp = _listKiHocs.FirstOrDefault(c => c.Id == id);

            KiHocViewmodel result = new KiHocViewmodel()
            {
                Id = temp.Id,
                Ten = temp.Ten,
                NamHoc = temp.NamHoc,
                NgayBatDau = temp.NgayBatDau,
                NgayKetThuc = temp.NgayKetThuc,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        //
        public async Task<bool> CreateAsync(KiHocCreateViewmodel obj)
        {

            var temp = new KiHoc()
            {
                Id = Guid.NewGuid(),
                Ten = obj.Ten,
                NamHoc = obj.NamHoc,
                NgayBatDau = obj.NgayBatDau,
                NgayKetThuc = obj.NgayKetThuc,
                TrangThai = obj.TrangThai
            };

            await _iKiHocRepositories.CreateAsync(temp);
            await _iKiHocRepositories.SaveChangesAsync();

            var _listKiHocs = await _iKiHocRepositories.GetAllAsync();
            if (_listKiHocs.Any(c => temp.Id == c.Id)) return true;

            return false;
        }
        
        //
        public async Task<bool> UpdateAsync(Guid id, KiHocUpdateViewmodel obj)
        {
            var _listKiHocs = await _iKiHocRepositories.GetAllAsync();

            if (!_listKiHocs.Any(c => c.Id == id)) return false;

            var temp = _listKiHocs.FirstOrDefault(temp => temp.Id == id);

                temp.Ten = obj.Ten;
                temp.NamHoc = obj.NamHoc;
                temp.NgayBatDau = obj.NgayBatDau;
                temp.NgayKetThuc = obj.NgayKetThuc;
                temp.TrangThai = obj.TrangThai;

            await _iKiHocRepositories.UpdateAsync(temp);
            await _iKiHocRepositories.SaveChangesAsync();

            return true;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listKiHocs = await _iKiHocRepositories.GetAllAsync();

            if (!_listKiHocs.Any(c => c.Id == id)) return false;

            await _iKiHocRepositories.RemoveAsync(id);
            await _iKiHocRepositories.SaveChangesAsync();

            return true;
        }

    }
}
