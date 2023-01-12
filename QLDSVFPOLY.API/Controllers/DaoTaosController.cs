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
        //lấy ra danh sách đào tạo còn hoạt động kết hợp tìm kiếm
        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iDaoTaoServices.GetAllActiveAsync();

            return Ok(listObjectVM);
        }

        //
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listObjectVM = await _iDaoTaoServices.GetAllAsync();

            return Ok(listObjectVM);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _iDaoTaoServices.GetByIdAsync(id);
            return Ok(objVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DaoTaoCreateVM daoTao)
        {
            if (daoTao == null)
                return BadRequest();

            var newObjectVM = await _iDaoTaoServices.CreateAsync(daoTao);

            return Ok(newObjectVM);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DaoTaoUpdateVM daoTao)
        {
            var objUpdateVM = await _iDaoTaoServices.UpdateAsync(id, daoTao);
            return Ok(objUpdateVM);
        }

        //
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var objRemoveVM = await _iDaoTaoServices.UpdateRemoveAsync(id);
            return Ok(objRemoveVM);
        }

    }
}
