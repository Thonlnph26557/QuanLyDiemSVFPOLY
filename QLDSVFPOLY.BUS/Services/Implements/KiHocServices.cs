using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class KiHocServices : IKiHocServices
    {
        //
        IKiHocRepository _iKiHocRepository;

        List<KiHoc> _listKiHocs;

        private readonly IMapper _mapper;


        //
        public KiHocServices(IMapper mapper)
        {
            _iKiHocRepository = new KiHocRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> CreateAsync(KiHocCreateVM obj)
        {
            var temp = new KiHoc()
            {
                Id = Guid.NewGuid(),
                Ten = obj.Ten,
                NamHoc = obj.NamHoc,
                NgayBatDau = obj.NgayBatDau,
                NgayKetThuc = obj.NgayKetThuc,
                TrangThai = obj.TrangThai,
                NgayTao = DateTime.Now
            };

            await _iKiHocRepository.CreateAsync(temp);
            await _iKiHocRepository.SaveChangesAsync();

            var listKiHocs = await _iKiHocRepository.GetAllAsync();
            if (listKiHocs.Any(c => c.Id == temp.Id)) return true;
            return false;
        }

        public async Task<List<KiHocVM>> GetAllActiveAsync()
        {
            try
            {
                await GetListKiHocAsync();

                List<KiHocVM> listObjectVM = _listKiHocs.AsQueryable().ProjectTo<KiHocVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

                return listObjectVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<KiHocVM>> GetAllAsync()
        {
            try
            {
                await GetListKiHocAsync();

                List<KiHocVM> listObjectVM = _listKiHocs.AsQueryable().ProjectTo<KiHocVM>(_mapper.ConfigurationProvider).ToList();

                return listObjectVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<KiHocVM> GetByIdAsync(Guid id)
        {
            try
            {
                await GetListKiHocAsync();

                var obj = _listKiHocs.FirstOrDefault(c => c.Id == id);
                var objVM = _mapper.Map<KiHocVM>(obj);
                return objVM;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listKiHocs = await _iKiHocRepository.GetAllAsync();

            if (!_listKiHocs.Any(c => c.Id == id)) return false;

            var temp = _listKiHocs.FirstOrDefault(temp => temp.Id == id);

            temp.TrangThai = 0;

            await _iKiHocRepository.UpdateAsync(temp);
            await _iKiHocRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, KiHocUpdateVM obj)
        {
            var _listKiHocs = await _iKiHocRepository.GetAllAsync();

            if (!_listKiHocs.Any(c => c.Id == id)) return false;

            var temp = _listKiHocs.FirstOrDefault(temp => temp.Id == id);

            temp.Ten = obj.Ten;
            temp.NamHoc = obj.NamHoc;
            temp.NgayBatDau = obj.NgayBatDau;
            temp.NgayKetThuc = obj.NgayKetThuc;
            temp.TrangThai = obj.TrangThai;

            await _iKiHocRepository.UpdateAsync(temp);
            await _iKiHocRepository.SaveChangesAsync();

            return true;
        }

        //
        private async Task GetListKiHocAsync()
        {
            _listKiHocs = await _iKiHocRepository.GetAllAsync();
        }
    }
}
