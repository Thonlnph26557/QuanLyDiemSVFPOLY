using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiHocsController : ControllerBase
    {
        private readonly IKiHocServices _iKiHocServices;
        public KiHocsController()
        {
            _iKiHocServices = new KiHocServices();
        }
    }
}
