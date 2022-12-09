using Microsoft.AspNetCore.Components;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Pages.GiangVien
{
    public partial class ChiTietGiangVien
    {
        //
        [Parameter]
        public string idDaoTao { get; set; }

        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private IGiangVienRepos giangVienRepos { set; get; }

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
            var giangVien = await giangVienRepos.GetByIdAsync(Guid.Parse(idGiangVien));
            updateVM.IdDaoTao = giangVien.IdDaoTao;
            updateVM.Ma = giangVien.Ma;
            updateVM.Ho = giangVien.Ho;
            updateVM.TenDem = giangVien.TenDem;
            updateVM.Ten = giangVien.Ten;
            updateVM.GioiTinh = giangVien.GioiTinh;
            updateVM.NgaySinh = giangVien.NgaySinh;
            updateVM.DiaChi = giangVien.DiaChi;
            updateVM.Email = giangVien.Email;
            updateVM.SoDienThoai = giangVien.SoDienThoai;
            updateVM.DuongDanAnh = giangVien.DuongDanAnh;
            //updateVM.MatKhau = giangVien.MatKhau;
            //updateVM.tendangnhap = giangVien.TenDangNhap;
            updateVM.TrangThai = giangVien.TrangThai;

        }


    }
}
