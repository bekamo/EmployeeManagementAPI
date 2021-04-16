using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Dtos;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAllEmployees()
        {
            var empl = await _repository.GetAllEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(empl));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> GetEmployeeById(int id)
        {
            var empl = await _repository.GetEmployeeById(id);

            if (empl == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeReadDto>(empl));
        }

        [HttpPost]
        public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto emp)
        {
            var empl = _mapper.Map<Employee>(emp);
            _repository.CreateEmployee(empl);
            _repository.SaveChanges();

            var emplRead = _mapper.Map<EmployeeReadDto>(empl);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = emplRead.Id }, emplRead);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeUpdateDto emp)
        {
            var empl = await _repository.GetEmployeeById(id);
            if (empl == null)
            {
                return NotFound();
            }

            _mapper.Map(emp, empl);
            _repository.UpdateEmployee(empl);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var empl = await _repository.GetEmployeeById(id);
            if (empl == null)
            {
                return NotFound();
            }
            _repository.DeleteEmployee(empl);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
