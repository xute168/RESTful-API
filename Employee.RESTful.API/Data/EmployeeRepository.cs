using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Employee.RESTful.API.Data
{
  public class EmployeeRepository : IEmployeeRepository
  {
    private readonly EmployeeContext _context;
    private readonly ILogger<EmployeeRepository> _logger;

    public EmployeeRepository(EmployeeContext context, ILogger<EmployeeRepository> logger)
    {
      _context = context;
      _logger = logger;
    }

    public void Add<T>(T entity) where T : class 
    {
      _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T: class
    {
      _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
      _context.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
      _logger.LogInformation($"Attempitng to save the changes in the context");

      // Only return success if at least one row was changed
      return (await _context.SaveChangesAsync()) > 0;
    }

        public async Task<Employee[]> GetEmployeeById(int EmployeeId)
        {
            _logger.LogInformation($"Getting Employees");

            IQueryable<Employee> query = _context.Employees;          

            // Order It
            query = query.OrderByDescending(c => c.EmployeeId)
              .Where(c => c.EmployeeId == EmployeeId);
            return await query.ToArrayAsync();
        }

        public async Task<Employee[]> GetAllEmployeesAsync(bool includeTasks = true)
        {
            _logger.LogInformation($"Getting all Employees");

            IQueryable<Employee> query = _context.Employees;

            if (includeTasks)
            {
                query = query
                  .Include(c => c.EmployeeTasks);
            }

            // Order It
            query = query.OrderByDescending(c => c.EmployeeId);

            return await query.ToArrayAsync();
        }

        public async Task<Employee> GetEmployeeAsync(string firstname, bool includeTalks = false)
        {
            _logger.LogInformation($"Getting a Employee for {firstname}");

            IQueryable<Employee> query = _context.Employees;

            if (includeTalks)
            {
                query = query.Include(c => c.EmployeeTasks);
            }

            // Query It
            query = query.Where(c => c.FirstName == firstname);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeid, bool includeTalks = false)
        {
            _logger.LogInformation($"Getting a Employee for {employeeid}");

            IQueryable<Employee> query = _context.Employees;

            if (includeTalks)
            {
                query = query.Include(c => c.EmployeeTasks);
            }

            // Query It
            query = query.Where(c => c.EmployeeId == employeeid);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<EmployeeTask[]> GetEmployeeTasksByEmployeeAsync(int EmployeeId)
        {
            _logger.LogInformation($"Getting all EmployeeTasks for an Employee");

            IQueryable<EmployeeTask> query = _context.EmployeeTasks;
            

            // Add Query
            query = query
              .Where(t => t.EmployeeId == EmployeeId)
              .OrderByDescending(t => t.EmployeeTaskId);

            return await query.ToArrayAsync();
        }

        public async Task<EmployeeTask> GetEmployeeTaskByEmployeeAsync(int EmployeeId, string TaskName)
        {
            _logger.LogInformation($"Getting a EmployeeTask for an Employee");

            IQueryable<EmployeeTask> query = _context.EmployeeTasks;

            // Add Query
            query = query
              .Where(t => t.TaskName == TaskName && t.EmployeeId == EmployeeId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<EmployeeTask> GetEmployeeTaskByIdAsync(int EmployeeId, int id)
        {
            _logger.LogInformation($"Getting a EmployeeTask for an Employee");

            IQueryable<EmployeeTask> query = _context.EmployeeTasks;

            // Add Query
            query = query
              .Where(t => t.EmployeeTaskId == id && t.EmployeeId == EmployeeId);

            return await query.FirstOrDefaultAsync();
        }

        //public async Task<Speaker[]> GetSpeakersByMonikerAsync(string moniker)
        //{
        //  _logger.LogInformation($"Getting all Speakers for a Camp");

        //  IQueryable<Speaker> query = _context.Talks
        //    .Where(t => t.Camp.Moniker == moniker)
        //    .Select(t => t.Speaker)
        //    .Where(s => s != null)
        //    .OrderBy(s => s.LastName)
        //    .Distinct();

        //  return await query.ToArrayAsync();
        //}

        //public async Task<Speaker[]> GetAllSpeakersAsync()
        //{
        //  _logger.LogInformation($"Getting Speaker");

        //  var query = _context.Speakers
        //    .OrderBy(t => t.LastName);

        //  return await query.ToArrayAsync();
        //}


        //public async Task<Speaker> GetSpeakerAsync(int speakerId)
        //{
        //  _logger.LogInformation($"Getting Speaker");

        //  var query = _context.Speakers
        //    .Where(t => t.SpeakerId == speakerId);

        //  return await query.FirstOrDefaultAsync();
        //}
    }
}
