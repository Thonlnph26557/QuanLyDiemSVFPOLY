using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client.Extensions.Msal;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;

namespace QLDSVFPOLY.Blazor.Pages.NhanVienDaoTao
{
    public partial class HienThiNhanVienDaoTao
    {
        //
        [Parameter]
        public string idDaoTao { get; set; }

        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private INhanVienDaoTaoRepos nhanVienDaoTaoRepos { set; get; }

        [Inject] private NavigationManager navigationManager { get; set; }


        // Khai báo
        private List<NhanVienDaoTaoVM> _listNhanVienDaoTaos;

        private NhanVienDaoTaoSearchVM _search = new NhanVienDaoTaoSearchVM();

        // Xóa = id
        private Guid IdDelete { get; set; }

        //Ghi đè phương thức OnInitializedAsync
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = await _SStorage.GetItemAsync<string>("IdDaoTao"); ;

            await LoadData();

            _Layout.Title = await _SStorage.GetItemAsync<string>("TenHienThi");
            _Layout.Role = await _SStorage.GetItemAsync<string>("ChucVu");

        }


        //
        private async Task LoadData()
        {

            _listNhanVienDaoTaos = await nhanVienDaoTaoRepos.GetAllActiveAsync(_search);

            _listNhanVienDaoTaos = _listNhanVienDaoTaos.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();
        }


        //
        public async Task OnDeleteNhanVienDaoTao(bool y)
        {
            if (y)
            {
                await nhanVienDaoTaoRepos.RemoveAsync(IdDelete);
                await LoadData();


                bool x = await nhanVienDaoTaoRepos.RemoveAsync(IdDelete);

                if (x == true)
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
        private void NavigationChiTiet(Guid idNhanVienDaoTao)
        {
            navigationManager.NavigateTo($"/nhanviendaotao/chitiet/{idNhanVienDaoTao}");

        }

        //
        private void NavigationThemMoi()
        {
            navigationManager.NavigateTo($"/nhanviendaotao/themmoi");
        }
    }
}
