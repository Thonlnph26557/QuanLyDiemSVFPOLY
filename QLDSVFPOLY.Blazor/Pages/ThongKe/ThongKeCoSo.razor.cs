using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using Microsoft.AspNetCore.Components;

namespace QLDSVFPOLY.Blazor.Pages.ThongKe
{
    public partial class ThongKeCoSo
    {
        [Parameter]
        public string idDaoTao { set; get; }

        //ChuyenNganh
        [Inject] private IChuyenNganhRepo ChuyenNganhRepo { set; get; }
        private List<ChuyenNganhVM> listChuyenNganhs;
        private ChuyenNganhSearchVM chuyenNganhSearchVm = new ChuyenNganhSearchVM();

        //KiHoc
        [Inject] private ILopHocRepos LopHocRepo { set; get; }
        private List<LopHocVM> listLopHocs;
        private LopHocSearchVM lopHocSearchVm = new LopHocSearchVM();

        //SinhVien
        [Inject] private ISinhVienRepo sinhVienRepo { set; get; }
        private List<SinhVienVM> listSinhViens;
        private SinhVienSearchVM sinhVienSearchVm = new SinhVienSearchVM();
        //GiangVien
        [Inject] private IGiangVienRepos GiangVienRepo { set; get; }
        private List<GiangVienVM> listGiangViens;
        private GiangVienSearchVM giangVienSearchVm = new GiangVienSearchVM();

        private int SinhVienActiveCount { set; get; }
        private int SinhVienNonAcCount { set; get; }
        private int SinhVienDelayCount { set; get; }

        private int ChuyenNganhActiveCount { set; get; }
        private int ChuyenNganhNonAcCount { set; get; }
        private int ChuyenNganhDelayCount { set; get; }


        private int GiangVienActiveCount { set; get; }
        private int GiangVienNonAcCount { set; get; }
        private int GiangVienDelayCount { set; get; }

        private int LopHocActiveCount { set; get; }
        private int LopHocNonAcCount { set; get; }
        private int LopHocDelayCount { set; get; }


        protected override async Task OnInitializedAsync()
        {
            idDaoTao = "9d01fb1f-6d12-4b11-9962-871c333e659b";

            await LoadData();
        }

        private async Task LoadData()
        {
            //ChuyenNganh
            listChuyenNganhs = await ChuyenNganhRepo.GetAllAsync(chuyenNganhSearchVm);
            listChuyenNganhs = listChuyenNganhs.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();
            //LopHoc
            listLopHocs = await LopHocRepo.GetAllAsync(lopHocSearchVm);
            listLopHocs = listLopHocs.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();
            //SinhVien
            listSinhViens = await sinhVienRepo.GetAllAsync(sinhVienSearchVm);
            listSinhViens = listSinhViens.Where(c => listChuyenNganhs.Any(x => x.Id == c.IdChuyenNganh)).ToList();
            //GiangVien
            listGiangViens = await GiangVienRepo.GetAllAsync(giangVienSearchVm);
            listGiangViens = listGiangViens.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();

            //Đếm số lượng có trong cơ sở
            int SinhVienCount = listSinhViens.Count();
            int GiangVienCount = listGiangViens.Count();
            int LopHocCount = listLopHocs.Count();
            int ChuyenNganhCount = listChuyenNganhs.Count();

            //Đếm số lượng còn hoạt động ở trong cơ sở
            SinhVienActiveCount = listSinhViens.Where(x => x.TrangThai == 1).Count();
            GiangVienActiveCount = listGiangViens.Where(x => x.TrangThai == 1).Count();
            LopHocActiveCount = listLopHocs.Where(x => x.TrangThai == 1).Count();
            ChuyenNganhActiveCount = listChuyenNganhs.Where(x => x.TrangThai == 1).Count();

            //Đếm số lượng không hoạt động ở trong cơ sở
            SinhVienNonAcCount = listSinhViens.Where(x => x.TrangThai == 0).Count();
            GiangVienNonAcCount = listGiangViens.Where(x => x.TrangThai == 0).Count();
            LopHocNonAcCount = listLopHocs.Where(x => x.TrangThai == 0).Count();
            ChuyenNganhNonAcCount = listChuyenNganhs.Where(x => x.TrangThai == 0).Count();

            //Đếm số lượng tạm dừng hoạt động ở trong cơ sở
            SinhVienDelayCount = listSinhViens.Where(x => x.TrangThai == 2).Count();
            GiangVienDelayCount = listGiangViens.Where(x => x.TrangThai == 2).Count();
            LopHocDelayCount = listLopHocs.Where(x => x.TrangThai == 2).Count();
            ChuyenNganhDelayCount = listChuyenNganhs.Where(x => x.TrangThai == 2).Count();

        }
    }
}
