using AutoMapper;
using AutoMapper.QueryableExtensions;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChucVu;
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
    public class ChucVuServices : IChucVuServices
    {
        IChucVuRepository _iChucVuRepository;

        List<ChucVu> _listChucVus;

        private readonly IMapper _mapper;
        //
        public ChucVuServices(IMapper mapper)
        {
            _iChucVuRepository = new ChucVuRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        private async Task GetListChucVuAsync()
        {
            _listChucVus = await _iChucVuRepository.GetAllAsync();
        }
        public async Task<bool> CreateAsync(ChucVuCreateVM obj)
        {
            var temp = new ChucVu()
            {
                Id = Guid.NewGuid(),
                Ten = obj.Ten,
                NgayTao = obj.NgayTao,
                TrangThai = obj.TrangThai,
            };
            await _iChucVuRepository.CreateAsync(temp);
            await _iChucVuRepository.SaveChangesAsync();

            var listObjectVM = await _iChucVuRepository.GetAllAsync();
            if (listObjectVM.Any(c => c.Id == temp.Id)) return true;
            return false;
        }

        public async Task<List<ChucVuVM>> GetAllActiveAsync()
        {
            await GetListChucVuAsync();

            List<ChucVuVM> listObjectVM = _listChucVus.AsQueryable().ProjectTo<ChucVuVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

            return listObjectVM;
        }

        public async Task<List<ChucVuVM>> GetAllAsync()
        {
            await GetListChucVuAsync();
            List<ChucVuVM> listObjectVM = _listChucVus.AsQueryable().ProjectTo<ChucVuVM>(_mapper.ConfigurationProvider).ToList();

            return listObjectVM;
        }

        public async Task<ChucVuVM> GetByIdAsync(Guid id)
        {
            try
            {
                await GetListChucVuAsync();
                var obj = _listChucVus.FirstOrDefault(c => c.Id == id);
                var objVM = _mapper.Map<ChucVuVM>(obj);
                return objVM;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var listObjectVM = await _iChucVuRepository.GetAllAsync();

            if (!listObjectVM.Any(c => c.Id == id)) return false;

            var temp = listObjectVM.FirstOrDefault(temp => temp.Id == id);
            temp.TrangThai = 0;

            await _iChucVuRepository.UpdateAsync(temp);
            await _iChucVuRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, ChucVuUpdateVM obj)
        {
            var listObjectVM = await _iChucVuRepository.GetAllAsync();
            if (!listObjectVM.Any(c => c.Id == id)) return false;

            var temp = listObjectVM.FirstOrDefault(temp => temp.Id == id);
            temp.Ten = obj.Ten;
            temp.NgayTao = obj.NgayTao;
            temp.TrangThai = obj.TrangThai;

            await _iChucVuRepository.UpdateAsync(temp);
            await _iChucVuRepository.SaveChangesAsync();
            return true;
        }
    }
}
