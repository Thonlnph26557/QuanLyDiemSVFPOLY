using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiHocsController : ControllerBase
    {
        private readonly IKiHocServices _iKiHocServices;

        public KiHocsController(IKiHocServices iKiHocServices)
        {
            _iKiHocServices = iKiHocServices ?? throw new ArgumentNullException(nameof(iKiHocServices));
        }


        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listObjectVM = await _iKiHocServices.GetAllAsync();
            return Ok(listObjectVM);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listObjectVM = await _iKiHocServices.GetAllActiveAsync();
            return Ok(listObjectVM);
        }

        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var objVM = await _iKiHocServices.GetByIdAsync(id);
            return Ok(objVM);
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] KiHocCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var newObjCreateVM = await _iKiHocServices.CreateAsync(obj);
            return Ok(newObjCreateVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] KiHocUpdateVM obj)
        {
            var objVM = await _iKiHocServices.UpdateAsync(id, obj);
            return Ok(objVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var objRemoveVM = await _iKiHocServices.RemoveAsync(id);
            return Ok(objRemoveVM);
        }
    }
}
