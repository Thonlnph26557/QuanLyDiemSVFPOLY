using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenNganhMonHocsController : ControllerBase
    {
        private readonly IChuyenNganhMonHocServices _iChuyenNganhMonHocServices;

        public ChuyenNganhMonHocsController(IChuyenNganhMonHocServices iChuyenNganhMonHocServices)
        {
            _iChuyenNganhMonHocServices = iChuyenNganhMonHocServices;
        }

       
    }
}
