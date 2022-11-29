using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DTO.Entities;
using QLDSVFPOLY.DTO.Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class LopHocServices : ILopHocServices
    {
        //
        ILopHocRepositories _iLopHocRepositories;

        List<LopHoc> _listLopHocs;

        //
        public LopHocServices()
        {
            _iLopHocRepositories = new LopHocRepositories();
        }
        //
        private async Task GetListLopHocAsync()
        {
            _listLopHocs = await _iLopHocRepositories.GetAllAsync();
        }
        //
        public async Task<List<LopHocViewmodel>> GetAllAsync(LopHocSearchViewmodel obj)
        {
            await GetListLopHocAsync();

            List<LopHocViewmodel> listLopHocViewmodel = new List<LopHocViewmodel>();

            foreach (var temp in _listLopHocs)
            {
                listLopHocViewmodel.Add(new LopHocViewmodel()
                {
                    Id = temp.Id,
                    Ma = temp.Ma,
                    IdDaoTao = temp.IdDaoTao,
                    NgayTao = temp.NgayTao,
                    TrangThai = temp.TrangThai
                });
            }

            if (obj == null)
            {
                return listLopHocViewmodel;
            }
            //Tìm kiếm, tôi chỉ tìm theo Mã trc
            return listLopHocViewmodel.Where(c => c.Ma == obj.Ma).ToList();
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<LopHocViewmodel>> GetAllActiveAsync(LopHocSearchViewmodel obj)
        {
            await GetListLopHocAsync();

            List<LopHocViewmodel> listLopHocViewmodel = new List<LopHocViewmodel>();


            foreach (var temp in _listLopHocs)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listLopHocViewmodel.Add(new LopHocViewmodel()
                    {
                        Id = temp.Id,
                        Ma = temp.Ma,
                        IdDaoTao = temp.IdDaoTao,
                        NgayTao = temp.NgayTao,
                        TrangThai = temp.TrangThai
                    });
                }
            }

            if (obj == null)
            {
                return listLopHocViewmodel;
            }
            //Tìm kiếm, tôi chỉ tìm theo Mã trc
            return listLopHocViewmodel.Where(c => c.Ma == obj.Ma).ToList();
        }

        //
        public async Task<LopHocViewmodel> GetByIdAsync(Guid id)
        {
            await GetListLopHocAsync();

            LopHoc temp = _listLopHocs.FirstOrDefault(c => c.Id == id);

            LopHocViewmodel result = new LopHocViewmodel()
            {
                Id = temp.Id,
                Ma = temp.Ma,
                IdDaoTao = temp.IdDaoTao,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        //
        public async Task<bool> CreateAsync(LopHocCreateViewmodel obj)
        {

            var temp = new LopHoc()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                TrangThai = obj.TrangThai
            };

            await _iLopHocRepositories.CreateAsync(temp);
            await _iLopHocRepositories.SaveChangesAsync();

            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();
            if (_listLopHocs.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, LopHocUpdateViewmodel obj)
        {
            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();

            if (!_listLopHocs.Any(c => c.Id == id)) return false;

            var temp = _listLopHocs.FirstOrDefault(temp => temp.Id == id);

                temp.Ma = obj.Ma;
                temp.TrangThai = obj.TrangThai;

            await _iLopHocRepositories.UpdateAsync(temp);
            await _iLopHocRepositories.SaveChangesAsync();

            return true;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();

            if (!_listLopHocs.Any(c => c.Id == id)) return false;

            await _iLopHocRepositories.RemoveAsync(id);
            await _iLopHocRepositories.SaveChangesAsync();

            return true;
        }

    }
}
