using Microsoft.AspNetCore.Components;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using Blazored.Toast.Services;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;

namespace QLDSVFPOLY.Blazor.Pages.QuanLiDiemSinhVienTrongLop
{
    public partial class BangDiemSV
    {
        [Parameter]
        public string idChiTietLopHoc { get; set; }
        private int stt = 1;


        [Inject] private IChiTietDiemSoRepo chiTietDiemSoRepo { set; get; }
        [Inject] private IDiemSoRepos diemSoRepo { set; get; }
        [Inject] private IChiTietLopHocRepos chiTietLopHocRepos { set; get; }
        [Inject] private ISinhVienRepo sinhVienRepo { set; get; }
        [Inject] private IMonHocRepo monHocRepo { set; get; }
        [Inject] private ILopHocRepos lopHocRepo { set; get; }
        [Inject] private IToastService toastService { set; get; }


        // Khai báo
        private List<ChiTietDiemSoVM> _listChiTietDiemSos;
        private List<ChiTietDiemSoVM> _listChiTietDiemSoAfterUpdate;
        private List<SinhVienVM> _listSinhViens;
        private List<DiemSoVM> _listDiemSos;
        private List<ChiTietLopHocVM> _listChiTietLopHoc;
        private List<LopHocVM> _listLopHoc;
        private List<MonHocVM> _listMonHoc;


        private DiemSoSearchVM diemSoSearch;
        private SinhVienSearchVM sinhVienSearch;
        private ChiTietDiemSoSearchVM chiTietDSSearch = new ChiTietDiemSoSearchVM();
        private ChiTietLopHocSearchVM chiTietLHSearch = new ChiTietLopHocSearchVM();
        private MonHocSearchVM monSoSearch;
        private LopHocSearchVM lopSoSearch;


        private List<Guid> listIdDiemSo;
        private string MaLop { set; get; }
        private string MaMon { set; get; }
        private string TenMon { set; get; }


        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }


        //
        private async Task LoadData()
        {
            _listChiTietLopHoc = await chiTietLopHocRepos.GetAllActiveAsync(chiTietLHSearch);

            _listDiemSos = await diemSoRepo.GetAllActiveAsync(diemSoSearch);

            // _listDiemSos = _listDiemSos.Where(c => c.IdMonHoc == chiTietLHSearch.IdMonHoc).ToList();
            _listSinhViens = await sinhVienRepo.GetAllActiveAsync(sinhVienSearch);

            _listChiTietDiemSos = await chiTietDiemSoRepo.GetAllActiveAsync(chiTietDSSearch);

            _listChiTietDiemSos = _listChiTietDiemSos.Where(c => c.IdChiTietLopHoc == Guid.Parse(idChiTietLopHoc)).ToList();

            listIdDiemSo = _listChiTietDiemSos.GroupBy(c => c.IdDiemSo).Select(x => x.Key).ToList();

            _listSinhViens = _listSinhViens.Where(c => _listChiTietDiemSos.Any(x => x.IdSinhVien == c.Id)).ToList();

            _listChiTietDiemSoAfterUpdate = _listChiTietDiemSos;
            _listMonHoc = await monHocRepo.GetAllActiveAsync(monSoSearch);

            _listLopHoc = await lopHocRepo.GetAllActiveAsync(lopSoSearch);

            MaLop = _listLopHoc.FirstOrDefault(c => c.Id == (_listChiTietLopHoc.FirstOrDefault(x => x.Id == Guid.Parse(idChiTietLopHoc))).IdLopHoc).Ma;
            MaMon = _listMonHoc.FirstOrDefault(c => c.Id == (_listChiTietLopHoc.FirstOrDefault(x => x.Id == Guid.Parse(idChiTietLopHoc))).IdMonHoc).Ma;
            TenMon = _listMonHoc.FirstOrDefault(c => c.Id == (_listChiTietLopHoc.FirstOrDefault(x => x.Id == Guid.Parse(idChiTietLopHoc))).IdMonHoc).Ten;
        }



        private async Task SaveAsync()
        {
            if (_listChiTietDiemSoAfterUpdate.Any(c => c.Diem < 0 || c.Diem > 10))
            {
                toastService.ShowError($"Hãy nhập điểm hợp lệ(>= 0 và <= 10)");
            }
            else
            {
                var isFullSuccess = true;
                foreach (var item in _listChiTietDiemSoAfterUpdate)
                {
                    var updateVm = new ChiTietDiemSoUpdateVM()
                    {
                        IdSinhVien = item.IdSinhVien,
                        IdChiTietLopHoc = item.IdChiTietLopHoc,
                        IdDiemSo = item.IdDiemSo,
                        Diem = item.Diem,
                    };
                    if (await chiTietDiemSoRepo.UpdateAsync(item.IdDiemSo, item.IdChiTietLopHoc, item.IdSinhVien, updateVm) == false)
                    {
                        isFullSuccess = false;
                    }
                }
                if (isFullSuccess)
                {
                    toastService.ShowSuccess($"Cập nhật điểm thành công");
                }
                await LoadData();
            }
        }

    }
}
