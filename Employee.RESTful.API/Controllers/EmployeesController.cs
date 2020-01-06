using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.RESTful.API.Models;
using AutoMapper;
using Employee.RESTful.API.Data;

namespace Employee.RESTful.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private IEmployeeRepository _repository;
        private IMapper _mapper;


        public EmployeesController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllEmployeesAsync(true);
               
                return _mapper.Map<EmployeeModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [HttpGet("{FirstName}")]
        public async Task<ActionResult<EmployeeModel>> Get(string firstname)
        {
            try
            {                
                var result = await _repository.GetEmployeeAsync(firstname);

                if (result == null) return NotFound();

                return _mapper.Map<EmployeeModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        public async Task<ActionResult<EmployeeModel>> Post(EmployeeModel model)
        {

            try
            {
                var employee = _mapper.Map<Employee.RESTful.API.Data.Employee>(model);

                _repository.Add(employee);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/Employees/{employee.FirstName}", _mapper.Map<EmployeeModel>(employee));
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }
                
        [HttpPut]
        public async Task<ActionResult<EmployeeModel>> Put(CreateOrEditEmployeeModel model)
        {

            try
            {
                var oldempl = await _repository.GetEmployeeByIdAsync(model.EmployeeId);

                if (oldempl == null)
                    return NotFound($"Could not find employee wiht id of {model.EmployeeId}");

                _mapper.Map(model, oldempl);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<EmployeeModel>(oldempl);
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete("{employeeid}")]
        public async Task<ActionResult<EmployeeModel>> Delete(int employeeid)       
        {

            try
            {
                var oldempl = await _repository.GetEmployeeByIdAsync(employeeid);

                if (oldempl == null)
                    return NotFound($"Could not find employee wiht id of {employeeid}");

                var employeeTasks = await _repository.GetEmployeeTasksByEmployeeAsync(employeeid);

                if (employeeTasks!=null)
                    return BadRequest($"Tasks should be clean out");

                _repository.Delete(oldempl);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }
    }
}
