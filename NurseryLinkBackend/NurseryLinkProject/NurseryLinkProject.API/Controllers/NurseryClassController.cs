using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.NurseryClassDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseryClassController : ControllerBase
    {
        private readonly IBaseRepository<NurseryClass> _baseRepository;
        private readonly IMapper _mapper;

        public NurseryClassController(IBaseRepository<NurseryClass> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllNurseryClass(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, x => x.Include(t => t.Teacher));
            if (result.IsSuccess && result.DataList != null)
            {
                var NurseryClassDtoList = _mapper.Map<IEnumerable<NurseryClassDto>>(result.DataList);
                return Ok(NurseryClassDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByNurseryClassType/{name}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetNurseryClassByname(string name, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.ClassName.ToString().ToLower() == name.ToLower(),
                pageNumber, pageSize, x => x.Include(t => t.Teacher)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var NurseryClassDtoList = _mapper.Map<IEnumerable<NurseryClassDto>>(result.DataList);
                return Ok(NurseryClassDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNurseryClassById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var NurseryClassDto = _mapper.Map<NurseryClassDto>(result.Data);
                return Ok(NurseryClassDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddNurseryClassDto addNurseryClassDto)
        {
            var NurseryClass = _mapper.Map<NurseryClass>(addNurseryClassDto);
            var result = await _baseRepository.AddAsync(NurseryClass);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateNurseryClassDto updateNurseryClassDto)
        {
            var existingNurseryClass = await _baseRepository.GetByIdAsync(id);
            if (!existingNurseryClass.IsSuccess || existingNurseryClass.Data == null)
            {
                return NotFound($"this NurseryClass id {id} not exist");
            }
            var NurseryClass = _mapper.Map(updateNurseryClassDto, existingNurseryClass.Data);
            var result = _baseRepository.Update(NurseryClass);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this NurseryClass");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this NurseryClass");
        }
    }
}
