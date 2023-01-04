using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietLopHocsController : ControllerBase
    {
        private readonly IChiTietLopHocServices _iChiTietLopHocServices;

        public ChiTietLopHocsController(IChiTietLopHocServices iChiTietLopHocServices)
        {
            _iChiTietLopHocServices = iChiTietLopHocServices;
        }
    }
}
