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
        IGiangVienRepository _repoGiangVien;
        IDaoTaoRepository _repoDaoTao;
        ISinhVienRepository _repoSinhVien;
        IChuyenNganhRepository _repoChuyenNganh;

        string TenHienThi = "";
        Guid IdDaoTao;
        Guid Id;

        public TaiKhoanServices()
        {
            _repoDaoTao = new DaoTaoRepository();
            _repoGiangVien = new GiangVienRepository();
            _repoSinhVien = new SinhVienRepository();
            _repoChuyenNganh = new ChuyenNganhRepository();
        }

        public Task<DangNhapVM> DangNhapAsync(DangNhapVM input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(DoiMatKhauVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
