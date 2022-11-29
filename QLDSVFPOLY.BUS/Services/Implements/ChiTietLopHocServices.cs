using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class ChiTietLopHocServices : IChiTietLopHocServices
    {
        //
        IChiTietLopHocRepositories _iChiTietLopHocRepositories;
        IGiangVienRepositories _iGiangVienRepositories;
        IKiHocRepositories _iKiHocRepositories;
        ILopHocRepositories _iLopHocRepositories;

        List<ChiTietLopHoc> _listChiTietLopHocs;


        //
        public ChiTietLopHocServices()
        {
            _iChiTietLopHocRepositories = new ChiTietLopHocRepositories();
            _iGiangVienRepositories = new GiangVienRepositories();
            _iKiHocRepositories = new KiHocRepositories();
            _iLopHocRepositories = new LopHocRepositories();
        }

        //
        private async Task GetListChiTietLopHocAsync()
        {
            _listChiTietLopHocs = await _iChiTietLopHocRepositories.GetAllAsync();
        }



        //
        public async Task<List<ChiTietLopHocViewmodel>> GetAllAsync(ChiTietLopHocSearchViewmodel obj)
        {
            await GetListChiTietLopHocAsync();

            List<ChiTietLopHocViewmodel> listChiTietLopHocViewmodel = new List<ChiTietLopHocViewmodel>();


            foreach (var temp in _listChiTietLopHocs)
            {
                listChiTietLopHocViewmodel.Add(new ChiTietLopHocViewmodel()
                {
                    Id = temp.Id,
                    IdGiangVien = temp.IdGiangVien,
                    IdKiHoc = temp.IdKiHoc,
                    IdLopHoc = temp.IdLopHoc,
                    IdMonHoc = temp.IdMonHoc,
                    SoLuongSinhVien = temp.SoLuongSinhVien,
                    TrangThai = temp.TrangThai
                });
            }
            return listChiTietLopHocViewmodel;

            //if (obj == null)
            //{
            //    return listChiTietLopHocViewmodel;
            //}
            ////Tìm kiếm, tôi chỉ tìm theo Mã trc
            //return listChiTietLopHocViewmodel.Where(c => c.Id == obj.Id).ToList();
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<ChiTietLopHocViewmodel>> GetAllActiveAsync(ChiTietLopHocSearchViewmodel obj)
        {
            await GetListChiTietLopHocAsync();

            List<ChiTietLopHocViewmodel> listChiTietLopHocViewmodel = new List<ChiTietLopHocViewmodel>();

            foreach (var temp in _listChiTietLopHocs)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listChiTietLopHocViewmodel.Add(new ChiTietLopHocViewmodel()
                    {
                        Id = temp.Id,
                        IdGiangVien = temp.IdGiangVien,
                        IdKiHoc = temp.IdKiHoc,
                        IdLopHoc = temp.IdLopHoc,
                        IdMonHoc = temp.IdMonHoc,
                        SoLuongSinhVien = temp.SoLuongSinhVien,
                        TrangThai = temp.TrangThai,
                    });
                }
            }
            return listChiTietLopHocViewmodel;


            //if (obj == null)
            //{
            //    return listChiTietLopHocViewmodel;
            //}
            ////Tìm kiếm, tôi chỉ tìm theo Mã trc
            //return listChiTietLopHocViewmodel.Where(c => c.Id == obj.Id).ToList();
        }

        //
        public async Task<ChiTietLopHocViewmodel> GetByIdAsync(Guid id)
        {
            await GetListChiTietLopHocAsync();

            ChiTietLopHoc temp = _listChiTietLopHocs.FirstOrDefault(c => c.Id == id);

            ChiTietLopHocViewmodel result = new ChiTietLopHocViewmodel()
            {
                Id = temp.Id,
                IdGiangVien = temp.IdGiangVien,
                IdKiHoc = temp.IdKiHoc,
                IdLopHoc = temp.IdLopHoc,
                IdMonHoc = temp.IdMonHoc,
                SoLuongSinhVien = temp.SoLuongSinhVien,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        //
        public async Task<bool> CreateAsync(ChiTietLopHocCreateViewmodel obj)
        {
            var temp = new ChiTietLopHoc()
            {
                Id = Guid.NewGuid(),
                IdGiangVien = obj.IdGiangVien,
                IdKiHoc = obj.IdKiHoc,
                IdLopHoc = obj.IdLopHoc,
                IdMonHoc = obj.IdMonHoc,
                SoLuongSinhVien = obj.SoLuongSinhVien,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai
            };

            await _iChiTietLopHocRepositories.CreateAsync(temp);
            await _iChiTietLopHocRepositories.SaveChangesAsync();

            var _listChiTietLopHocs = await _iChiTietLopHocRepositories.GetAllAsync();

            if (_listChiTietLopHocs.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, ChiTietLopHocUpdateViewmodel obj)
        {
            var _listChiTietLopHocs = await _iChiTietLopHocRepositories.GetAllAsync();

            if (!_listChiTietLopHocs.Any(c => c.Id == id)) return false;

            var temp = _listChiTietLopHocs.FirstOrDefault(temp => temp.Id == id);

                temp.IdGiangVien = obj.IdGiangVien;
                temp.IdKiHoc = obj.IdKiHoc;
                temp.IdLopHoc = obj.IdLopHoc;
                temp.IdMonHoc = obj.IdMonHoc;
                temp.SoLuongSinhVien = obj.SoLuongSinhVien;
                temp.TrangThai = obj.TrangThai;
            

            await _iChiTietLopHocRepositories.UpdateAsync(temp);
            await _iChiTietLopHocRepositories.SaveChangesAsync();

            return true;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listChiTietLopHocs = await _iChiTietLopHocRepositories.GetAllAsync();

            if (!_listChiTietLopHocs.Any(c => c.Id == id)) return false;

            await _iChiTietLopHocRepositories.RemoveAsync(id);
            await _iChiTietLopHocRepositories.SaveChangesAsync();

            return true;
        }

    }
}
