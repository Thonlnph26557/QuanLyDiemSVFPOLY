using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.JSInterop;
using QLDSVFPOLY.Blazor.Repository;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;
using QLDSVFPOLY.DAL.Entities;
using System.Text.Json;

namespace QLDSVFPOLY.Blazor.Pages.NhanVienDaoTao
{
    public partial class ChiTietNhanVienDaoTao
    {
        //
        [Parameter]
        public string idDaoTao { get; set; }

        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private INhanVienDaoTaoRepos nhanVienDaoTaoRepos { set; get; }

        [Inject] private NavigationManager navigationManager { get; set; }


        //Ghi đè phương thức OnInitializedAsync
        protected override async Task OnInitializedAsync()
        {
            idDaoTao = await _SStorage.GetItemAsync<string>("IdDaoTao");
            module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/fileSize.js");
            await LoadData();

            await LoadDataUpdate();
        }

        //
        public async Task LoadDataUpdate()
        {
            var nhanVienDaoTao = await nhanVienDaoTaoRepos.GetByIdAsync(Guid.Parse(idNhanVienDaoTao));
            updateVM.Ma = nhanVienDaoTao.Ma;
            updateVM.Ho = nhanVienDaoTao.Ho;
            updateVM.TenDem = nhanVienDaoTao.TenDem;
            updateVM.Ten = nhanVienDaoTao.Ten;
            updateVM.GioiTinh = nhanVienDaoTao.GioiTinh;
            updateVM.NgaySinh = nhanVienDaoTao.NgaySinh;
            updateVM.DiaChi = nhanVienDaoTao.DiaChi;
            updateVM.Email = nhanVienDaoTao.Email;
            updateVM.SoDienThoai = nhanVienDaoTao.SoDienThoai;
            updateVM.TenDangNhap = nhanVienDaoTao.TenDangNhap;
            updateVM.DuongDanAnh = nhanVienDaoTao.DuongDanAnh;
            updateVM.IdDaoTao = nhanVienDaoTao.IdDaoTao;
            updateVM.MatKhau = nhanVienDaoTao.MatKhau;
            updateVM.TrangThai = nhanVienDaoTao.TrangThai;
            
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
