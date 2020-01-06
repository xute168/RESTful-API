﻿using Employee.MVC.Models;
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
    public class EmployeeTaskServiceProxy
    {
        // GET: Employee
        private readonly string Baseurl = "http://localhost:1253/";

        public async Task<List<EmployeeTast>> GetAllByEmployeeId(int id)
        {
            List<EmployeeTast> EmpInfo = new List<EmployeeTast>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Employees/" + id + "/EmployeeTasks");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<EmployeeTast>>(EmpResponse);

                }
                //returning the employee list to view  
                return EmpInfo;
            }
        }

    }
}