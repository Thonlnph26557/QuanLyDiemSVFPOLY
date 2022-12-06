﻿using QLDSVFPOLY.BUS.Services.Interfaces;
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
    public class LopHocServices : ILopHocServices
    {
        ILopHocRepository _iLopHocRepositories;

        List<LopHoc> _listLopHocs;

        //
        public LopHocServices()
        {
            _iLopHocRepositories = new LopHocRepository();
        }
        //
        private async Task GetListLopHocAsync()
        {
            _listLopHocs = await _iLopHocRepositories.GetAllAsync();
        }
        //
        public async Task<List<LopHocVM>> GetAllAsync(LopHocSearchVM searchVm)
        {
            await GetListLopHocAsync();

            List<LopHocVM> listLopHocViewmodel = _listLopHocs.Select(c => new LopHocVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                IdDaoTao = c.IdDaoTao,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();

            //Tìm kiếm theo Mã, TT, Ngày tạo
            if (searchVm.Ma != null)
            {
                return listLopHocViewmodel.Where(c => c.Ma == searchVm.Ma).ToList();
            }
            if (searchVm.TrangThai != null)
            {
                return listLopHocViewmodel.Where(c => c.TrangThai == searchVm.TrangThai).ToList();
            }
            if (searchVm.NgayTao != null)
            {
                return listLopHocViewmodel.Where(c => c.NgayTao == searchVm.NgayTao).ToList();
            }

            return listLopHocViewmodel;
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<LopHocVM>> GetAllActiveAsync(LopHocSearchVM searchVm)
        {
            await GetListLopHocAsync();

            List<LopHocVM> listLopHocViewmodel = _listLopHocs.Where(c => c.TrangThai != 0).Select(c => new LopHocVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                IdDaoTao = c.IdDaoTao,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();

            //Tìm kiếm theo Mã, TT, Ngày tạo
            if (searchVm.Ma != null)
            {
                return listLopHocViewmodel.Where(c => c.Ma == searchVm.Ma).ToList();
            }
            if (searchVm.TrangThai != null)
            {
                return listLopHocViewmodel.Where(c => c.TrangThai == searchVm.TrangThai).ToList();
            }
            if (searchVm.NgayTao != null)
            {
                return listLopHocViewmodel.Where(c => c.NgayTao == searchVm.NgayTao).ToList();
            }

            return listLopHocViewmodel;
        }

        //
        public async Task<LopHocVM> GetByIdAsync(Guid id)
        {
            await GetListLopHocAsync();

            LopHoc temp = _listLopHocs.FirstOrDefault(c => c.Id == id);

            LopHocVM result = new LopHocVM()
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
        public async Task<bool> CreateAsync(LopHocCreateVM createVm)
        {
            createVm.Id = Guid.NewGuid();

            var temp = new LopHoc()
            {
                Id = createVm.Id,
                Ma = createVm.Ma,
                IdDaoTao = createVm.IdDaoTao,// tại sao IdDaoTao lại là NewGuid???
                NgayTao = createVm.NgayTao,
                TrangThai = createVm.TrangThai
            };

            await _iLopHocRepositories.CreateAsync(temp);
            await _iLopHocRepositories.SaveChangesAsync();

            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();
            if (_listLopHocs.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, LopHocUpdateVM updateVm)
        {
            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();
            if (!_listLopHocs.Any(c => c.Id == id)) return false;

            var temp = _listLopHocs.FirstOrDefault(c => c.Id == id);
            temp.NgayTao = updateVm.NgayTao;
            temp.TrangThai = updateVm.TrangThai;

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

        public async Task<bool> UpdateTrangThaiAsync(Guid id)
        {
            var _listLopHocs = await _iLopHocRepositories.GetAllAsync();
            if (!_listLopHocs.Any(c => c.Id == id)) return false;

            var temp = _listLopHocs.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

            await _iLopHocRepositories.UpdateAsync(temp);
            await _iLopHocRepositories.SaveChangesAsync();
            return true;
        }
    }
}
