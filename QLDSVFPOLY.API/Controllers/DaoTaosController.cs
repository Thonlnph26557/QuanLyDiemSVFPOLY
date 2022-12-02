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
        private readonly IDaoTaoServices _daoTaoServices;
        private QLSVDbContext _qLSVDbContext;

        //
        public DaoTaosController(IDaoTaoServices daoTaoServices)
        {
            _daoTaoServices = daoTaoServices;
            _qLSVDbContext = new QLSVDbContext();
        }

        //
        [HttpGet("active")]
        public async Task<IActionResult> GetListDaoTaoList([FromQuery] DaoTaoSearchVM search)
        {
            var objCollection = await _daoTaoServices.GetAllActiveAsync(search);

            if (search.Ma == null 
                && search.DiaChi == null
                && search.SoDienThoai == null
                && search.Email == null
                && search.TrangThai == 0
                )
            {
                objCollection = await _daoTaoServices.GetAllActiveAsync(null);
            }

            return Ok(objCollection);
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDaoTao([FromQuery] DaoTaoSearchVM search)
        {
            var objCollection = await _daoTaoServices.GetAllAsync(search);

            if (search.Ma == null
                && search.DiaChi == null
                && search.SoDienThoai == null
                && search.Email == null
                && search.TrangThai == 0
                )
            {
                objCollection = await _daoTaoServices.GetAllAsync(null);
            }

            return Ok(objCollection);
        }

        //
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDaoTaoListById(Guid IdDaoTao)
        {
            var lecturerModel = await _daoTaoServices.GetByIdAsync(IdDaoTao);
            return Ok(lecturerModel);
        }

        //
        [HttpPost]
        public async Task<IActionResult> CreateDaoTao([FromBody] DaoTaoCreateVM request)
        {
            if (request == null)
                return BadRequest();

            var newRole = await _daoTaoServices.CreateAsync(request);

            return Ok(newRole);
        }

        //
        [HttpPut]
        [Route("{IdDaoTao}")]
        public async Task<IActionResult> UpdateDaoTao(Guid IdDaoTao, [FromBody] DaoTaoUpdateVM request)
        {
            var result = await _daoTaoServices.UpdateAsync(IdDaoTao, request);
            return Ok(result);
        }

        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _daoTaoServices.RemoveAsync(id);
            return Ok(temp);
        }

    }
}
