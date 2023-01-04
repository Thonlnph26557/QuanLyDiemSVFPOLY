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
        ITaiKhoanServices _iTaiKhoanServices;
        private IConfiguration _config;
        public TaiKhoansController(IConfiguration config)
        {
            _iTaiKhoanServices = new TaiKhoanServices();
            _config = config;
        }
    }
}
