using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietLopHocsController : ControllerBase
    {
        private readonly IChiTietLopHocServices _svChiTietLopHoc;

        public ChiTietLopHocsController(IChiTietLopHocServices svChiTietLopHoc)
        {
            _svChiTietLopHoc = svChiTietLopHoc;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var listVM = await _svChiTietLopHoc.GetAllAsync();
            return Ok(listVM);
        }

        [HttpGet("GetAllActiveAsync")]
        public async Task<IActionResult> GetAllActiveAsync()
        {
            var listVM = await _svChiTietLopHoc.GetAllActiveAsync();
            return Ok(listVM);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var vm = await _svChiTietLopHoc.GetByIdAsync(id);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ChiTietLopHocCreateVM createVM)
        {
            if (createVM == null) return BadRequest();
            var temp = await _svChiTietLopHoc.CreateAsync(createVM);
            return Ok(temp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ChiTietLopHocUpdateVM updateVM)
        {
            if (updateVM == null) return BadRequest();
            var temp = await _svChiTietLopHoc.UpdateAsync(id, updateVM);
            return Ok(temp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var temp = await _svChiTietLopHoc.RemoveByUpdateAsync(id);
            return Ok(temp);
        }
    }
}
