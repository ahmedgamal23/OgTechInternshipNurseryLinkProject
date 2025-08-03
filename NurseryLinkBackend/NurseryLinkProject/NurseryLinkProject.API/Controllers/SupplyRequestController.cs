using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.SupplyRequestDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyRequestController : ControllerBase
    {
        private readonly IBaseRepository<SupplyRequest> _baseRepository;
        private readonly IMapper _mapper;

        public SupplyRequestController(IBaseRepository<SupplyRequest> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllSupplyRequest(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, x => x.Include(s => s.Student).Include(t => t.Teacher));
            if (result.IsSuccess && result.DataList != null)
            {
                var SupplyRequestDtoList = _mapper.Map<IEnumerable<SupplyRequestDto>>(result.DataList);
                return Ok(SupplyRequestDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetBySupplyRequestStatus/{status}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetSupplyRequestByStatus(string status, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.Status.ToString().ToLower() == status.ToLower(),
                pageNumber, pageSize, x => x.Include(s => s.Student).Include(t => t.Teacher)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var SupplyRequestDtoList = _mapper.Map<IEnumerable<SupplyRequestDto>>(result.DataList);
                return Ok(SupplyRequestDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplyRequestById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var SupplyRequestDto = _mapper.Map<SupplyRequestDto>(result.Data);
                return Ok(SupplyRequestDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddSupplyRequestDto addSupplyRequestDto)
        {
            var SupplyRequest = _mapper.Map<SupplyRequest>(addSupplyRequestDto);
            var result = await _baseRepository.AddAsync(SupplyRequest);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSupplyRequestDto updateSupplyRequestDto)
        {
            var existingSupplyRequest = await _baseRepository.GetByIdAsync(id);
            if (!existingSupplyRequest.IsSuccess || existingSupplyRequest.Data == null)
            {
                return NotFound($"this SupplyRequest id {id} not exist");
            }
            var SupplyRequest = _mapper.Map(updateSupplyRequestDto, existingSupplyRequest.Data);
            var result = _baseRepository.Update(SupplyRequest);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this SupplyRequest");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this SupplyRequest");
        }
    }
}
