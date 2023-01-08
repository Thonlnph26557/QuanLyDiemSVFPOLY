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

        //
        public ChucVusController(ChucVuServices ChucVuServices)
        {
            _iChucVuServices = ChucVuServices ?? throw new ArgumentNullException(nameof(ChucVuServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listChucVus = await _iChucVuServices.GetAllAsync();
            return Ok(listChucVus);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listChucVus = await _iChucVuServices.GetAllActiveAsync();
            return Ok(listChucVus);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var chucVu = await _iChucVuServices.GetByIdAsync(id);
            return Ok(chucVu);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChucVuCreateVM chucVu)
        {
            if (chucVu == null) return BadRequest();
            var newChucVu = await _iChucVuServices.CreateAsync(chucVu);
            return Ok(newChucVu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ChucVuUpdateVM chucVu)
        {
            var result = await _iChucVuServices.UpdateAsync(id, chucVu);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _iChucVuServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
