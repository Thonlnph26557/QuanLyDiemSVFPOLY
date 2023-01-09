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

        public NguoiDungsController(INguoiDungServices NguoiDungServices)
        {
            _iNguoiDungServices = NguoiDungServices ?? throw new ArgumentNullException(nameof(NguoiDungServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listObjectVM = await _iNguoiDungServices.GetAllAsync();
            return Ok(listObjectVM);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iNguoiDungServices.GetAllActiveAsync();
            return Ok(listObjectVM);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _iNguoiDungServices.GetByIdAsync(id);
            return Ok(objVM);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] NguoiDungCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var newObjCreateVM = await _iNguoiDungServices.CreateAsync(obj);
            return Ok(newObjCreateVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] NguoiDungUpdateVM obj)
        {
            var objVM = await _iNguoiDungServices.UpdateAsync(id, obj);
            return Ok(objVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var objRemoveVM = await _iNguoiDungServices.RemoveAsync(id);
            return Ok(objRemoveVM);
        }
    }
}
