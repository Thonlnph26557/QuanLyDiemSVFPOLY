using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDiemSosController : ControllerBase
    {
        IChiTietDiemSoServices _svChiTietDiemSo;
        public ChiTietDiemSosController(IChiTietDiemSoServices svChiTietDiemSo)
        {
            _svChiTietDiemSo = svChiTietDiemSo;
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listVM = await _svChiTietDiemSo.GetAllAsync();
            return Ok(listVM);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listVM = await _svChiTietDiemSo.GetAllActiveAsync();
            return Ok(listVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid idCTLH, [FromQuery] Guid idSinhVien, [FromQuery] Guid idDiemSo)
        {
            var vm = await _svChiTietDiemSo.GetByIdAsync(idCTLH, idSinhVien, idDiemSo);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChiTietDiemSoCreateVM createVM)
        {
            if (createVM == null) return BadRequest();
            var temp = await _svChiTietDiemSo.CreateAsync(createVM);
            return Ok(temp);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromQuery]Guid idCTLH, [FromQuery] Guid idSinhVien, [FromQuery] Guid idDiemSo, [FromBody] ChiTietDiemSoUpdateVM updateVM)
        {
            if (updateVM == null) return BadRequest();
            var temp = await _svChiTietDiemSo.UpdateAsync(idCTLH, idSinhVien, idDiemSo, updateVM);
            return Ok(temp);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync([FromQuery] Guid idCTLH, [FromQuery] Guid idSinhVien, [FromQuery] Guid idDiemSo)
        {
            var temp = await _svChiTietDiemSo.RemoveByUpdateAsync(idCTLH, idSinhVien, idDiemSo);
            return Ok(temp);
        }
    }
}
