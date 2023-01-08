using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NguoiDungChucVu;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungChucVusController : ControllerBase
    {
        private readonly INguoiDungChucVuServices _iNguoiDungChucVuServices;

        public NguoiDungChucVusController(NguoiDungChucVuServices NguoiDungChucVuServices)
        {
            _iNguoiDungChucVuServices = NguoiDungChucVuServices ?? throw new ArgumentNullException(nameof(NguoiDungChucVuServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listChucVus = await _iNguoiDungChucVuServices.GetAllAsync();
            return Ok(listChucVus);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listNguoiDungChucVus = await _iNguoiDungChucVuServices.GetAllActiveAsync();
            return Ok(listNguoiDungChucVus);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid idNguoiDung, [FromQuery] Guid idChucVu)
        {
            var nguoiDungNguoiDunghucVu = await _iNguoiDungChucVuServices.GetByIdAsync(idNguoiDung,idChucVu);
            return Ok(nguoiDungNguoiDunghucVu);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] NguoiDungChucVuCreateVM nguoiDungChucVu)
        {
            if (nguoiDungChucVu == null) return BadRequest();
            var newNguoiDungChucVu = await _iNguoiDungChucVuServices.CreateAsync(nguoiDungChucVu);
            return Ok(newNguoiDungChucVu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromQuery] Guid idNguoiDung, [FromQuery] Guid idChucVu)
        {
            var result = await _iNguoiDungChucVuServices.UpdateAsync(idNguoiDung, idChucVu);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid idNguoiDung, [FromQuery] Guid idChucVu)
        {
            var result = await _iNguoiDungChucVuServices.DeleteAsync(idNguoiDung, idChucVu);
            return Ok(result);
        }
    }
}
