using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IMonHocServices, MonHocServices>();
builder.Services.AddTransient<IChuyenNganhServices, ChuyenNganhServices>();
builder.Services.AddTransient<IChuyenNganhMonHocServices, ChuyenNganhMonHocServices>();
builder.Services.AddTransient<IKiHocServices, KiHocServices>();
builder.Services.AddTransient<IMonHocServices, MonHocServices>();
builder.Services.AddTransient<ILopHocServices, LopHocServices>();
builder.Services.AddTransient<IGiangVienServices, GiangVienServices>();
builder.Services.AddTransient<IDiemSoServices, DiemSoServices>();
builder.Services.AddTransient<IChiTietLopHocServices, ChiTietLopHocServices>();
builder.Services.AddTransient<IChiTietDiemSoServices, ChiTietDiemSoServices>();
builder.Services.AddTransient<ITaiKhoanServices, TaiKhoanServices>();
builder.Services.AddTransient<ISinhVienServices, SinhVienServices>();
builder.Services.AddTransient<INhanVienDaoTaoServices, NhanVienDaoTaoServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
