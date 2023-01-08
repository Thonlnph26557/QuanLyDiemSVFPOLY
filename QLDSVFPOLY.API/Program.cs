using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using QLDSVFPOLY.BUS.Extensions;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
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
builder.Services.AddTransient<IGiangVienServices, GiangVienServices>();
builder.Services.AddTransient<IDiemSoServices, DiemSoServices>();
builder.Services.AddTransient<IChiTietLopHocServices, ChiTietLopHocServices>();
builder.Services.AddTransient<IChiTietDiemSoServices, ChiTietDiemSoServices>();
builder.Services.AddTransient<ITaiKhoanServices, TaiKhoanServices>();
builder.Services.AddTransient<ISinhVienServices, SinhVienServices>();
builder.Services.AddTransient<IDaoTaoServices, DaoTaoServices>();

//3 bang moi
builder.Services.AddTransient<IChucVuServices, ChucVuServices>();
builder.Services.AddTransient<INguoiDungServices, NguoiDungServices>();
builder.Services.AddTransient<INguoiDungChucVuServices, NguoiDungChucVuServices>();

builder.Services.AddApplication();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
