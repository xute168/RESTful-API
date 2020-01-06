using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Employee.MVC.SeviceProxies
{
    public class EmployeeServiceProxy
    {
        // GET: Employee
        private readonly string Baseurl = "http://localhost:1253/";

        public async Task<List<Employee.MVC.Models.Employee>> GetAll()
        {
            List<Employee.MVC.Models.Employee> EmpInfo = new List<Employee.MVC.Models.Employee>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Employees");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<Employee.MVC.Models.Employee>>(EmpResponse);

                }
                //returning the employee list to view  
                return EmpInfo;
            }
            //return View();
        }

        public async Task<List<Employee.MVC.Models.Employee>> Create(Employee.MVC.Models.Employee newEmployee)
        {
            List<Employee.MVC.Models.Employee> EmpInfo = new List<Employee.MVC.Models.Employee>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.PostAsJsonAsync<Employee.MVC.Models.Employee>("api/Employees", newEmployee);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<Employee.MVC.Models.Employee>>(EmpResponse);

                }
                //returning the employee list to view  
                return EmpInfo;
            }
            //return View();
        }

    }
}