using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.JSInterop;
using QLDSVFPOLY.Blazor.Repository;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.Utilities;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.DAL.Entities;
using System.Text.Json;

namespace QLDSVFPOLY.Blazor.Pages.GiangVien
{
    public partial class ChiTietGiangVien
    {

        [Parameter]
        public string idGiangVien { set; get; }

        [Parameter]
        public string idDaoTao { set; get; }


        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private IGiangVienRepos giangVienRepos { set; get; }

        [Inject] private NavigationManager navigationManager { get; set; }

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

        //Ghi đè phương thức OnInitializedAsync

        //Gọi OnInitializedAsync để lấy dữ liệu.Khi OnInitializedAsync hãy sử dụng từ khóa await vì gọi không đồng bộ:
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = await _SStorage.GetItemAsync<string>("IdDaoTao");

            await LoadData();
            await LoadDataUpdate();
            obj = _listGiangViens.FirstOrDefault(c => c.Id == Guid.Parse(idGiangVien));
            module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/fileSize.js");

        }

        //
        public async Task LoadDataUpdate()
        {
            var giangVien = await giangVienRepos.GetByIdAsync(Guid.Parse(idGiangVien));
            updateVM.IdDaoTao = giangVien.IdDaoTao;
            updateVM.Ma = giangVien.Ma;
            updateVM.Ho = giangVien.Ho;
            updateVM.TenDem = giangVien.TenDem;
            updateVM.Ten = giangVien.Ten;
            updateVM.GioiTinh = giangVien.GioiTinh;
            updateVM.NgaySinh = giangVien.NgaySinh;
            updateVM.DiaChi = giangVien.DiaChi;
            updateVM.Email = giangVien.Email;
            updateVM.SoDienThoai = giangVien.SoDienThoai;
            updateVM.DuongDanAnh = giangVien.DuongDanAnh;
            //updateVM.MatKhau = giangVien.MatKhau;
            //updateVM.tendangnhap = giangVien.TenDangNhap;
            updateVM.TrangThai = 1;

        }
        private GiangVienUpdateVM updateVM = new();

        //
        private Utility utility = new Utility();

        private async Task ChinhSua(bool y)
        {
            if (utility.CheckMa(Ma))
            {

                if (y)
                {
                    await giangVienRepos.UpdateAsync(Guid.Parse(idGiangVien), updateVM);

                    await LoadData();

                    bool x = await giangVienRepos.UpdateAsync(Guid.Parse(idGiangVien), updateVM);

                    if (x == true)
                    {
                        navigationManager.NavigateTo("/giangvien/hienthi");
                        ToastService.ShowSuccess($"Sửa thành công");
                    }
                    else
                    {
                        ToastService.ShowError($"Sửa thất bại");
                    }

                }
            }
            else
            {
                ToastService.ShowError($"Trường này không chứa ký tự đặc biệt");
            }
            LamMoi();
        }


        // Khai báo
        private GiangVienVM obj;

        private List<GiangVienVM> _listGiangViens;

        private GiangVienSearchVM _search = new GiangVienSearchVM();

        //
        private async Task LoadData()
        {
            _listGiangViens = await giangVienRepos.GetAllActiveAsync(_search);

            _listGiangViens = _listGiangViens.Where(c => c.IdDaoTao == Guid.Parse(idDaoTao)).ToList();


        }

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


        DefaultImages defImg = new DefaultImages();
        IJSObjectReference module;
        record ImageDimensions(int Width, int Height);
        private async Task OnInputFileChanged(InputFileChangeEventArgs e)
        {
            var file = e.File;
            var streamRef = new DotNetStreamReference(file.OpenReadStream(file.Size));
            var json = await module.InvokeAsync<string>("getImageDimensions", streamRef);
            var dimensions = JsonSerializer.Deserialize<ImageDimensions>(json);
            if (dimensions.Width > 250)
            {
                file = await file.RequestImageFileAsync(file.ContentType, 250, int.MaxValue);
            }
            var buffers = new byte[file.Size];
            await file.OpenReadStream().ReadAsync(buffers);
            string imageType = file.ContentType;
            updateVM.DuongDanAnh = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }

    }
}
