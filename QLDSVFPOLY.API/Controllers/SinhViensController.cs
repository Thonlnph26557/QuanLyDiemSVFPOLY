using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.DAL.Entities.EF;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        //
        private readonly ISinhVienServices _iSinhVienServices;

        //
        public SinhViensController(ISinhVienServices sinhVienServices)
        {
            _iSinhVienServices = sinhVienServices;
        }
    }
}
