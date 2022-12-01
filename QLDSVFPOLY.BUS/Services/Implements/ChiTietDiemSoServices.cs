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
        //IChiTietLopHocRepository _iChiTietLopHocRepository;
        //ISinhVienRepository _iSinhVienRepository;

        List<ChiTietDiemSo> _listCTDiemSo;


        public ChiTietDiemSoServices()
        {
            _iChiTietDiemSoRepository = new ChiTietDiemSoRepository();
            //_iChiTietLopHocRepository = new ChiTietLopHocRepository();
            //_iSinhVienRepository = new SinhVienRepository();
        }
        //public List<ChiTietDiemSoViewModel> GetAll()
        //{
        //    List<ChiTietDiemSoViewModel> _lstNhanVien = new List<ChiTietDiemSoViewModel>();
        //    _lstNhanVien = (from a in _iChiTietDiemSoRepository.GetAll()
        //                    join b in _iSinhVienRepository.GetAll() on a.IdSinhVien equals b.Id
        //                    join c in _iChiTietLopHocRepository.GetAllChiTietLopHoc() on a.IdChiTietLopHoc equals c.Id
        //                    select new ChiTietDiemSoViewModel()
        //                    {
        //                        Diem = a.Diem,
        //                        TrangThai = a.TrangThai,
        //                        NgayTao = a.NgayTao,
        //                        TenLopHocCT = c.LopHoc.Ma,
        //                        TenSinhVien = b.Ten
        //                    }).ToList();

        //    return _lstNhanVien;
        //}

        //public List<ChiTietDiemSoViewModel> GetAll(ChiTietDiemSoSearchViewModel ctDiemSearch)
        //{
        //    if (ctDiemSearch == null) return GetAll();

        //    return GetAll().Where(x => x.Diem == ctDiemSearch.Diem
        //    || x.TrangThai == ctDiemSearch.TrangThai).ToList();
        //}

        private async Task GetListCTDiemSoAsync()
        {
            _listCTDiemSo = await _iChiTietDiemSoRepository.GetAllChiTietDiemSoAsync();
        }


        public async Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM obj)
        {
            await GetListCTDiemSoAsync();

            List<ChiTietDiemSoVM> listCTDiemSoVM = new List<ChiTietDiemSoVM>();

            foreach (var temp in _listCTDiemSo)
            {
                listCTDiemSoVM.Add(new ChiTietDiemSoVM()
                {
                    IdDiemSo = temp.IdDiemSo,
                    IdSinhVien = temp.IdSinhVien,
                    IdChiTietLopHoc = temp.IdChiTietLopHoc,
                    Diem = temp.Diem,
                    NgayTao = temp.NgayTao,
                    TrangThai = temp.TrangThai,
                });
            }

            if (obj == null)
            {
                return listCTDiemSoVM;
            }
            //Tìm kiếm, tìm theo trạng thái, điểm
            return listCTDiemSoVM.Where(c => c.Diem == obj.Diem
            || c.TrangThai == obj.TrangThai).ToList();
        }

        public async Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM obj)
        {
            await GetListCTDiemSoAsync();

            List<ChiTietDiemSoVM> listCTDiemSoVM = new List<ChiTietDiemSoVM>();

            foreach (var temp in _listCTDiemSo)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listCTDiemSoVM.Add(new ChiTietDiemSoVM()
                    {
                        IdDiemSo = temp.IdDiemSo,
                        IdSinhVien = temp.IdSinhVien,
                        IdChiTietLopHoc = temp.IdChiTietLopHoc,
                        Diem = temp.Diem,
                        NgayTao = temp.NgayTao,
                        TrangThai = temp.TrangThai,
                    });
                }
            }

            if (obj == null)
            {
                return listCTDiemSoVM;
            }
            return listCTDiemSoVM.Where(c => c.Diem == obj.Diem
            || c.TrangThai == obj.TrangThai).ToList();
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

        public async Task<bool> CreateAsync(ChiTietDiemSoCreateViewModel obj, Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            obj.IdSinhVien = idSinhVien;
            obj.IdChiTietLopHoc = idLopHoc;
            obj.IdSinhVien = idDiemSo;

            var temp = new ChiTietDiemSo()
            {
                IdChiTietLopHoc = obj.IdChiTietLopHoc,
                IdSinhVien = obj.IdSinhVien,
                Diem = obj.Diem,
                IdDiemSo = obj.IdDiemSo,
                NgayTao = obj.NgayTao,
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
            var listDiemSo = await _iChiTietDiemSoRepository.GetAllChiTietDiemSoAsync();

            if (!listDiemSo.Any(c => c.IdDiemSo == idDiemSo
            && c.IdSinhVien == idSinhVien
            && c.IdChiTietLopHoc == idLopHoc)) return false;

            var temp = new ChiTietDiemSo()
            {
                IdChiTietLopHoc = idLopHoc,
                IdSinhVien = idSinhVien,
                Diem = obj.Diem,
                IdDiemSo = idDiemSo,
                TrangThai = obj.TrangThai
            };
            await _iChiTietDiemSoRepository.UpdateAsync(temp);
            await _iChiTietDiemSoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            var listDiemSo = await _iChiTietDiemSoRepository.GetAllChiTietDiemSoAsync();

            if (!listDiemSo.Any(c => c.IdDiemSo == idDiemSo
            && c.IdSinhVien == idSinhVien
            && c.IdChiTietLopHoc == idLopHoc)) return false;

            await _iChiTietDiemSoRepository.DeleteAsync(idDiemSo, idLopHoc, idSinhVien);
            await _iChiTietDiemSoRepository.SaveChangesAsync();
            return true;
        }
    }
}
