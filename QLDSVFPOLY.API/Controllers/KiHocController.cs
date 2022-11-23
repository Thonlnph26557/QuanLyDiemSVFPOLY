using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiHocController : ControllerBase
    {
        private readonly IKiHocServices _iKiHocServices;
        public KiHocController(IKiHocServices iKiHocServices)
        {
            _iKiHocServices = iKiHocServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllKiHoc()
        {
            var listKiHoc = await _iKiHocServices.GetAllAsyncKiHoc(null);
            return Ok(listKiHoc);
        }

        [HttpGet("allActive")]
        public async Task<IActionResult> GetAllActiveKiHoc()
        {
            var listKiHoc = await _iKiHocServices.GetAllActiveAsyncKiHoc(null);
            return Ok(listKiHoc);
        }




        //GetById
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetKiHocById(Guid id)
        {
            var kiHoc = await _iKiHocServices.GetByIdAsyncKiHoc(id);
            return Ok(kiHoc);   
        }

        //Controller đc gọi khi thêm obj
        [HttpPost]
        public async Task<IActionResult> CreateKiHoc([FromBody] KiHocCreateViewmodel kiHoc)
        {
            if (kiHoc == null) return BadRequest();
            var newKiHoc = await _iKiHocServices.CreateAsync(kiHoc);
            return Ok(newKiHoc);
        }

        //Controller đc gọi khi update obj
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateKiHoc(Guid id, [FromBody] KiHocUpdateViewmodel kiHoc)
        {
            var result = await _iKiHocServices.UpdateAsync(id, kiHoc);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteKiHoc(Guid id)
        {
            var result = await _iKiHocServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
