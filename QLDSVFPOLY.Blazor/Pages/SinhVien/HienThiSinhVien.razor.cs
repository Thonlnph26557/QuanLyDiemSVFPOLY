using Microsoft.AspNetCore.Components;
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

        //Gọi OnInitializedAsync để lấy dữ liệu.Khi OnInitializedAsync hãy sử dụng từ khóa await vì gọi không đồng bộ:
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = "9D01FB1F-6D12-4B11-9962-871C333E659B";

            await LoadData();
        }

        /*
            B1 : Laays ra list chuyen nganh cua dao tao dua voa idDaoTao lay tu route

            B2 : Lay ra list Sinh Vien cos idChuyenNganh nam trong list chuyen nganh tim duoc 
            
         */



        //
        private async Task LoadData()
        
        {

            _listChuyenNganh = await chuyenNganhRepo.GetAllActiveAsync(_searchVM);

            _listChuyenNganh = _listChuyenNganh.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();



            _listSinhViens = await sinhVienRepos.GetAllActiveAsync(_search);
            //_listSinhViens = _listSinhViens.Where(c => _listChuyenNganh.Any(x => x.Id == c.IdChuyenNganh))

            foreach (var item in _listSinhViens)
            {
                if(_listChuyenNganh.Any(c => c.Id == item.IdChuyenNganh))
                {

                }
                else
                {
                    _listSinhViens.Remove(item);
                }
            }

        }


        //
        public async Task OnDeleteSinhVien(Guid IdDelete)
        {
            await sinhVienRepos.RemoveAsync(IdDelete);
            await LoadData();
        }

        //
        private void NavigationChiTiet(Guid idSinhVien)
        {
            navigationManager.NavigateTo($"/sinhvien/chitiet/{idSinhVien}");
        }

        //
        //
        private void NavigationThemMoi()
        {
            navigationManager.NavigateTo("/sinhvien/themmoi/{idDaoTao}");
        }

    }
}
