using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NguoiDung;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungsController : ControllerBase
    {
        private readonly INguoiDungServices _iNguoiDungServices;

        public NguoiDungsController(NguoiDungServices NguoiDungServices)
        {
            _iNguoiDungServices = NguoiDungServices ?? throw new ArgumentNullException(nameof(NguoiDungServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listNguoiDungs = await _iNguoiDungServices.GetAllAsync();
            return Ok(listNguoiDungs);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listNguoiDungs = await _iNguoiDungServices.GetAllActiveAsync();
            return Ok(listNguoiDungs);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var nguoiDung = await _iNguoiDungServices.GetByIdAsync(id);
            return Ok(nguoiDung);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] NguoiDungCreateVM nguoiDung)
        {
            if (nguoiDung == null) return BadRequest();
            var newNguoiDung = await _iNguoiDungServices.CreateAsync(nguoiDung);
            return Ok(newNguoiDung);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] NguoiDungUpdateVM nguoiDung)
        {
            var result = await _iNguoiDungServices.UpdateAsync(id, nguoiDung);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _iNguoiDungServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
