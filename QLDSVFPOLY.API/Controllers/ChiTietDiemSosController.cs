using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDiemSosController : ControllerBase
    {
        IChiTietDiemSoServices _sv;
        public ChiTietDiemSosController()
        {
            _sv = new ChiTietDiemSoServices();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] ChiTietDiemSoSearchVM obj)
        {
            var list = await _sv.GetAllAsync(obj);
            return Ok(list);
        }

        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllActiveAsync([FromQuery] ChiTietDiemSoSearchVM obj)
        {
            var list = await _sv.GetAllActiveAsync(obj);
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid idDS, [FromQuery] Guid idLH, [FromQuery] Guid idSV)
        {
            var temp = await _sv.GetByIdAsync(idDS, idLH, idSV);
            return Ok(temp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChiTietDiemSoCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var temp = await _sv.CreateAsync(obj);
            return Ok(temp);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid idDS, Guid idLH, Guid idSV, [FromBody] ChiTietDiemSoUpdateVM obj)
        {
            var temp = await _sv.UpdateAsync(idDS, idLH, idSV, obj);
            return Ok(temp);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync([FromQuery] Guid idDS, [FromQuery] Guid idLH, [FromQuery] Guid idSV)
        {
            var temp = await _sv.RemoveAsync(idDS, idLH, idSV);
            return Ok(temp);
        }
    }
}
