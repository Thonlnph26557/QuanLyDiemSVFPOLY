using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class MonHocServices : IMonHocServices
    {
        //
        IMonHocRepository _iMonHocRepository;
        List<MonHoc> _listMonHocs;

        private readonly IMapper _mapper;

        //
        public MonHocServices(IMapper mapper)
        {
            _iMonHocRepository = new MonHocRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private async Task GetListMonHocAsync()
        {
            _listMonHocs = await _iMonHocRepository.GetAllAsync();
        }

        public async Task<List<MonHocVM>> GetAllAsync()
        {
            await GetListMonHocAsync();

            List<MonHocVM> listMonHocVM = _listMonHocs.AsQueryable().ProjectTo<MonHocVM>(_mapper.ConfigurationProvider).ToList();

            return listMonHocVM;
        }


        public async Task<List<MonHocVM>> GetAllActiveAsync()
        {
            await GetListMonHocAsync();

            List<MonHocVM> listMonHocVM = _listMonHocs.AsQueryable().ProjectTo<MonHocVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

            return listMonHocVM;
        }

        public async Task<MonHocVM> GetByIdAsync(Guid id)
        {
            try
            {
                await GetListMonHocAsync();

                var obj = _listMonHocs.FirstOrDefault(c => c.Id == id);
                var objModel = _mapper.Map<MonHocVM>(obj);
                return objModel;
            }
            catch
            {
                return null;
            }
        }


        public async Task<bool> CreateAsync(MonHocCreateVM obj)
        {
            var temp = new MonHoc()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                Ten = obj.Ten,
                DuongDanAnh = obj.DuongDanAnh,
                NgayTao = DateTime.Now,
                TrangThai = obj.TrangThai,
            };

            await _iMonHocRepository.CreateAsync(temp);
            await _iMonHocRepository.SaveChangesAsync();

            var listMonHoc = await _iMonHocRepository.GetAllAsync();

            if (listMonHoc.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, MonHocUpdateVM obj)
        {
            var listMonHoc = await _iMonHocRepository.GetAllAsync();

            if (!listMonHoc.Any(c => c.Id == id)) return false;

            var temp = listMonHoc.FirstOrDefault(c => c.Id == id);

            temp.Ma = obj.Ma;
            temp.Ten = obj.Ten;
            temp.DuongDanAnh = obj.DuongDanAnh;
            temp.TrangThai = obj.TrangThai;

            await _iMonHocRepository.UpdateAsync(temp);
            await _iMonHocRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateRemoveAsync(Guid id)
        {
            var listMonHoc = await _iMonHocRepository.GetAllAsync();

            if (!listMonHoc.Any(c => c.Id == id)) return false;

            var temp = listMonHoc.FirstOrDefault(c => c.Id == id);

            temp.TrangThai = 0;

            await _iMonHocRepository.UpdateAsync(temp);
            await _iMonHocRepository.SaveChangesAsync();

            return true;
        }


        public async Task<bool> RemoveAsync(Guid id)
        {
            var listMonHoc = await _iMonHocRepository.GetAllAsync();

            if (!listMonHoc.Any(c => c.Id == id)) return false;

            await _iMonHocRepository.RemoveAsync(id);
            await _iMonHocRepository.SaveChangesAsync();

            return true;
        }
    }
}
