using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using QLDSVFPOLY.DAL.Repositories.Implements;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Implements
{
    public class GiangVienServices : IGiangVienServices
    {
        //
        IGiangVienRepositories _iGiangVienRepositories;

        List<GiangVien> _listGiangViens;


        //
        public GiangVienServices()
        {
            _iGiangVienRepositories = new GiangVienRepositories();
        }

        //
        private async Task GetListGiangVienAsync()
        {
            _listGiangViens = await _iGiangVienRepositories.GetAllAsync();
        }
        //
        public async Task<List<GiangVienViewmodel>> GetAllAsync(GiangVienSearchViewmodel obj)
        {
            await GetListGiangVienAsync();

            List<GiangVienViewmodel> listGiangVienViewmodel = new List<GiangVienViewmodel>();

            foreach (var temp in _listGiangViens)
            {
                listGiangVienViewmodel.Add(new GiangVienViewmodel()
                {
                    Id = temp.Id,
                    IdDaoTao = temp.IdDaoTao,
                    Ma = temp.Ma,
                    Ho = temp.Ho,
                    TenDem = temp.TenDem,
                    Ten = temp.Ten,
                    GioiTinh = temp.GioiTinh,
                    NgaySinh = temp.NgaySinh,
                    DiaChi = temp.DiaChi,
                    SoDienThoai = temp.SoDienThoai,
                    Email = temp.Email,
                    TenDangNhap = temp.TenDangNhap,
                    MatKhau = temp.MatKhau,
                    DuongDanAnh = temp.DuongDanAnh,
                    NgayTao = temp.NgayTao,
                    TrangThai = temp.TrangThai
                });
            }

            if (obj == null)
            {
                return listGiangVienViewmodel;
            }
            //Tìm kiếm, tôi chỉ tìm theo Mã trc
            return listGiangVienViewmodel.Where(c => c.Ma == obj.Ma).ToList();
        }

        //
        //Active = (TrangThai != 0)
        public async Task<List<GiangVienViewmodel>> GetAllActiveAsync(GiangVienSearchViewmodel obj)
        {
            await GetListGiangVienAsync();

            List<GiangVienViewmodel> listGiangVienViewmodel = new List<GiangVienViewmodel>();


            foreach (var temp in _listGiangViens)
            {
                //Kiểm tra TrangThai
                if (temp.TrangThai != 0)
                {
                    listGiangVienViewmodel.Add(new GiangVienViewmodel()
                    {
                        Id = temp.Id,
                        IdDaoTao = temp.IdDaoTao,
                        Ma = temp.Ma,
                        Ho = temp.Ho,
                        TenDem = temp.TenDem,
                        Ten = temp.Ten,
                        GioiTinh = temp.GioiTinh,
                        NgaySinh = temp.NgaySinh,
                        DiaChi = temp.DiaChi,
                        SoDienThoai = temp.SoDienThoai,
                        Email = temp.Email,
                        TenDangNhap = temp.TenDangNhap,
                        MatKhau = temp.MatKhau,
                        DuongDanAnh = temp.DuongDanAnh,
                        NgayTao = temp.NgayTao,
                        TrangThai = temp.TrangThai
                    });
                }
            }

            if (obj == null)
            {
                return listGiangVienViewmodel;
            }
            //Tìm kiếm, tôi chỉ tìm theo Mã trc
            return listGiangVienViewmodel.Where(c => c.Ma == obj.Ma).ToList();
        }

        //
        public async Task<GiangVienViewmodel> GetByIdAsync(Guid id)
        {
            await GetListGiangVienAsync();

            GiangVien temp = _listGiangViens.FirstOrDefault(c => c.Id == id);

            GiangVienViewmodel result = new GiangVienViewmodel()
            {
                Id = temp.Id,
                IdDaoTao = temp.IdDaoTao,
                Ma = temp.Ma,
                Ho = temp.Ho,
                TenDem = temp.TenDem,
                Ten = temp.Ten,
                GioiTinh = temp.GioiTinh,
                NgaySinh = temp.NgaySinh,
                DiaChi = temp.DiaChi,
                SoDienThoai = temp.SoDienThoai,
                Email = temp.Email,
                TenDangNhap = temp.TenDangNhap,
                MatKhau = temp.MatKhau,
                DuongDanAnh = temp.DuongDanAnh,
                NgayTao = temp.NgayTao,
                TrangThai = temp.TrangThai
            };

            return result;
        }

        //
        public async Task<bool> CreateAsync(GiangVienCreateViewmodel obj)
        {
            var temp = new GiangVien()
            {
                Id = Guid.NewGuid(),
                Ma = obj.Ma,
                Ho = obj.Ho,
                TenDem = obj.TenDem,
                Ten = obj.Ten,
                GioiTinh = obj.GioiTinh,
                NgaySinh = obj.NgaySinh,
                DiaChi = obj.DiaChi,
                SoDienThoai = obj.SoDienThoai,
                Email = obj.Email,
                TenDangNhap = obj.TenDangNhap,
                MatKhau = obj.MatKhau,
                DuongDanAnh = obj.DuongDanAnh,
                TrangThai = obj.TrangThai
            };

            await _iGiangVienRepositories.CreateAsync(temp);
            await _iGiangVienRepositories.SaveChangesAsync();

            var _listGiangViens = await _iGiangVienRepositories.GetAllAsync();
            if (_listGiangViens.Any(c => temp.Id == c.Id)) return true;

            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, GiangVienUpdateViewmodel obj)
        {
            var _listGiangViens = await _iGiangVienRepositories.GetAllAsync();

            if (!_listGiangViens.Any(c => c.Id == id)) return false;

            var temp = _listGiangViens.FirstOrDefault(temp => temp.Id == id);

                temp.Ma = obj.Ma;
                temp.Ho = obj.Ho;
                temp.TenDem = obj.TenDem;
                temp.Ten = obj.Ten;
                temp.GioiTinh = obj.GioiTinh;
                temp.NgaySinh = obj.NgaySinh;
                temp.DiaChi = obj.DiaChi;
                temp.SoDienThoai = obj.SoDienThoai;
                temp.MatKhau = obj.MatKhau;
                temp.DuongDanAnh = obj.DuongDanAnh;
                temp.TrangThai = obj.TrangThai;

            await _iGiangVienRepositories.UpdateAsync(temp);
            await _iGiangVienRepositories.SaveChangesAsync();

            return true;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var _listGiangViens = await _iGiangVienRepositories.GetAllAsync();

            if (!_listGiangViens.Any(c => c.Id == id)) return false;

            await _iGiangVienRepositories.RemoveAsync(id);
            await _iGiangVienRepositories.SaveChangesAsync();

            return true;
        }


    }
}
