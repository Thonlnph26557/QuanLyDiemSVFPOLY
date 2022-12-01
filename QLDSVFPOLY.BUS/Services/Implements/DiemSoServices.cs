using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DTO.Entities;
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


        private async Task GetListDiemSopAsync()
        {
            _listDiemSo = await _iDiemSoRepository.GetAllDiemSoAsync();
        }

        public async Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM obj)
        {
            await GetListDiemSopAsync();

            List<DiemSoVM> listDiemSoVM = new List<DiemSoVM>();

            foreach (var temp in _listDiemSo)
            {
                listDiemSoVM.Add(new DiemSoVM()
                {
                    Id = temp.Id,
                    TrongSo = temp.TrongSo,
                    TenDiemSo = temp.TenDiemSo,
                    NgayTao = temp.NgayTao,
                    TrangThai = temp.TrangThai,
                });
            }

            if (obj == null)
            {
                return listDiemSoVM;
            }
            //Tìm kiếm, tìm theo trạng thái, trọng số, tên điểm
            return listDiemSoVM.Where(c => c.TenDiemSo.ToLower().Contains(obj.TenDiemSo.ToLower())
            || c.TrangThai == obj.TrangThai
            || c.TrongSo == obj.TrongSo).ToList();
        }

        public async Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM obj)
        {
            await GetListDiemSopAsync();

            List<DiemSoVM> listDiemSoVM = new List<DiemSoVM>();

            foreach (var temp in _listDiemSo)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listDiemSoVM.Add(new DiemSoVM()
                    {
                        Id = temp.Id,
                        TrongSo = temp.TrongSo,
                        TenDiemSo = temp.TenDiemSo,
                        NgayTao = temp.NgayTao,
                        TrangThai = temp.TrangThai,
                    });
                }
            }

            if (obj == null)
            {
                return listDiemSoVM;
            }
            //Tìm kiếm, tìm theo trạng thái, trọng số, tên điểm
            return listDiemSoVM.Where(c => c.TenDiemSo.ToLower().Contains(obj.TenDiemSo.ToLower())
            || c.TrangThai == obj.TrangThai
            || c.TrongSo == obj.TrongSo).ToList();
        }

        public async Task<DiemSoVM> GetByIdAsync(Guid id)
        {
            await GetListDiemSopAsync();

            DiemSo temp = _listDiemSo.FirstOrDefault(c => c.Id == id);

            DiemSoVM result = new DiemSoVM()
            {
                Id = temp.Id,
                TrongSo = temp.TrongSo,
                TenDiemSo = temp.TenDiemSo,
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
                TenDiemSo = obj.TenDiemSo,
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
            var listDiemSo = await _iDiemSoRepository.GetAllDiemSoAsync();
            if (!listDiemSo.Any(c => c.Id == id)) return false;
            var temp = new DiemSo()
            {
                NgayTao = obj.NgayTao,
                TenDiemSo = obj.TenDiemSo,
                TrongSo = obj.TrongSo,
                TrangThai = obj.TrangThai
            };
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
