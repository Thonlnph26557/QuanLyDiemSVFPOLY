using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client.Extensions.Msal;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.Blazor.Pages.SinhVien
{
    public partial class HienThiSinhVien
    {
        //
        [Parameter]
        public string idDaoTao { get; set; }

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

            await LoadData();
        }


        //
        private async Task LoadData()

        {

            _listChuyenNganh = await chuyenNganhRepo.GetAllActiveAsync(_searchVM);

            _listChuyenNganh = _listChuyenNganh.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();



            _listSinhViens = await sinhVienRepos.GetAllActiveAsync(_search);
            //_listSinhViens = _listSinhViens.Where(c => _listChuyenNganh.Any(x => x.Id == c.IdChuyenNganh))

            foreach (var item in _listSinhViens)
            {
                if (_listChuyenNganh.Any(c => c.Id == item.IdChuyenNganh))
                {

                }
                else
                {
                    _listSinhViens.Remove(item);
                }
            }

        }


        //
        public async Task OnDeleteSinhVien(bool y)
        {
            if (y)
            {
                await sinhVienRepos.RemoveAsync(IdDelete);
                await LoadData();


                bool x = await sinhVienRepos.RemoveAsync(IdDelete);

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
        public int TrangThai { get; set; }

        //
        private async Task LamMoi()
        {
            Ma = null;
            Ho = null;
            Ten = null;
            TenDem = null;
            NgaySinh = DateTime.Now;
            GioiTinh = 1;
            DiaChi = null;
            Email = null;
            SoDienThoai = null;
            DuongDanAnh = null;
            TrangThai = 1;
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
