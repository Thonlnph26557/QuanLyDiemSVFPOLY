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

        //lấy ra danh sách đào tạo còn hoạt động kết hợp tìm kiếm
        [HttpGet("active")]
        public async Task<IActionResult> GetAllDaoTaoActive([FromQuery] DaoTaoSearchVM search)
        {
            var listDaoTaoSearch = await _daoTaoServices.GetAllActiveAsync(search);

            if (search.Ma == null 
                && search.DiaChi == null
                && search.SoDienThoai == null
                && search.Email == null
                && search.TrangThai == 0
                )
            {
                listDaoTaoSearch = await _daoTaoServices.GetAllActiveAsync(null);
            }

            return Ok(listDaoTaoSearch);
        }

        //
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDaoTao([FromQuery] DaoTaoSearchVM search)
        {
            var listDaoTaoSearch = await _daoTaoServices.GetAllAsync(search);

            if (search.Ma == null
                && search.DiaChi == null
                && search.SoDienThoai == null
                && search.Email == null
                && search.TrangThai == 0
                )
            {
                listDaoTaoSearch = await _daoTaoServices.GetAllAsync(null);
            }

            return Ok(listDaoTaoSearch);
        }

        // GetById ??? 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDaoTaoById(Guid IdDaoTao)
        {
            var daoTao = await _daoTaoServices.GetByIdAsync(IdDaoTao);
            return Ok(daoTao);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateDaoTao([FromBody] DaoTaoCreateVM daoTao)
        {
            if (daoTao == null)
                return BadRequest();

            var newDaoTao = await _daoTaoServices.CreateAsync(daoTao);

            return Ok(newDaoTao);
        }

        //Controller dc gọi khi update obj
        [HttpPut]
        [Route("{IdDaoTao}")]
        public async Task<IActionResult> UpdateDaoTao(Guid IdDaoTao, [FromBody] DaoTaoUpdateVM daoTao)
        {
            var result = await _daoTaoServices.UpdateAsync(IdDaoTao, daoTao);
            return Ok(result);
        }

        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _daoTaoServices.UpdateRemoveAsync(id);
            return Ok(temp);
        }

    }
}
