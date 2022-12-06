using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
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
    public class ChiTietDiemSoServices : IChiTietDiemSoServices
    {
        IChiTietDiemSoRepository _iChiTietDiemSoRepository;

        List<ChiTietDiemSo> _listCTDiemSo;


        public ChiTietDiemSoServices()
        {
            _iChiTietDiemSoRepository = new ChiTietDiemSoRepository();
        }

        private async Task GetListCTDiemSoAsync()
        {
            _listCTDiemSo = await _iChiTietDiemSoRepository.GetAllChiTietDiemSoAsync();
        }


        public async Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM obj)
        {
            await GetListCTDiemSoAsync();

            List<ChiTietDiemSoVM> listCTDiemSoVM = _listCTDiemSo.Select(c => new ChiTietDiemSoVM
            {
                IdChiTietLopHoc = c.IdChiTietLopHoc,
                IdSinhVien = c.IdSinhVien,
                IdDiemSo = c.IdDiemSo,
                Diem = c.Diem,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).ToList();

            if (obj.IdChiTietLopHoc == null
                && obj.IdSinhVien == null
                && obj.IdDiemSo == null
                && obj.TrangThai == 0)
            {
                return listCTDiemSoVM;
            }

            return listCTDiemSoVM.Where(c =>
                c.IdChiTietLopHoc == obj.IdChiTietLopHoc
                || c.IdSinhVien == obj.IdSinhVien
                || c.IdDiemSo == obj.IdDiemSo
                || c.TrangThai == obj.TrangThai
                ).ToList();

        }

        public async Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM obj)
        {
            await GetListCTDiemSoAsync();

            List<ChiTietDiemSoVM> listCTDiemSoVM = _listCTDiemSo.Select(c => new ChiTietDiemSoVM
            {
                IdChiTietLopHoc = c.IdChiTietLopHoc,
                IdSinhVien = c.IdSinhVien,
                IdDiemSo = c.IdDiemSo,
                Diem = c.Diem,
                NgayTao = c.NgayTao,
                TrangThai = c.TrangThai
            }).Where(c => c.TrangThai != 0).ToList();

            if (obj.IdChiTietLopHoc == null
                && obj.IdSinhVien == null
                && obj.IdDiemSo == null
                && obj.TrangThai == 0)
            {
                return listCTDiemSoVM;
            }
            return listCTDiemSoVM.Where(c =>
                c.IdChiTietLopHoc == obj.IdChiTietLopHoc
                || c.IdSinhVien == obj.IdSinhVien
                || c.IdDiemSo == obj.IdDiemSo
                || c.TrangThai == obj.TrangThai
                ).ToList();
        }

        public async Task<ChiTietDiemSoVM> GetByIdAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            await GetListCTDiemSoAsync();

            ChiTietDiemSo temp = _listCTDiemSo.FirstOrDefault(c => c.IdDiemSo == idDiemSo
            && c.IdSinhVien == idSinhVien
            && c.IdChiTietLopHoc == idLopHoc);

            ChiTietDiemSoVM result = new ChiTietDiemSoVM()
            {
                IdChiTietLopHoc = idLopHoc,
                IdSinhVien = idSinhVien,
                IdDiemSo = idDiemSo,
                Diem = temp.Diem,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };

            return result;
        }

        public async Task<bool> CreateAsync(ChiTietDiemSoCreateVM obj)
        {
            var temp = new ChiTietDiemSo()
            {
                IdChiTietLopHoc = obj.IdChiTietLopHoc,
                IdSinhVien = obj.IdSinhVien,
                Diem = obj.Diem,
                IdDiemSo = obj.IdDiemSo,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai,
            };
            await _iChiTietDiemSoRepository.CreateAsync(temp);
            await _iChiTietDiemSoRepository.SaveChangesAsync();

            var listCtDiemSo = await _iChiTietDiemSoRepository.GetAllChiTietDiemSoAsync();

            if (listCtDiemSo.Any(c => obj.IdDiemSo == c.IdDiemSo
            && obj.IdSinhVien == c.IdSinhVien
            && obj.IdChiTietLopHoc == c.IdChiTietLopHoc)) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien, ChiTietDiemSoUpdateVM obj)
        {
            await GetListCTDiemSoAsync();

            var temp = _listCTDiemSo.FirstOrDefault(c =>
            c.IdSinhVien == idSinhVien
            && c.IdSinhVien == idSinhVien
            && c.IdChiTietLopHoc == idLopHoc);

            if (temp == null) return false;
            else
            {
                temp.Diem = obj.Diem;
                temp.IdSinhVien = obj.IdSinhVien;
                temp.IdDiemSo = obj.IdDiemSo;
                temp.IdChiTietLopHoc = obj.IdChiTietLopHoc;
            }

            await _iChiTietDiemSoRepository.UpdateAsync(temp);
            await _iChiTietDiemSoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            await GetListCTDiemSoAsync();

            var temp = _listCTDiemSo.FirstOrDefault(c =>
            c.IdSinhVien == idSinhVien
            && c.IdSinhVien == idSinhVien
            && c.IdChiTietLopHoc == idLopHoc);

            temp.TrangThai = 0;

            await _iChiTietDiemSoRepository.SaveChangesAsync();
            return true;
        }
    }
}
