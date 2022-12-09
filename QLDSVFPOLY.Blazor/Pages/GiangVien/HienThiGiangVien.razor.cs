using Microsoft.AspNetCore.Components;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;

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

        //Gọi OnInitializedAsync để lấy dữ liệu.Khi OnInitializedAsync hãy sử dụng từ khóa await vì gọi không đồng bộ:
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = "9D01FB1F-6D12-4B11-9962-871C333E659B";
            await LoadData();
        }


        //
        private async Task LoadData()
        {
            _listGiangViens = await giangVienRepos.GetAllActiveAsync(_search);

            _listGiangViens = _listGiangViens.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();
        }


        //
        public async Task OnDeleteGiangVien(Guid IdDelete)
        {
            await giangVienRepos.RemoveAsync(IdDelete);
            await LoadData();
        }

        //
        private void NavigationChiTiet(Guid idGiangVien)
        {
            navigationManager.NavigateTo($"/giangvien/chitiet/{idGiangVien}");
        }

        //
        //
        private void NavigationThemMoi()
        {
            navigationManager.NavigateTo($"/giangvien/themmoi/{idDaoTao}");
        }

    }
}
