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
        public KiHocsController()
        {
            _iKiHocServices = new KiHocServices();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] KiHocSearchViewmodel searchVM)
        {
            var listKiHoc = await _iKiHocServices.GetAllAsync(searchVM);
            return Ok(listKiHoc);
        }

        [HttpGet("allActive")]
        public async Task<IActionResult> GetAllActiveAsync([FromQuery] KiHocSearchViewmodel searchVM)
        {
            var listKiHoc = await _iKiHocServices.GetAllActiveAsync(searchVM);
            return Ok(listKiHoc);
        }




        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var kiHoc = await _iKiHocServices.GetByIdAsync(id);
            return Ok(kiHoc);   
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]

        public async Task<IActionResult> CreateAsync([FromBody] KiHocCreateViewmodel kiHoc)
        {
            if (kiHoc == null) return BadRequest();
            var newKiHoc = await _iKiHocServices.CreateAsync(kiHoc);
            return Ok(newKiHoc);
        }

        //Controller đc gọi khi update obj
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] KiHocUpdateViewmodel kiHoc)
        {
            var result = await _iKiHocServices.UpdateAsync(id, kiHoc);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _iKiHocServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
