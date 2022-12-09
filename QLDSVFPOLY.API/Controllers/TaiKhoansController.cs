using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.ViewModels.TaiKhoan;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.Services.Implements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoansController : ControllerBase
    {
        ITaiKhoanServices _sv;
        private IConfiguration _config;
        public TaiKhoansController(IConfiguration config)
        {
            _sv = new TaiKhoanServices();
            _config = config;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DoiMatKhauVM vm)
        {
            var result = await _sv.UpdateAsync(vm);
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> LoginAsync([FromBody] DangNhapVM vm)
        //{
        //    IActionResult response = Unauthorized();

        //    var user = await XacThucTK(vm);

        //    if (user != null)
        //    {
        //        var gen_token = await GenerateJWToken(user);
        //        response = Ok(new { token = gen_token });
        //        return Ok(new DangNhapResponseVM { user, Token = gen_token });
        //    }
        //    return response;
        //}



        [HttpGet]
        public async Task<IActionResult> DangNhap(string TaiKhoan, string MatKhau, string ChucVu)
        {
            DangNhapVM vm = new DangNhapVM
            {
                TaiKhoan = TaiKhoan,
                MatKhau = MatKhau,
                ChucVu = ChucVu
            };
            IActionResult response = Unauthorized();

            var user = await XacThucTK(vm);
            //user.TenHienThi = "Tenhienthitest";

            if (user != null)
            {
                var gen_token = await GenerateJWToken(user);
                //response = Ok(new {token = gen_token} );
                return Ok(new DangNhapResponseVM { 
                    TenHienThi = user.TenHienThi, 
                    IdDaoTao = user.IdDaoTao,
                    Token = gen_token 
                });
            }
            return response;
        }


        private async Task<DangNhapVM> XacThucTK(DangNhapVM tk)
        {
            DangNhapVM result = await _sv.DangNhapAsync(tk);
            return result;
        }

        private async Task<string> GenerateJWToken(DangNhapVM tk)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                //new Claim(ClaimTypes.Name, tk.TenHienThi),
                new Claim(JwtRegisteredClaimNames.Name, tk.TaiKhoan),
                new Claim(ClaimTypes.Role, tk.ChucVu)
            };

            var token = new JwtSecurityToken
                (
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials
                );
            var EncodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return EncodeToken;
        }
    }
}
