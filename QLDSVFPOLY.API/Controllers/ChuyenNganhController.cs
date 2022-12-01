using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.DTO.Entities.EF;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenNganhController : ControllerBase
    {
        private readonly IChuyenNganhServices _iChuyenNganhServices;

        public ChuyenNganhController(IChuyenNganhServices chuyenNganhServices)
        {
            _iChuyenNganhServices = chuyenNganhServices;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iChuyenNganhServices.RemoveAsync(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChuyenNganhCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var temp = await _iChuyenNganhServices.CreateAsync(obj);
            return Ok(temp);
        } 
    }
}
