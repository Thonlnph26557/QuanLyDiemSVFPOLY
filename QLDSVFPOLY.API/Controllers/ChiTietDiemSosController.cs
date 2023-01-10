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
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync(ChiTietDiemSoSearchVM searchVM)
        {
            var listVM = await _svChiTietDiemSo.GetAllAsync(searchVM);
            return Ok(listVM);
        }

        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllActiveAsync(ChiTietDiemSoSearchVM searchVM)
        {
            var listVM = await _svChiTietDiemSo.GetAllActiveAsync(searchVM);
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
