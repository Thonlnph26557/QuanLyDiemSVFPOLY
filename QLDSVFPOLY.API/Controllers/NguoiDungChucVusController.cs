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

        public NguoiDungChucVusController(INguoiDungChucVuServices NguoiDungChucVuServices)
        {
            _iNguoiDungChucVuServices = NguoiDungChucVuServices ?? throw new ArgumentNullException(nameof(NguoiDungChucVuServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listObjectVM = await _iNguoiDungChucVuServices.GetAllAsync();
            return Ok(listObjectVM);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iNguoiDungChucVuServices.GetAllActiveAsync();
            return Ok(listObjectVM);
        }

        //GetById
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid idNguoiDung, [FromQuery] Guid idChucVu)
        {
            var objVM = await _iNguoiDungChucVuServices.GetByIdAsync(idNguoiDung,idChucVu);
            return Ok(objVM);
        }


        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] NguoiDungChucVuCreateVM obj, Guid idNguoiDung, Guid idChucVu)
        {
            if (obj == null) return BadRequest();
            var newObjCreateVM = await _iNguoiDungChucVuServices.CreateAsync(obj, idNguoiDung, idChucVu);
            return Ok(newObjCreateVM);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromQuery] Guid idNguoiDung, [FromQuery] Guid idChucVu)
        {
            var result = await _iNguoiDungChucVuServices.UpdateAsync(idNguoiDung, idChucVu);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid idNguoiDung, [FromQuery] Guid idChucVu)
        {
            var result = await _iNguoiDungChucVuServices.DeleteAsync(idNguoiDung, idChucVu);
            return Ok(result);
        }
    }
}
