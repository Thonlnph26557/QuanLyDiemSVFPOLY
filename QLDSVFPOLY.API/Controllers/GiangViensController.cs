
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
        public GiangViensController(IGiangVienServices GiangVienServices)
        {
            _iGiangVienServices = GiangVienServices ?? throw new ArgumentNullException(nameof(GiangVienServices)); ;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listObjectVM = await _iGiangVienServices.GetAllAsync();
            return Ok(listObjectVM);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iGiangVienServices.GetAllActiveAsync();
            return Ok(listObjectVM);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _iGiangVienServices.GetByIdAsync(id);
            return Ok(objVM);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] GiangVienCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var newObjCreateVM = await _iGiangVienServices.CreateAsync(obj);
            return Ok(newObjCreateVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] GiangVienUpdateVM obj)
        {
            var objVM = await _iGiangVienServices.UpdateAsync(id, obj);
            return Ok(objVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var objRemoveVM = await _iGiangVienServices.RemoveAsync(id);
            return Ok(objRemoveVM);
        }
    }
}
