using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenNganhsController : ControllerBase
    {
        IChuyenNganhServices _sv;
        public ChuyenNganhsController()
        {
            _sv = new ChuyenNganhServices();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] ChuyenNganhSearchVM obj)
        {
            var list = await _sv.GetAllAsync(obj);
            return Ok(list);
        }

        [HttpGet("allactive")]
        public async Task<IActionResult> GetAllActiveAsync([FromQuery] ChuyenNganhSearchVM obj)
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
        public async Task<IActionResult> CreateAsync([FromBody] ChuyenNganhCreateVM obj)
        {
            if (obj == null) return BadRequest();
            var temp = await _sv.CreateAsync(obj);
            return Ok(temp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ChuyenNganhUpdateVM obj)
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

        //Controller dc gọi khi thêm chuyên ngành hẹp
        [HttpPost]
        public async Task<IActionResult> CreateChuyenNganhHep([FromBody] ChuyenNganhCreateVM chuyenNganh, Guid idChuyenNganh)
        {
            if (chuyenNganh == null)
                return BadRequest();

            var newChuyenNganhHep = await _sv.CreateChuyenNganhHep(chuyenNganh, idChuyenNganh);

            return Ok(newChuyenNganhHep);
        }

        //lấy ra chuyên ngành hẹp theo idChuyenNganh 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChuyenNganhhepById(Guid id)
        {
            var listCNHep = await _sv.GetChuyenNganhHepById(id);
            return Ok(listCNHep);
        }
    }
}
