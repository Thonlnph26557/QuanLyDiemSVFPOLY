using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienDaoTaosController : ControllerBase
    {
        //
        private readonly INhanVienDaoTaoServices _iNhanVienDaoTaoServices;
        //
        public NhanVienDaoTaosController(INhanVienDaoTaoServices nhanVienDaoTaoServices)
        {
            _iNhanVienDaoTaoServices = nhanVienDaoTaoServices;
        }
    }
}
