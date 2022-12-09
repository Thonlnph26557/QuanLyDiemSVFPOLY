using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class DiemSoServices : IDiemSoServices
    {
        IDiemSoRepository _iDiemSoRepository;
        List<DiemSo> _listDiemSo;


        public DiemSoServices()
        {
            _iDiemSoRepository = new DiemSoRepository();
        }


        private async Task GetListDiemSoAsync()
        {
            _listDiemSo = await _iDiemSoRepository.GetAllDiemSoAsync();
        }

        public async Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM obj)
        {
            await GetListDiemSoAsync();

            List<DiemSoVM> listDiemSoVM = new List<DiemSoVM>();
            listDiemSoVM = _listDiemSo.Select(c => new DiemSoVM()
            {
                Id = c.Id,
                IdMonHoc = c.IdMonHoc,
                TrongSo = c.TrongSo,
                TenDauDiem = c.TenDauDiem,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();

            //if (obj.TrongSo != 0)
            //{
            //    listDiemSoVM = listDiemSoVM.Where(c =>
            // c.TrongSo.ToString().Contains(obj.TrongSo.ToString())).ToList();
            //}
            if (obj.TenDauDiem != null)
            {
                listDiemSoVM = listDiemSoVM.Where(c => c.TenDauDiem.Contains(obj.TenDauDiem)).ToList();
            }
            return listDiemSoVM;

        }

        public async Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM obj)
        {
            await GetListDiemSoAsync();

            List<DiemSoVM> listDiemSoVM = new List<DiemSoVM>();
            listDiemSoVM = _listDiemSo.Where(c=>c.TrangThai !=0).Select(c => new DiemSoVM()
            {
                Id = c.Id,
                IdMonHoc = c.IdMonHoc,
                TrongSo = c.TrongSo,
                TenDauDiem = c.TenDauDiem,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();
            //if (obj.TrongSo != 0)
            //{
            //    listDiemSoVM = listDiemSoVM.Where(c =>
            // c.TrongSo.ToString().Contains(obj.TrongSo.ToString())).ToList();
            //}
            if(obj.TenDauDiem != null)
            {
                listDiemSoVM = listDiemSoVM.Where(c => c.TenDauDiem.Contains(obj.TenDauDiem)).ToList();
            }
            return listDiemSoVM;
        }

        public async Task<DiemSoVM> GetByIdAsync(Guid id)
        {
            await GetListDiemSoAsync();

            DiemSo temp = _listDiemSo.FirstOrDefault(c => c.Id == id);

            DiemSoVM result = new DiemSoVM()
            {
                Id = temp.Id,
                IdMonHoc = temp.IdMonHoc,
                TrongSo = temp.TrongSo,
                TenDauDiem = temp.TenDauDiem,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        public async Task<bool> CreateAsync(DiemSoCreateVM obj)
        {

            var temp = new DiemSo()
            {
                Id = Guid.NewGuid(),
                IdMonHoc = obj.IdMonHoc,
                TrongSo = obj.TrongSo,
                TenDauDiem = obj.TenDauDiem,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai,
            };

            await _iDiemSoRepository.CreateAsync(temp);
            await _iDiemSoRepository.SaveChangesAsync();

            var listDiemSo = await _iDiemSoRepository.GetAllDiemSoAsync();
            if (listDiemSo.Any(c => temp.Id == c.Id)) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM obj)
        {
            var listDiemSo = await _iDiemSoRepository.GetAllDiemSoAsync();
            if (!listDiemSo.Any(c => c.Id == id)) return false;
            var temp = listDiemSo.FirstOrDefault(temp => temp.Id == id);
                temp.IdMonHoc = obj.IdMonHoc;
                temp.TrongSo = obj.TrongSo;
                temp.TenDauDiem = obj.TenDauDiem;
                temp.TrangThai = obj.TrangThai;

            await _iDiemSoRepository.UpdateAsync(temp);
            await _iDiemSoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var listDiemSo = await _iDiemSoRepository.GetAllDiemSoAsync();

            if (!listDiemSo.Any(c => c.Id == id)) return false;
            await _iDiemSoRepository.DeleteAsync(id);
            await _iDiemSoRepository.SaveChangesAsync();
            return true;
        }
    }
}
