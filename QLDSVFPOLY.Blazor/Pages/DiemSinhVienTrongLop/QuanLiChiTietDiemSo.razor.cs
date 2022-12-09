using Microsoft.AspNetCore.Components;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLDSVFPOLY.Blazor.Pages.QuanLiDiemSinhVienTrongLop
{
    public partial class QuanLiChiTietDiemSo
    {

        //
        [Parameter]
        public string idDaoTao { get; set; }

        [Parameter]

        public string idChiTietLopHoc { get; set; }

        [Parameter]

        public string idDiemSo { get; set; }

        [Parameter]

        public string idSinhVien { get; set; }


        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private IChiTietDiemSoRepo chiTietDiemSoRepo { set; get; }
        [Inject] private IDiemSoRepos diemSoRepo { set; get; }


        // Khai báo
        private List<ChiTietDiemSoVM> _listChiTietDiemSos;

        private List<SinhVienVM> _listSinhViens;

        private List<DiemSoVM> _listDiemSos;

        private List<ChiTietLopHocVM> _listChiTietLopHocVM;
        private List<DiemSoVM> _listDiemSoVMl;
        private List<SinhVienVM> _listSinhVienVM;

        private ChiTietLopHocVM _chiTietLopHocVM;
        private DiemSoVM _diemSoVM;
        private SinhVienVM _sinhVienVM;

        private ChiTietDiemSoSearchVM _search = new ChiTietDiemSoSearchVM();
        private ChiTietLopHocSearchVM _search1 = new ChiTietLopHocSearchVM();


        //Ghi đè phương thức OnInitializedAsync

        //Gọi OnInitializedAsync để lấy dữ liệu.Khi OnInitializedAsync hãy sử dụng từ khóa await vì gọi không đồng bộ:
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = "9D01FB1F-6D12-4B11-9962-871C333E659B";
            idChiTietLopHoc = "7C9DFD21-0C6F-41F0-8EB4-921D0C1C025F";
            idDiemSo = "A131A50B-C9E2-4CAA-A579-4945A2B3357A";
            idSinhVien = "F5C02259-46DB-4C60-9FA9-3CF85C570F78";

            await LoadData();
            await LoadDataUpdate();

            _chiTietLopHocVM = _listChiTietLopHocVM.FirstOrDefault(c => c.Id == Guid.Parse(idChiTietLopHoc));
            _diemSoVM = _listDiemSoVMl.FirstOrDefault(c => c.Id == Guid.Parse(idDiemSo));
            _sinhVienVM = _listSinhVienVM.FirstOrDefault(c => c.Id == Guid.Parse(idSinhVien));
        }


        //
        private async Task LoadData()
        {

            _listDiemSos = await diemSoRepo.GetAllActiveAsync(new DiemSoSearchVM());

            _listDiemSos = _listDiemSos.Where(c => c.IdMonHoc == _chiTietLopHocVM.IdMonHoc).ToList();


            _listChiTietDiemSos = await chiTietDiemSoRepo.GetAllActiveAsync(_search);

            _listChiTietDiemSos = _listChiTietDiemSos.Where(c => c.IdChiTietLopHoc == Guid.Parse(idChiTietLopHoc)).ToList();

        }

        private ChiTietDiemSoUpdateVM updateVM = new();


        //
        public async Task LoadDataUpdate()
        {
            var diemSo = await chiTietDiemSoRepo.GetByIdAsync(Guid.Parse(idChiTietLopHoc), Guid.Parse(idDiemSo), Guid.Parse(idSinhVien));
            
            updateVM.IdChiTietLopHoc = diemSo.IdChiTietLopHoc;
            updateVM.IdSinhVien = diemSo.IdSinhVien;
            updateVM.IdDiemSo = diemSo.IdDiemSo;
            updateVM.Diem = diemSo.Diem;
            updateVM.TrangThai = diemSo.TrangThai;
        }


        //
        private async Task ChinhSua(Guid idChiTietLopHoc, ChiTietDiemSoUpdateVM updateVM)
        {
            await chiTietDiemSoRepo.UpdateAsync(idChiTietLopHoc, updateVM);
        }

    }
}
