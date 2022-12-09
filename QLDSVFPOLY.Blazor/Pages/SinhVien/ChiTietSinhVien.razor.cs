using Microsoft.AspNetCore.Components;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Pages.SinhVien
{
	public partial class ChiTietSinhVien
	{
        //
        [Parameter]
        public string idDaoTao { get; set; }

        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private ISinhVienRepo sinhVienRepos { set; get; }

        [Inject] private NavigationManager navigationManager { get; set; }


        //Ghi đè phương thức OnInitializedAsync

        //Gọi OnInitializedAsync để lấy dữ liệu.Khi OnInitializedAsync hãy sử dụng từ khóa await vì gọi không đồng bộ:
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = "9D01FB1F-6D12-4B11-9962-871C333E659B";
            await LoadDataUpdate();
            await LoadData();
        }

        //
        public async Task LoadDataUpdate()
        {
            var sinhVien = await sinhVienRepos.GetByIdAsync(Guid.Parse(idSinhVien));
            updateVM.Ma = sinhVien.Ma;
            updateVM.Ho = sinhVien.Ho;
            updateVM.TenDem = sinhVien.TenDem;
            updateVM.Ten = sinhVien.Ten;
            updateVM.GioiTinh = sinhVien.GioiTinh;
            updateVM.NgaySinh = sinhVien.NgaySinh;
            updateVM.DiaChi = sinhVien.DiaChi;
            updateVM.Email = sinhVien.Email;
            updateVM.SoDienThoai = sinhVien.SoDienThoai;
            updateVM.TenDangNhap = sinhVien.TenDangNhap;
            updateVM.DuongDanAnh = sinhVien.DuongDanAnh;
            updateVM.IdChuyenNganh = sinhVien.IdChuyenNganh;
            updateVM.MatKhau = sinhVien.MatKhau;
            updateVM.TrangThai = sinhVien.TrangThai;

        }


    }
}
