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
    [ApiController]
    [Route("api/Employees/{employee_id}/EmployeeTasks")]
    public class EmployeeTasksController : ControllerBase
    {
        private IEmployeeRepository _repository;
        private IMapper _mapper;

        public EmployeeTasksController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeTaskModel[]>> Get(int employee_id)
        {
            try
            {                
                var results = await _repository.GetEmployeeTasksByEmployeeAsync(employee_id);

                return _mapper.Map<EmployeeTaskModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{taskName}")]
        public async Task<ActionResult<EmployeeTaskModel>> Get(int employee_id, string taskName)
        {
            try
            {                
                var result = await _repository.GetEmployeeTaskByEmployeeAsync(employee_id,taskName);

                if (result == null) return NotFound();
                return _mapper.Map<EmployeeTaskModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [HttpPost]
        public async Task<ActionResult<EmployeeTaskModel>> Post(int employee_id, CreateOrEditEmployeeTaskModel model)
        {

            try
            {
                var employee =await _repository.GetEmployeeByIdAsync(employee_id);

                if (employee == null) return BadRequest("Employee does not exist");

                var existEmployeeTask =await _repository.GetEmployeeTaskByEmployeeAsync(employee_id, model.TaskName);

                if (existEmployeeTask != null) return BadRequest("Task have been existing");

                var employeeTask = _mapper.Map<EmployeeTask>(model);

                employeeTask.EmployeeId = employee_id;

                _repository.Add(employeeTask);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/Employees/{employee_id}/EmployeeTasks/{model.TaskName}", _mapper.Map<EmployeeTaskModel>(employeeTask));
                }
                else
                {
                    return BadRequest("Failed to save new EmployeeTask");
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [HttpPut]
        public async Task<ActionResult<EmployeeTaskModel>> Put(int employee_id, CreateOrEditEmployeeTaskModel model)
        {
            if (model.StartDate.CompareTo(model.DeadLine) >= 0)
                return BadRequest("DeadLine should be larger than StartDate");
            if (employee_id!= model.EmployeeId)
                return BadRequest("EmployeeId not match");
            try
            {
                var oldtask = await _repository.GetEmployeeTaskByIdAsync(employee_id, model.EmployeeTaskId);
                if (oldtask == null)
                    return NotFound($"Could not find task wiht id of {model.EmployeeTaskId}");

                var existTast = await _repository.GetEmployeeTaskByEmployeeAsync(employee_id, model.TaskName);
                if (existTast != null && existTast.EmployeeTaskId != model.EmployeeTaskId)
                    return BadRequest("Task have been existing");

                _mapper.Map(model, oldtask);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<EmployeeTaskModel>(oldtask);
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete("{taskid}")]
        public async Task<ActionResult<EmployeeModel>> Delete(int employee_id, int taskid)
        {
            try
            {
                var task = await _repository.GetEmployeeTaskByIdAsync(employee_id,taskid);

                if (task == null) return NotFound("Could not find task to delete");

                _repository.Delete(task);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok("Deleted");
                }
                else
                {
                    return BadRequest("Failed to delete task");
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }
    }
}
