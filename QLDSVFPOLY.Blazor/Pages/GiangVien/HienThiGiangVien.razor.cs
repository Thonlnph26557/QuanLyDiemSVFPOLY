using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client.Extensions.Msal;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.Blazor.Shared;
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


        [CascadingParameter]
        public QLDSVLayout _Layout { get; set; }

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
            _Layout.Title = await _SStorage.GetItemAsync<string>("TenHienThi");
            _Layout.Role = await _SStorage.GetItemAsync<string>("ChucVu");
            stt = 1;
        }


        //
        private async Task LoadData()
        {
            _listGiangViens = await giangVienRepos.GetAllActiveAsync(_search);

            _listGiangViens = _listGiangViens.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();
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
            stt = 1;
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
