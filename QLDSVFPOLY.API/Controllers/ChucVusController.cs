using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChucVu;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVusController : ControllerBase
    {
        private readonly IChucVuServices _iChucVuServices;

        public ChucVusController(IChucVuServices ChucVuServices)
        {
            _iChucVuServices = ChucVuServices ?? throw new ArgumentNullException(nameof(ChucVuServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listObjectVM = await _iChucVuServices.GetAllAsync();
            return Ok(listObjectVM);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iChucVuServices.GetAllActiveAsync();
            return Ok(listObjectVM);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _iChucVuServices.GetByIdAsync(id);
            return Ok(objVM);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChucVuCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var newObjCreateVM = await _iChucVuServices.CreateAsync(obj);
            return Ok(newObjCreateVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ChucVuUpdateVM obj)
        {
            var objVM = await _iChucVuServices.UpdateAsync(id, obj);
            return Ok(objVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var objRemoveVM = await _iChucVuServices.RemoveAsync(id);
            return Ok(objRemoveVM);
        }
    }
}
