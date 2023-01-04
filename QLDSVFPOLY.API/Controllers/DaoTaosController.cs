using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.DAL.Entities.EF;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaoTaosController : ControllerBase
    {
        //
        private readonly IDaoTaoServices _iDaoTaoServices;
        //
        public DaoTaosController(IDaoTaoServices daoTaoServices)
        {
            _iDaoTaoServices = daoTaoServices;
        }
    }
}
