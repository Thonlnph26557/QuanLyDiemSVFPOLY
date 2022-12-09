//using Microsoft.AspNetCore.Components;
//using QLDSVFPOLY.Blazor.Repository.Interfaces;
//using QLDSVFPOLY.Blazor.Repository.Implements;
//using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
//using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;
//using QLDSVFPOLY.BUS.ViewModels.SinhVien;

//namespace QLDSVFPOLY.Blazor.Pages.ChuyenNganh
//{
//    public partial class ChuyenNganhHienThi
//    {
//        [Parameter]
//        public string idDaoTao { get; set; }


//        //Inject Repo cua ChuyenNganh
//        [Inject] private IChuyenNganhRepo ChuyenNganhRepos { set; get; }

//        //Khai bao ra listChuyenNganh
//        private List<ChuyenNganhVM> listChuyenNganhs;

//        private ChuyenNganhSearchVM searchVM = new ChuyenNganhSearchVM();

//        //lay listChuyenNganhMonHoc
//        [Inject] private IChuyenNganhMonHocRepos ChuyenNganhMonHocRepo { set; get; }

//        //Khai bao ra listChuyenNganh
//        private List<ChuyenNganhMonHocVM> listChuyenNganhMonHocs;

//        private ChuyenNganhMonHocSearchVM searchCNMHVM = new ChuyenNganhMonHocSearchVM();

//        //SinhVien
//        [Inject] private ISinhVienRepo sinhVienRepo { set; get; }

//        //Khai bao ra listChuyenNganh
//        private List<SinhVienVM> listSinhViens;

//        private SinhVienSearchVM searchSV = new SinhVienSearchVM();

//        [Inject] private NavigationManager navigationManager { get; set; }


//        protected override async Task OnInitializedAsync()
//        {
//            idDaoTao = "9d01fb1f-6d12-4b11-9962-871c333e659b";
//            await LoadData();
//        }

//        private async Task LoadData()
//        {
//            listChuyenNganhs = await ChuyenNganhRepos.GetAllActiveAsync(searchVM);
//            listChuyenNganhs = listChuyenNganhs.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();
//            //lay ra list chuyenNganhMH
//            listChuyenNganhMonHocs = await ChuyenNganhMonHocRepo.GetAllActiveAsync(searchCNMHVM);
//            //SinhVien
//            listSinhViens = await sinhVienRepo.GetAllActiveAsync(searchSV);
//            //listSinhViens = listSinhViens.Where(c => c.IdChuyenNganh == Guid.Parse(idDaoTao)).ToList();
//        }

//        public async Task OnDeleteChuyenNganh(Guid deleteId)
//        {
//            await ChuyenNganhRepos.RemoveAsync(deleteId);
//            await LoadData();
//        }

//        private void NavigationChiTiet(Guid idChuyenNganh)
//        {
//            navigationManager.NavigateTo($"/chuyennganh/chitiet/{idChuyenNganh}");
//        }

//        private void NavigationThemMoi()
//        {
//            navigationManager.NavigateTo($"/chuyennganh/themmoi/{idDaoTao}");
//        }
//    }
//}
