using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietLopHocController : ControllerBase
    {
        private readonly IChiTietLopHocServices _iChiTietLopHocServices;

        public ChiTietLopHocController(IChiTietLopHocServices iChiTietLopHocServices)
        {
            _iChiTietLopHocServices = iChiTietLopHocServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllChiTietLopHoc()
        {
            var listChiTietLopHoc = await _iChiTietLopHocServices.GetAllAsyncChiTietLopHoc(null);

            return Ok(listChiTietLopHoc);
        }

        //GetById ??? 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChiTietLopHocById(Guid id)
        {
            var chiTietLopHoc = await _iChiTietLopHocServices.GetByIdAsyncChiTietLopHoc(id);
            return Ok(chiTietLopHoc);
        }

        //Controller dc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateChiTietLopHoc([FromBody] ChiTietLopHocCreateViewmodel chiTietLopHoc)
        {
            if (chiTietLopHoc == null)
                return BadRequest();

            var newChiTietLopHoc = await _iChiTietLopHocServices.CreateAsync(chiTietLopHoc);

            return Ok(newChiTietLopHoc);
        }

        //Controller dc gọi khi update obj
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateChiTietLopHoc(Guid id, [FromBody] ChiTietLopHocUpdateViewmodel chiTietLopHoc)
        {
            var result = await _iChiTietLopHocServices.UpdateAsync(id, chiTietLopHoc);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteChiTietLopHoc(Guid id)
        {
            var result = await _iChiTietLopHocServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
