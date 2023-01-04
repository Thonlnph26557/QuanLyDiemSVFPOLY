using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenNganhsController : ControllerBase
    {
        IChuyenNganhServices _iChuyenNganhServices;
        public ChuyenNganhsController()
        {
            _iChuyenNganhServices = new ChuyenNganhServices();
        }

    }
}
