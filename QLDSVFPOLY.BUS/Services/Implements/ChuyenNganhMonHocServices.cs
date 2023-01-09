using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
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
    public class ChuyenNganhMonHocServices : IChuyenNganhMonHocServices
    {
        //
        IChuyenNganhMonHocRepository _iChuyenNganhMonHocRepository;

        List<ChuyenNganhMonHoc> _listChuyenNganhMonHocs;

        private readonly IMapper _mapper;

        public ChuyenNganhMonHocServices(IMapper mapper)
        {
            _iChuyenNganhMonHocRepository = new ChuyenNganhMonHocRepository();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private async Task GetListChuyenNganhMonHocAsync()
        {
            _listChuyenNganhMonHocs = await _iChuyenNganhMonHocRepository.GetAllAsync();
        }

        public async Task<List<ChuyenNganhMonHocVM>> GetAllAsync()
        {
            await GetListChuyenNganhMonHocAsync();

            List<ChuyenNganhMonHocVM> listChuyenNganhMonHocVM = _listChuyenNganhMonHocs.AsQueryable().ProjectTo<ChuyenNganhMonHocVM>(_mapper.ConfigurationProvider).ToList();

            return listChuyenNganhMonHocVM;
        }

        public async Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync()
        {
            await GetListChuyenNganhMonHocAsync();

            List<ChuyenNganhMonHocVM> listChuyenNganhMonHocVM = _listChuyenNganhMonHocs.AsQueryable().ProjectTo<ChuyenNganhMonHocVM>(_mapper.ConfigurationProvider).Where(x => x.TrangThai != 0).ToList();

            return listChuyenNganhMonHocVM;
        }

        public async Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            try
            {
                await GetListChuyenNganhMonHocAsync();

                var obj = _listChuyenNganhMonHocs.FirstOrDefault(c => c.IdChuyenNganh == idChuyenNganh);
                var objModel = _mapper.Map<ChuyenNganhMonHocVM>(obj);
                return objModel;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj)
        {
            var temp = new ChuyenNganhMonHoc()
            {
                IdChuyenNganh = obj.IdChuyenNganh,
                IdMonHoc = obj.IdMonHoc,
                NgayTao = obj.NgayTao,
                TrangThai = obj.TrangThai,
            };
            await _iChuyenNganhMonHocRepository.CreateAsync(temp);
            await _iChuyenNganhMonHocRepository.SaveChangesAsync();

            var listChuyenNganhMH = await _iChuyenNganhMonHocRepository.GetAllAsync();

            if (listChuyenNganhMH.Any(c => temp.IdChuyenNganh == c.IdChuyenNganh
            && temp.IdMonHoc == c.IdMonHoc)) return true;
            return false;
        }

        public async Task<bool> UpdateTrangThaiAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var listChuyenNganhMH = await _iChuyenNganhMonHocRepository.GetAllAsync();
            if (!listChuyenNganhMH.Any(c => c.IdChuyenNganh == idChuyenNganh && c.IdMonHoc == idMonHoc)) return false;

            var temp = listChuyenNganhMH.FirstOrDefault(c => c.IdChuyenNganh == idChuyenNganh && c.IdMonHoc == idMonHoc);

            temp.TrangThai = 0;

            await _iChuyenNganhMonHocRepository.UpdateAsync(temp);
            await _iChuyenNganhMonHocRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var listChuyenNganhMH = await _iChuyenNganhMonHocRepository.GetAllAsync();

            if (!listChuyenNganhMH.Any(c => c.IdChuyenNganh == idChuyenNganh
            && c.IdMonHoc == idMonHoc)) return false;

            await _iChuyenNganhMonHocRepository.RemoveAsync(idChuyenNganh, idMonHoc);
            await _iChuyenNganhMonHocRepository.SaveChangesAsync();
            return true;
        }

    }
}
