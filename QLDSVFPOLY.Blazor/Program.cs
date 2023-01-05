using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QLDSVFPOLY.Blazor.Data;
using MudBlazor.Services;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.Blazor.Repository.Implements;
using Microsoft.AspNetCore.Components.Authorization;
using QLDSVFPOLY.Blazor.Repository;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Blazored.SessionStorage;
using Blazored.Toast;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//New
builder.Services.AddScoped(c => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7258"),
});
builder.Services.AddMudServices();
builder.Services.AddTransient<IMonHocRepo, MonHocRepo>();
builder.Services.AddTransient<IChuyenNganhRepo, ChuyenNganhRepo>();
builder.Services.AddTransient<IChuyenNganhMonHocRepo, ChuyenNganhMonHocRepo>();
builder.Services.AddTransient<IKiHocRepo, KiHocRepo>();
builder.Services.AddTransient<IMonHocRepo, MonHocRepo>();
builder.Services.AddTransient<ILopHocRepos, LopHocRepos>();
builder.Services.AddTransient<IGiangVienRepo, GiangVienRepo>();
builder.Services.AddTransient<IDiemSoRepo, DiemSoRepo>();
builder.Services.AddTransient<IChiTietLopHocRepo, ChiTietLopHocRepo>();
builder.Services.AddTransient<IChiTietDiemSoRepo, ChiTietDiemSoRepo>();
builder.Services.AddTransient<ITaiKhoanRepo, TaiKhoanRepo>();
builder.Services.AddTransient<ISinhVienRepo, SinhVienRepo>();
builder.Services.AddTransient<IDaoTaoRepo, DaoTaoRepo>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredToast();

//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
