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
            var listObjectVM = await _iSinhVienServices.GetAllAsync();
            return Ok(listObjectVM);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iSinhVienServices.GetAllActiveAsync();
            return Ok(listObjectVM);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _iSinhVienServices.GetByIdAsync(id);
            return Ok(objVM);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SinhVienCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var newObjCreateVM = await _iSinhVienServices.CreateAsync(obj);

            return Ok(newObjCreateVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] SinhVienUpdateVM obj)
        {
            var objVM = await _iSinhVienServices.UpdateAsync(id, obj);
            return Ok(objVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var objRemoveVM = await _iSinhVienServices.RemoveAsync(id);
            return Ok(objRemoveVM);
        }
    }
}
