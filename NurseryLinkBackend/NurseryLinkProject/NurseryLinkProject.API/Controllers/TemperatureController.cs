using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.TemperatureDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly IBaseRepository<Temperature> _baseRepository;
        private readonly IMapper _mapper;

        public TemperatureController(IBaseRepository<Temperature> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllTemperature(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, x => x.Include(s => s.Student).Include(t => t.Teacher));
            if (result.IsSuccess && result.DataList != null)
            {
                var TemperatureDtoList = _mapper.Map<IEnumerable<TemperatureDto>>(result.DataList);
                return Ok(TemperatureDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemperatureById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var TemperatureDto = _mapper.Map<TemperatureDto>(result.Data);
                return Ok(TemperatureDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddTemperatureDto addTemperatureDto)
        {
            var Temperature = _mapper.Map<Temperature>(addTemperatureDto);
            var result = await _baseRepository.AddAsync(Temperature);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTemperatureDto updateTemperatureDto)
        {
            var existingTemperature = await _baseRepository.GetByIdAsync(id);
            if (!existingTemperature.IsSuccess || existingTemperature.Data == null)
            {
                return NotFound($"this Temperature id {id} not exist");
            }
            var Temperature = _mapper.Map(updateTemperatureDto, existingTemperature.Data);
            var result = _baseRepository.Update(Temperature);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this Temperature");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this Temperature");
        }
    }
}
