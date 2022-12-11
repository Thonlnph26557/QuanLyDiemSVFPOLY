using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.JSInterop;
using QLDSVFPOLY.Blazor.Repository;
using QLDSVFPOLY.Blazor.Repository.Implements;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.DAL.Entities;
using System.Text.Json;

namespace QLDSVFPOLY.Blazor.Pages.SinhVien
{
    public partial class ChiTietSinhVien
    {
        //
        [Parameter]
        public string idDaoTao { get; set; }

        // Inject
        [Inject] private HttpClient _httpClient { get; set; }

        [Inject] private ISinhVienRepo sinhVienRepos { set; get; }

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
            var sinhVien = await sinhVienRepos.GetByIdAsync(Guid.Parse(idSinhVien));
            updateVM.Ma = sinhVien.Ma;
            updateVM.Ho = sinhVien.Ho;
            updateVM.TenDem = sinhVien.TenDem;
            updateVM.Ten = sinhVien.Ten;
            updateVM.GioiTinh = sinhVien.GioiTinh;
            updateVM.NgaySinh = sinhVien.NgaySinh;
            updateVM.DiaChi = sinhVien.DiaChi;
            updateVM.Email = sinhVien.Email;
            updateVM.SoDienThoai = sinhVien.SoDienThoai;
            // updateVM.TenDangNhap = sinhVien.TenDangNhap;
            updateVM.DuongDanAnh = sinhVien.DuongDanAnh;
            updateVM.IdChuyenNganh = sinhVien.IdChuyenNganh;
            //updateVM.MatKhau = sinhVien.MatKhau;
            updateVM.TrangThai = sinhVien.TrangThai;

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
