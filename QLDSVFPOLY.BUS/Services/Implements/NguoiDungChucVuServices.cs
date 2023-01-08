using AutoMapper;
using AutoMapper.QueryableExtensions;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NguoiDungChucVu;
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
    public class NguoiDungChucVuServices : INguoiDungChucVuServices
    {
        INguoiDungChucVuRepository _iNguoiDungChucVuRepository;

        List<NguoiDungChucVu> _listNguoiDungChucVus;

        private readonly IMapper _mapper;
        public NguoiDungChucVuServices(IMapper mapper)
        {
            _iNguoiDungChucVuRepository = new NguoiDungChucVuRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        private async Task GetListNguoiDungChucVuAsync()
        {
            _listNguoiDungChucVus = await _iNguoiDungChucVuRepository.GetAllAsync();
        }
        public async Task<bool> CreateAsync(NguoiDungChucVuCreateVM obj)
        {
            var temp = new NguoiDungChucVu()
            {
                IdNguoiDung = Guid.NewGuid(),
                IdChucVu = Guid.NewGuid(),
                NgayTao = obj.NgayTao,
                TrangThai = obj.TrangThai,
            };
            await _iNguoiDungChucVuRepository.CreateAsync(temp);
            await _iNguoiDungChucVuRepository.SaveChangesAsync();

            var listNguoiDungChucVus = await _iNguoiDungChucVuRepository.GetAllAsync();
            if (listNguoiDungChucVus.Any(c => c.IdNguoiDung == temp.IdNguoiDung && c.IdChucVu == temp.IdChucVu)) return true;
            return false;
        }

        public async Task<List<NguoiDungChucVuVM>> GetAllActiveAsync()
        {
            await GetListNguoiDungChucVuAsync();

            List<NguoiDungChucVuVM> listObjectVM = _listNguoiDungChucVus.AsQueryable().ProjectTo<NguoiDungChucVuVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

            return listObjectVM;
        }

        public async Task<List<NguoiDungChucVuVM>> GetAllAsync()
        {
            await GetListNguoiDungChucVuAsync();
            List<NguoiDungChucVuVM> listObjectVM = _listNguoiDungChucVus.AsQueryable().ProjectTo<NguoiDungChucVuVM>(_mapper.ConfigurationProvider).ToList();

            return listObjectVM;
        }

        public async Task<NguoiDungChucVuVM> GetByIdAsync(Guid idNguoiDung,Guid idChucVu)
        {
            await GetListNguoiDungChucVuAsync();
            NguoiDungChucVu temp = _listNguoiDungChucVus.FirstOrDefault(c => c.IdNguoiDung == idNguoiDung && c.IdChucVu == idChucVu);

            NguoiDungChucVuVM objVM = new NguoiDungChucVuVM()
            {
                IdNguoiDung = temp.IdNguoiDung,
                IdChucVu = temp.IdChucVu,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai,
            };
            return objVM;
        }

        public async Task<bool> DeleteAsync(Guid idNguoiDung, Guid idChucVu)
        {
            var _listNguoiDungChucVus = await _iNguoiDungChucVuRepository.GetAllAsync();
            if (!_listNguoiDungChucVus.Any(c => c.IdNguoiDung == idNguoiDung && c.IdChucVu == idChucVu)) return false;
            await _iNguoiDungChucVuRepository.DeleteAsync(idNguoiDung,idChucVu);
            await _iNguoiDungChucVuRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Guid idNguoiDung, Guid idChucVu)
        {
            var _listNguoiDungChucVus = await _iNguoiDungChucVuRepository.GetAllAsync();

            if (!_listNguoiDungChucVus.Any(c => c.IdNguoiDung == idNguoiDung && c.IdChucVu == idChucVu)) return false;

            var temp = _listNguoiDungChucVus.FirstOrDefault(temp => temp.IdNguoiDung == idNguoiDung && temp.IdChucVu == idChucVu);

            temp.TrangThai = 0;
            await _iNguoiDungChucVuRepository.UpdateAsync(temp);
            await _iNguoiDungChucVuRepository.SaveChangesAsync();
            return true;
        }
    }
}
