using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client.Extensions.Msal;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.Blazor.Shared;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.Blazor.Pages.SinhVien
{
    public partial class HienThiSinhVien
    {
        //
        [Parameter]
        public string idDaoTao { get; set; }
        [CascadingParameter]
        public QLDSVLayout _Layout { get; set; }
        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private ISinhVienRepo sinhVienRepos { set; get; }

        [Inject] private IChuyenNganhRepo chuyenNganhRepo { set; get; }

        [Inject] private NavigationManager navigationManager { get; set; }


        // Khai báo
        private List<SinhVienVM> _listSinhViens;

        private SinhVienSearchVM _search = new SinhVienSearchVM();

        private ChuyenNganhVM obj;

        private List<ChuyenNganhVM> _listChuyenNganh;

        private ChuyenNganhSearchVM _searchVM = new ChuyenNganhSearchVM();


        // Xóa = id
        private Guid IdDelete { get; set; }

        //Ghi đè phương thức OnInitializedAsync
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = await _SStorage.GetItemAsync<string>("IdDaoTao");
            _Layout.Title = await _SStorage.GetItemAsync<string>("TenHienThi");
            _Layout.Role = await _SStorage.GetItemAsync<string>("ChucVu");
            stt = 1;

            await LoadData();

        }


        //
        private async Task LoadData()

        {
            _listChuyenNganh = await chuyenNganhRepo.GetAllActiveAsync(_searchVM);

            _listChuyenNganh = _listChuyenNganh.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();



            _listSinhViens = await sinhVienRepos.GetAllActiveAsync(_search);
            //_listSinhViens = _listSinhViens.Where(c => _listChuyenNganh.Any(x => x.Id == c.IdChuyenNganh))

        }


        //
        public async Task OnDeleteSinhVien(bool y)
        {
            if (y)
            {
                await sinhVienRepos.RemoveAsync(idDeleted);
                await LoadData();


                bool x = await sinhVienRepos.RemoveAsync(idDeleted);

                if (x == true)
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
        private void NavigationChiTiet(Guid idSinhVien)
        {
            navigationManager.NavigateTo($"/sinhvien/chitiet/{idSinhVien}");
        }

        //
        private void NavigationThemMoi()
        {
            navigationManager.NavigateTo($"/sinhvien/themmoi/{idDaoTao}");
        }

    }
}
