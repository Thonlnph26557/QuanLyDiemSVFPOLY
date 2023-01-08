using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.DAL.Entities.EF;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        //
        private readonly ISinhVienServices _iSinhVienServices;

        //
        public SinhViensController(ISinhVienServices SinhVienServices)
        {
            _iSinhVienServices = SinhVienServices ?? throw new ArgumentNullException(nameof(SinhVienServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listSinhViens = await _iSinhVienServices.GetAllAsync();
            return Ok(listSinhViens);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listSinhViens = await _iSinhVienServices.GetAllActiveAsync();
            return Ok(listSinhViens);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var sinhVien = await _iSinhVienServices.GetByIdAsync(id);
            return Ok(sinhVien);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SinhVienCreateVM sinhVien)
        {
            if (sinhVien == null) return BadRequest();
            var newSinhVien = await _iSinhVienServices.CreateAsync(sinhVien);
            return Ok(newSinhVien);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] SinhVienUpdateVM sinhVien)
        {
            var result = await _iSinhVienServices.UpdateAsync(id, sinhVien);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _iSinhVienServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
