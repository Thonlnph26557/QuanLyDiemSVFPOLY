
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangViensController : ControllerBase
    {
        private readonly IGiangVienServices _iGiangVienServices;

        //
        public GiangViensController(GiangVienServices GiangVienServices)
        {
            _iGiangVienServices = GiangVienServices ?? throw new ArgumentNullException(nameof(GiangVienServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listGiangViens = await _iGiangVienServices.GetAllAsync();
            return Ok(listGiangViens);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listGiangViens = await _iGiangVienServices.GetAllActiveAsync();
            return Ok(listGiangViens);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var GiangVien = await _iGiangVienServices.GetByIdAsync(id);
            return Ok(GiangVien);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] GiangVienCreateVM GiangVien)
        {
            if (GiangVien == null) return BadRequest();
            var newGiangVien = await _iGiangVienServices.CreateAsync(GiangVien);
            return Ok(newGiangVien);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] GiangVienUpdateVM GiangVien)
        {
            var result = await _iGiangVienServices.UpdateAsync(id, GiangVien);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _iGiangVienServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
