using Microsoft.IdentityModel.Tokens;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.BUS.ViewModels.TaiKhoan;
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
    public class TaiKhoanServices : ITaiKhoanServices
    {
        INhanVienDaoTaoRepository _repoNhanVienDaoTao;
        IGiangVienRepository _repoGiangVien;
        IDaoTaoRepository _repoDaoTao;
        ISinhVienRepository _repoSinhVien;
        IChuyenNganhRepository _repoChuyenNganh;

        string TenHienThi = "";
        Guid IdDaoTao;

        public TaiKhoanServices()
        {
            _repoDaoTao = new DaoTaoRepository();
            _repoGiangVien = new GiangVienRepository();
            _repoNhanVienDaoTao = new NhanVienDaoTaoRepository();
            _repoSinhVien = new SinhVienRepository();
            _repoChuyenNganh = new ChuyenNganhRepository();
        }

        

        private async Task<bool> ValidateAsync(DangNhapVM input)
        {
            switch (input.ChucVu)
            {
                case "DaoTao":
                    {
                        var list = await _repoDaoTao.GetAllAsync();
                        foreach (var i in list)
                        {
                            if (i.TenDangNhap == input.TaiKhoan && i.MatKhau == input.MatKhau)
                            {
                                TenHienThi = i.Ma;
                                IdDaoTao = i.Id;
                                return true;
                            }
                        }
                        break;
                    }
                case "GiangVien":
                    {
                        var list = await _repoGiangVien.GetAllAsync();
                        foreach (var i in list)
                        {
                            if (i.TenDangNhap == input.TaiKhoan && i.MatKhau == input.MatKhau)
                            {
                                TenHienThi = i.Ho + " " + i.TenDem + " " + i.Ten;
                                IdDaoTao = i.IdDaoTao;
                                return true;
                            }
                        }
                        break;
                    }
                case "SinhVien":
                    {
                        var list = await _repoSinhVien.GetAllAsync();
                        foreach (var i in list)
                        {
                            if (i.TenDangNhap == input.TaiKhoan && i.MatKhau == input.MatKhau)
                            {
                                TenHienThi = i.Ho + " " + i.TenDem + " " + i.Ten;
                                List<ChuyenNganh> list_CN = await _repoChuyenNganh.GetAllAsync();
                                IdDaoTao = list_CN.FirstOrDefault(c => c.IdChuyenNganh == i.IdChuyenNganh).IdDaoTao;
                                return true;
                            }
                        }
                        break;
                    }
                case "NhanVienDaoTao":
                    {
                        var list = await _repoNhanVienDaoTao.GetAllAsync();
                        foreach (var i in list)
                        {
                            if (i.TenDangNhap == input.TaiKhoan && i.MatKhau == input.MatKhau)
                            {
                                TenHienThi = i.Ho + " " + i.TenDem + " " + i.Ten;
                                IdDaoTao = i.IdDaoTao;
                                return true;
                            }
                        }
                        break;
                    }
            }
            return false;
        }

        public async Task<DangNhapVM> DangNhapAsync(DangNhapVM input)
        {
            var result = await ValidateAsync(input);
            if (result) return new DangNhapVM
            {
                TenHienThi = (String.IsNullOrEmpty(TenHienThi) ? "Không có" : TenHienThi),
                TaiKhoan = input.TaiKhoan,
                ChucVu = input.ChucVu,
                IdDaoTao = IdDaoTao
            };
            return null;
        }

        public async Task<bool> UpdateAsync(DoiMatKhauVM vm)
        {
            switch(vm.ChucVu)
            {
                case "DaoTao":
                    {
                        var list = await _repoDaoTao.GetAllAsync();
                        var temp = list.FirstOrDefault(c => c.TenDangNhap == vm.TaiKhoan && c.MatKhau == vm.MatKhau);
                        if (temp != null)
                        {
                            temp.MatKhau = vm.MatKhau;
                            return true;
                        }
                        return false;
                    }
                case "GiangVien":
                    {
                        var list = await _repoGiangVien.GetAllAsync();
                        var temp = list.FirstOrDefault(c => c.TenDangNhap == vm.TaiKhoan && c.MatKhau == vm.MatKhau);
                        if (temp != null)
                        {
                            temp.MatKhau = vm.MatKhau;
                            return true;
                        }
                        return false;
                    }
                case "NhanVienDaoTao":
                    {
                        var list = await _repoNhanVienDaoTao.GetAllAsync();
                        var temp = list.FirstOrDefault(c => c.TenDangNhap == vm.TaiKhoan && c.MatKhau == vm.MatKhau);
                        if (temp != null)
                        {
                            temp.MatKhau = vm.MatKhau;
                            return true;
                        }
                        return false;
                    }
                case "SinhVien":
                    {
                        var list = await _repoSinhVien.GetAllAsync();
                        var temp = list.FirstOrDefault(c => c.TenDangNhap == vm.TaiKhoan && c.MatKhau == vm.MatKhau);
                        if (temp != null) {
                            temp.MatKhau = vm.MatKhau;
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }
    }
}
