using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemSosController : ControllerBase
    {
        IDiemSoServices _sv;
        public DiemSosController()
        {
            _sv = new DiemSoServices();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] DiemSoSearchVM obj)
        {
            var list = await _sv.GetAllAsync(obj);
            return Ok(list);
        }

        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllActiveAsync([FromQuery] DiemSoSearchVM obj)
        {
            var list = await _sv.GetAllActiveAsync(obj);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var temp = await _sv.GetByIdAsync(id);
            return Ok(temp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DiemSoCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var temp = await _sv.CreateAsync(obj);
            return Ok(temp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DiemSoUpdateVM obj)
        {
            var temp = await _sv.UpdateAsync(id, obj);
            return Ok(temp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _sv.RemoveAsync(id);
            return Ok(temp);
        }
    }
}
