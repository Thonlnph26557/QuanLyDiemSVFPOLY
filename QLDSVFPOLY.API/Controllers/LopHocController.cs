using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDSVFPOLY.BUS.Services.Implements;
using QLDSVFPOLY.BUS.Services.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;

namespace QLDSVFPOLY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocController : ControllerBase
    {
        //gọi đến service của LopHoc
        private readonly ILopHocServices _iLopHocServices;

        public LopHocController(ILopHocServices lopHocServices)
        {
            _iLopHocServices = lopHocServices;
        }

        //Gọi đến GetAll(null)
        [HttpGet("all")]
        public async Task<IActionResult> GetAllLopHoc([FromQuery] LopHocSearchVM searchVm)
        {
            var listLopHocSearch = await _iLopHocServices.GetAllAsync(searchVm);

            //khong check dc null cua NgayTao...
            if (searchVm.Ma == null)
            {
                listLopHocSearch = await _iLopHocServices.GetAllAsync(searchVm);
            }

            return Ok(listLopHocSearch);
        }

        //lấy ra danh sách lớp học còn hoạt động
        [HttpGet("active")]
        public async Task<IActionResult> GetAllLopHocActive([FromQuery] LopHocSearchVM searchVm)
        {
            var listLopHocSearch = await _iLopHocServices.GetAllActiveAsync(searchVm);

            //khong check dc null cua NgayTao...
            if (searchVm.Ma == null)
            {
                listLopHocSearch = await _iLopHocServices.GetAllActiveAsync(searchVm);
            }

            return Ok(listLopHocSearch);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLopHocById(Guid id)
        {
            var lopHoc = await _iLopHocServices.GetByIdAsync(id);
            return Ok(lopHoc);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLopHoc([FromBody] LopHocCreateVM lopHoc)
        {
            if (lopHoc == null)
                return BadRequest();

            var newLopHoc = await _iLopHocServices.CreateAsync(lopHoc);

            return Ok(newLopHoc);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLopHoc(Guid id, [FromBody] LopHocUpdateVM lopHoc)
        {
            var result = await _iLopHocServices.UpdateAsync(id, lopHoc);
            return Ok(result);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLopHoc(Guid id)
        {
            var result = await _iLopHocServices.RemoveAsync(id);
            return Ok(result);
        }
    }
}
