
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangViensController : ControllerBase
    {
        private readonly IGiangVienServices _iGiangVienServices;

        public GiangViensController(IGiangVienServices iGiangVienServices)
        {
            _iGiangVienServices = iGiangVienServices;
        }

    }
}
