using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemSosController : ControllerBase
    {
        IDiemSoServices _svDiemSo;
        public DiemSosController(IDiemSoServices svDiemSo)
        {
            _svDiemSo= svDiemSo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync(DiemSoSearchVM searchVM)
        {
            var listVM = await _svDiemSo.GetAllAsync(searchVM);
            return Ok(listVM);
        }

        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllActiveAsync(DiemSoSearchVM searchVM)
        {
            var listVM = await _svDiemSo.GetAllActiveAsync(searchVM);
            return Ok(listVM);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var vm = await _svDiemSo.GetByIdAsync(id);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DiemSoCreateVM createVM)
        {
            if (createVM == null) return BadRequest();
            var temp = await _svDiemSo.CreateAsync(createVM);
            return Ok(temp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DiemSoUpdateVM updateVM)
        {
            if(updateVM == null) return BadRequest();
            var temp = await _svDiemSo.UpdateAsync(id, updateVM);
            return Ok(temp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _svDiemSo.RemoveByUpdateAsync(id);
            return Ok(temp);
        }
    }
}
