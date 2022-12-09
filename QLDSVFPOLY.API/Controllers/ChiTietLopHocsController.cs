using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietLopHocsController : ControllerBase
    {
        private readonly IChiTietLopHocServices _iChiTietLopHocServices;

        public ChiTietLopHocsController(IChiTietLopHocServices iChiTietLopHocServices)
        {
            _iChiTietLopHocServices = iChiTietLopHocServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listChiTietLopHoc = await _iChiTietLopHocServices.GetAllAsync(null);

            return Ok(listChiTietLopHoc);
        }

        
        [HttpGet("allActive")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listKiHoc = await _iChiTietLopHocServices.GetAllActiveAsync(null);
            return Ok(listKiHoc);
        }

        //GetById ??? 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var chiTietLopHoc = await _iChiTietLopHocServices.GetByIdAsync(id);
            return Ok(chiTietLopHoc);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChiTietLopHocCreateVM chiTietLopHoc)
        {
            if (chiTietLopHoc == null)
                return BadRequest();

            var newChiTietLopHoc = await _iChiTietLopHocServices.CreateAsync(chiTietLopHoc);

            return Ok(newChiTietLopHoc);
        }

        //Controller dc gọi khi update obj
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ChiTietLopHocUpdateVM chiTietLopHoc)
        {
            var result = await _iChiTietLopHocServices.UpdateAsync(id, chiTietLopHoc);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var result = await _iChiTietLopHocServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
