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
        private readonly INhanVienDaoTaoServices _iNhanVienDaoTaoServices;
        public NhanVienDaoTaosController(INhanVienDaoTaoServices nhanVienDaoTaoServices)
        {
            _iNhanVienDaoTaoServices = nhanVienDaoTaoServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllNhanVienDaoTao([FromQuery] NhanVienDaoTaoSearchVM searchVm)
        {
            var listNhanVienDaoTaoSearch = await _iNhanVienDaoTaoServices.GetAllAsync(searchVm);
            return Ok(listNhanVienDaoTaoSearch);
        }

        //lấy ra danh sách giảng viên còn hoạt động kết hợp tìm kiếm
        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllNhanVienDaoTaoActive([FromQuery] NhanVienDaoTaoSearchVM searchVm)
        {
            var listNhanVienDaoTaoSearch = await _iNhanVienDaoTaoServices.GetAllActiveAsync(searchVm);

            return Ok(listNhanVienDaoTaoSearch);
        }

        //GetById ??? 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetNhanVienDaoTaoById(Guid id)
        {
            var nhanVienDaoTao = await _iNhanVienDaoTaoServices.GetByIdAsync(id);
            return Ok(nhanVienDaoTao);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateNhanVienDaoTao([FromBody] NhanVienDaoTaoCreateVM nhanVienDaoTao)
        {
            if (nhanVienDaoTao == null)
                return BadRequest();

            var newNhanVienDaoTao = await _iNhanVienDaoTaoServices.CreateAsync(nhanVienDaoTao);

            return Ok(newNhanVienDaoTao);
        }

        //Controller dc gọi khi update obj
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateNhanVienDaoTao(Guid id, [FromBody] NhanVienDaoTaoUpdateVM nhanVienDaoTao)
        {
            var result = await _iNhanVienDaoTaoServices.UpdateAsync(id, nhanVienDaoTao);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteNhanVienDaoTao(Guid id)
        {
            var result = await _iNhanVienDaoTaoServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
