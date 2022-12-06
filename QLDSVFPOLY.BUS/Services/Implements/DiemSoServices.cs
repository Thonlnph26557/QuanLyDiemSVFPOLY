using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
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

            List<DiemSoVM> listDiemSoVM = _listDiemSo.Select(c => new DiemSoVM
            {
                Id = c.Id,
                TrongSo = c.TrongSo,
                TenDauDiem = c.TenDauDiem,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();

            if (obj.TrongSo == 0
                && obj.TenDauDiem == null
                && obj.TrangThai == 0)
            {
                return listDiemSoVM;
            }

            return listDiemSoVM.Where(c =>
            c.TrongSo == obj.TrongSo
            || c.TenDauDiem == obj.TenDauDiem
            || c.TrangThai == obj.TrangThai
            ).ToList();

        }

        public async Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM obj)
        {
            await GetListDiemSoAsync();

            List<DiemSoVM> listDiemSoVM = _listDiemSo.Select(c => new DiemSoVM
            {
                Id = c.Id,
                TrongSo = c.TrongSo,
                TenDauDiem = c.TenDauDiem,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();

            if (obj.TrongSo == 0
                && obj.TenDauDiem == null
                && obj.TrangThai == 0)
            {
                return listDiemSoVM;
            }

            return listDiemSoVM.Where(c =>
            c.TrongSo.ToString().Contains(obj.TrongSo.ToString())
            || c.TenDauDiem.Contains(obj.TenDauDiem)
            || c.TrangThai == obj.TrangThai
            ).ToList();
        }

        public async Task<DiemSoVM> GetByIdAsync(Guid id)
        {
            await GetListDiemSoAsync();

            DiemSo temp = _listDiemSo.FirstOrDefault(c => c.Id == id);

            DiemSoVM result = new DiemSoVM()
            {
                Id = temp.Id,
                TrongSo = temp.TrongSo,
                TenDauDiem = temp.TenDauDiem,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        public async Task<bool> CreateAsync(DiemSoCreateVM obj)
        {
            obj.Id = Guid.NewGuid();

            var temp = new DiemSo()
            {
                Id = obj.Id,
                TrongSo = obj.TrongSo,
                TenDauDiem = obj.TenDauDiem,
                NgayTao = obj.NgayTao,
                TrangThai = obj.TrangThai,
            };

            await _iDiemSoRepository.CreateAsync(temp);
            await _iDiemSoRepository.SaveChangesAsync();

            var listDaoTao = await _iDiemSoRepository.GetAllDiemSoAsync();
            if (listDaoTao.Any(c => obj.Id == c.Id)) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM obj)
        {
            await GetListDiemSoAsync();

            var temp = _listDiemSo.FirstOrDefault(c => c.Id == id);
            if (temp == null)
            {
                return false;
            }
            else
            {
                temp.TrongSo = obj.TrongSo;
                temp.TenDauDiem = obj.TenDauDiem;
                temp.TrangThai = obj.TrangThai;
            }

            await _iDiemSoRepository.UpdateAsync(temp);
            await _iDiemSoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            await GetListDiemSoAsync();

            var temp = _listDiemSo.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

            await _iDiemSoRepository.SaveChangesAsync();
            return true;
        }
    }
}
