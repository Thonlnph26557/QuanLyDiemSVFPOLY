using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client.Extensions.Msal;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.DAL.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLDSVFPOLY.Blazor.Pages.GiangVien
{
    public partial class HienThiGiangVien
    {
        //
        [Parameter]
        public string idDaoTao { get; set; }

        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private IGiangVienRepos giangVienRepos { set; get; }

        [Inject] private NavigationManager navigationManager { get; set; }


        // Khai báo
        private List<GiangVienVM> _listGiangViens;

        private GiangVienSearchVM _search = new GiangVienSearchVM();

        // Xóa = id
        private Guid IdDelete { get; set; }

        //Ghi đè phương thức OnInitializedAsync
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = await _SStorage.GetItemAsync<string>("IdDaoTao");
            await LoadData();
        }


        //
        private async Task LoadData()
        {
            _listGiangViens = await giangVienRepos.GetAllActiveAsync(_search);

            _listGiangViens = _listGiangViens.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();
        }

        //
        public string Ma { get; set; }
        public string Ho { get; set; }
        public string TenDem { get; set; }
        public string Ten { get; set; }
        public int GioiTinh { get; set; }

        public DateTime NgaySinh = DateTime.Now;
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string DuongDanAnh { get; set; }
        public int TrangThai { get; set; } = 1;


        //
        private async Task LamMoi()
        {
            Ma = null;
            Ho = null;
            Ten = null;
            TenDem = null;
            NgaySinh = DateTime.Now;
            GioiTinh = 0;
            DiaChi = null;
            Email = null;
            SoDienThoai = null;
            DuongDanAnh = null;
            TrangThai = 1;
        }


        //
        public async Task OnDeleteGiangVien(bool y)
        {
            if (y)
            {
                await giangVienRepos.RemoveAsync(idDeleted);
                await LoadData();

                bool x = await giangVienRepos.RemoveAsync(idDeleted);

                if (x)
                {
                    ToastService.ShowSuccess($"Xóa thành công");
                }
                else
                {
                    ToastService.ShowError($"Xóa thất bại");
                }

            }
            LamMoi();
        }

        //
        private void NavigationChiTiet(Guid idGiangVien)
        {
            navigationManager.NavigateTo($"/giangvien/chitiet/{idGiangVien}");
        }

        //
        private void NavigationThemMoi()
        {
            navigationManager.NavigateTo($"/giangvien/themmoi");
        }

    }
}
