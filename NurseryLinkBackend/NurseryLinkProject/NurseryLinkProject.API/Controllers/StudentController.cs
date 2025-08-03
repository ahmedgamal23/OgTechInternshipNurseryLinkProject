using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.StudentDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IBaseRepository<Student> _baseRepository;
        private readonly IMapper _mapper;

        public StudentController(IBaseRepository<Student> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllStudent(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, x => x.Include(n => n.NurseryClass));
            if (result.IsSuccess && result.DataList != null)
            {
                var StudentDtoList = _mapper.Map<IEnumerable<StudentDto>>(result.DataList);
                return Ok(StudentDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByStudentName/{name}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetStudentByName(string name, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.FullName.ToLower() == name.ToLower(),
                pageNumber, pageSize, x => x.Include(n => n.NurseryClass)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var StudentDtoList = _mapper.Map<IEnumerable<StudentDto>>(result.DataList);
                return Ok(StudentDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> GetStudentByName(Guid code)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.StudentCode == code,
                include:x => x.Include(n => n.NurseryClass)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var StudentDtoList = _mapper.Map<IEnumerable<StudentDto>>(result.DataList);
                return Ok(StudentDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var StudentDto = _mapper.Map<StudentDto>(result.Data);
                return Ok(StudentDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddStudentDto addStudentDto)
        {
            var Student = _mapper.Map<Student>(addStudentDto);
            var result = await _baseRepository.AddAsync(Student);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto updateStudentDto)
        {
            var existingStudent = await _baseRepository.GetByIdAsync(id);
            if (!existingStudent.IsSuccess || existingStudent.Data == null)
            {
                return NotFound($"this Student id {id} not exist");
            }
            var Student = _mapper.Map(updateStudentDto, existingStudent.Data);
            var result = _baseRepository.Update(Student);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this Student");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this Student");
        }
    }
}
