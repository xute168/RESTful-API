using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.RESTful.API.Data
{
    public interface IEmployeeRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Employees
        Task<Employee[]> GetAllEmployeesAsync(bool includeTalks = false);
        Task<Employee> GetEmployeeAsync(string firstname, bool includeTalks = false);
        Task<Employee> GetEmployeeByIdAsync(int employeeid, bool includeTalks = false);
        //Task<Employee[]> GetAllEmployeesByEventDate(DateTime dateTime, bool includeTalks = false);

        // EmployeeTasks
        Task<EmployeeTask> GetEmployeeTaskByEmployeeAsync(int EmployeeId, string TaskName);
        Task<EmployeeTask> GetEmployeeTaskByIdAsync(int EmployeeId, int id);
        Task<EmployeeTask[]> GetEmployeeTasksByEmployeeAsync(int EmployeeId);

    }
}