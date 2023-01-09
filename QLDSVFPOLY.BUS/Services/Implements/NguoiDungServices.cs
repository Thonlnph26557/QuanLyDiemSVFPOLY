using AutoMapper;
using AutoMapper.QueryableExtensions;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NguoiDung;
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
    public class NguoiDungServices : INguoiDungServices
    {
        INguoiDungRepository _iNguoiDungRepository;

        List<NguoiDung> _listNguoiDungs;

        private readonly IMapper _mapper;
        public NguoiDungServices(IMapper mapper)
        {
            _iNguoiDungRepository = new NguoiDungRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        private async Task GetListNguoiDungAsync()
        {
            _listNguoiDungs = await _iNguoiDungRepository.GetAllAsync();
        }
        public async Task<bool> CreateAsync(NguoiDungCreateVM obj)
        {
            var temp = new NguoiDung()
            {
                Id = Guid.NewGuid(),
                Email = obj.Email,
                MatKhau = obj.MatKhau,
                NgayTao = obj.NgayTao,
                TrangThai = obj.TrangThai,
            };
            await _iNguoiDungRepository.CreateAsync(temp);
            await _iNguoiDungRepository.SaveChangesAsync();

            var listObjectVM = await _iNguoiDungRepository.GetAllAsync();
            if (listObjectVM.Any(c => c.Id == temp.Id)) return true;
            return false;
        }

        public async Task<List<NguoiDungVM>> GetAllActiveAsync()
        {
            await GetListNguoiDungAsync();

            List<NguoiDungVM> listObjectVM = _listNguoiDungs.AsQueryable().ProjectTo<NguoiDungVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

            return listObjectVM;
        }

        public async Task<List<NguoiDungVM>> GetAllAsync()
        {
            await GetListNguoiDungAsync();
            List<NguoiDungVM> listObjectVM = _listNguoiDungs.AsQueryable().ProjectTo<NguoiDungVM>(_mapper.ConfigurationProvider).ToList();

            return listObjectVM;
        }

        public async Task<NguoiDungVM> GetByIdAsync(Guid id)
        {
            try
            {
                await GetListNguoiDungAsync();
                var obj = _listNguoiDungs.FirstOrDefault(c => c.Id == id);
                var objVM = _mapper.Map<NguoiDungVM>(obj);
                return objVM;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var listObjectVM = await _iNguoiDungRepository.GetAllAsync();

            if (!listObjectVM.Any(c => c.Id == id)) return false;

            var temp = listObjectVM.FirstOrDefault(temp => temp.Id == id);
            temp.TrangThai = 0;

            await _iNguoiDungRepository.UpdateAsync(temp);
            await _iNguoiDungRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, NguoiDungUpdateVM obj)
        {
            var listObjectVM = await _iNguoiDungRepository.GetAllAsync();

            if (!listObjectVM.Any(c => c.Id == id)) return false;

            var temp = listObjectVM.FirstOrDefault(temp => temp.Id == id);
            temp.Email = obj.Email;
            temp.MatKhau = obj.MatKhau;
            temp.NgayTao = obj.NgayTao;
            temp.TrangThai = obj.TrangThai;

            await _iNguoiDungRepository.UpdateAsync(temp);
            await _iNguoiDungRepository.SaveChangesAsync();
            return true;
        }
    }
}
