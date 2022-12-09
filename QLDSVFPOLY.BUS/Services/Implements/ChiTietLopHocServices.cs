using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
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
    public class ChiTietLopHocServices : IChiTietLopHocServices
    {
        //
        IChiTietLopHocRepositories _iChiTietLopHocRepositories;
        IGiangVienRepository _iGiangVienRepositories;
        IKiHocRepositories _iKiHocRepositories;
        ILopHocRepository _iLopHocRepositories;

        List<ChiTietLopHoc> _listChiTietLopHocs;


        //
        public ChiTietLopHocServices()
        {
            _iChiTietLopHocRepositories = new ChiTietLopHocRepositories();
            _iGiangVienRepositories = new GiangVienRepository();
            _iKiHocRepositories = new KiHocRepositories();
            _iLopHocRepositories = new LopHocRepository();
        }

        //
        private async Task GetListChiTietLopHocAsync()
        {
            _listChiTietLopHocs = await _iChiTietLopHocRepositories.GetAllAsync();
        }



        //
        public async Task<List<ChiTietLopHocVM>> GetAllAsync(ChiTietLopHocSearchVM obj)
        {
            await GetListChiTietLopHocAsync();

            List<ChiTietLopHocVM> listChiTietLopHocViewmodel = new List<ChiTietLopHocVM>();


            foreach (var temp in _listChiTietLopHocs)
            {
                listChiTietLopHocViewmodel.Add(new ChiTietLopHocVM()
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
        public async Task<List<ChiTietLopHocVM>> GetAllActiveAsync(ChiTietLopHocSearchVM obj)
        {
            await GetListChiTietLopHocAsync();

            List<ChiTietLopHocVM> listChiTietLopHocViewmodel = new List<ChiTietLopHocVM>();

            foreach (var temp in _listChiTietLopHocs)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listChiTietLopHocViewmodel.Add(new ChiTietLopHocVM()
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
        public async Task<ChiTietLopHocVM> GetByIdAsync(Guid id)
        {
            await GetListChiTietLopHocAsync();

            ChiTietLopHoc temp = _listChiTietLopHocs.FirstOrDefault(c => c.Id == id);

            ChiTietLopHocVM result = new ChiTietLopHocVM()
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
        public async Task<bool> CreateAsync(ChiTietLopHocCreateVM obj)
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
        public async Task<bool> UpdateAsync(Guid id, ChiTietLopHocUpdateVM obj)
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
