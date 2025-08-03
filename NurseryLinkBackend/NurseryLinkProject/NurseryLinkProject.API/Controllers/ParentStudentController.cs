using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.ParentStudentDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentStudentController : ControllerBase
    {
        private readonly IBaseRepository<ParentStudent> _baseRepository;
        private readonly IMapper _mapper;

        public ParentStudentController(IBaseRepository<ParentStudent> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllParentStudent(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, x => x.Include(s => s.Student).Include(t => t.Parent));
            if (result.IsSuccess && result.DataList != null)
            {
                var ParentStudentDtoList = _mapper.Map<IEnumerable<ParentStudentDto>>(result.DataList);
                return Ok(ParentStudentDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParentStudentById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var ParentStudentDto = _mapper.Map<ParentStudentDto>(result.Data);
                return Ok(ParentStudentDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddParentStudentDto addParentStudentDto)
        {
            var ParentStudent = _mapper.Map<ParentStudent>(addParentStudentDto);
            var result = await _baseRepository.AddAsync(ParentStudent);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateParentStudentDto updateParentStudentDto)
        {
            var existingParentStudent = await _baseRepository.GetByIdAsync(id);
            if (!existingParentStudent.IsSuccess || existingParentStudent.Data == null)
            {
                return NotFound($"this ParentStudent id {id} not exist");
            }
            var ParentStudent = _mapper.Map(updateParentStudentDto, existingParentStudent.Data);
            var result = _baseRepository.Update(ParentStudent);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this ParentStudent");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this ParentStudent");
        }
    }
}
