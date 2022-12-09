using Microsoft.AspNetCore.Components;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Pages.NhanVienDaoTao
{
    public partial class ChiTietNhanVienDaoTao
    {
        //
        [Parameter]
        public string idDaoTao { get; set; }

        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private INhanVienDaoTaoRepos nhanVienDaoTaoRepos { set; get; }

        [Inject] private NavigationManager navigationManager { get; set; }


        //Ghi đè phương thức OnInitializedAsync

        //Gọi OnInitializedAsync để lấy dữ liệu.Khi OnInitializedAsync hãy sử dụng từ khóa await vì gọi không đồng bộ:
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = "10E3933F-66A1-42BE-9E5F-C88BD749E17A";
            await LoadDataUpdate();
            await LoadData();
        }

        //
        public async Task LoadDataUpdate()
        {
            var nhanVienDaoTao = await nhanVienDaoTaoRepos.GetByIdAsync(Guid.Parse(idNhanVienDaoTao));
            updateVM.Ma = nhanVienDaoTao.Ma;
            updateVM.Ho = nhanVienDaoTao.Ho;
            updateVM.TenDem = nhanVienDaoTao.TenDem;
            updateVM.Ten = nhanVienDaoTao.Ten;
            updateVM.GioiTinh = nhanVienDaoTao.GioiTinh;
            updateVM.NgaySinh = nhanVienDaoTao.NgaySinh;
            updateVM.DiaChi = nhanVienDaoTao.DiaChi;
            updateVM.Email = nhanVienDaoTao.Email;
            updateVM.SoDienThoai = nhanVienDaoTao.SoDienThoai;
            updateVM.TenDangNhap = nhanVienDaoTao.TenDangNhap;
            updateVM.DuongDanAnh = nhanVienDaoTao.DuongDanAnh;
            updateVM.IdDaoTao = nhanVienDaoTao.IdDaoTao;
            updateVM.MatKhau = nhanVienDaoTao.MatKhau;
            updateVM.TrangThai = nhanVienDaoTao.TrangThai;

        }

    }
}
