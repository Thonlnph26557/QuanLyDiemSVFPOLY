using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemSosController : ControllerBase
    {
        IDiemSoServices _iDiemSoServices;
        public DiemSosController()
        {
            _iDiemSoServices = new DiemSoServices();
        }
    }
}
