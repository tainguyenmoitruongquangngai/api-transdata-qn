using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataTransmissionAPI.Data;
using DataTransmissionAPI.Dto;
using DataTransmissionAPI.Service;

namespace DataTransmissionAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class StoragePreDataController : ControllerBase
    {
        private readonly StoragePreDataService _service;

        public StoragePreDataController(StoragePreDataService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<StoragePreDataDto>> GetAllData()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet]
        [Route("{ConstructionCode}")]
        public async Task<List<StoragePreDataDto>> GetByConstruction(string ConstructionCode)
        {
            return await _service.GetByConstructionCode(ConstructionCode);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<StoragePreData>> Save(List<StoragePreDataDto> dtos)
        {
            var res = await _service.SaveAsync(dtos);
            if (res > 0)
            {
                return Ok(new { message = "Saved station successfully" });
            }
            else
            {
                return BadRequest(new { message = "Saving station failed", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<StoragePreData>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "StoragePreData successfully deleted" });
            }
            else
            {
                return BadRequest(new { message = "Removing StoragePreData failed", error = true });
            }
        }
    }
}
