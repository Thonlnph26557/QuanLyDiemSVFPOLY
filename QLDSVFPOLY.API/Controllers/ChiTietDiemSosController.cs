using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDiemSosController : ControllerBase
    {
        IChiTietDiemSoServices _iChiTietDiemSoServices;
        public ChiTietDiemSosController()
        {
            _iChiTietDiemSoServices = new ChiTietDiemSoServices();
        }

    }
}
