using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocsController : ControllerBase
    {
        //
        private readonly IMonHocServices _iMonHocServices;

        //
        public MonHocsController(IMonHocServices monHocServices)
        {
            _iMonHocServices = monHocServices;
        }
    }
}
