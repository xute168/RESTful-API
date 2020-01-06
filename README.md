# RESTful-API
Pre-Interview Assignment
Installation:
    To create data storate, follow steps below:
    1.In appsettings.json, modify the database connectstring
    2.run "update-database" command in Package Manager Console
CRUD for Employee:
      1.Get :http://localhost:1253/api/Employees/:
                   [
                        {
                          "employeeId": 7,
                          "firstName": "aa",
                          "lastName": "aa",
                          "hireDate": "0001-01-01T00:00:00",
                          "employeeTasks": [
                                                {
                                                    "employeeTaskId": 20,
                                                    "taskName": "Writing Sample Data Made Easy",
                                                    "startDate": "2010-01-01T10:00:00",
                                                    "deadLine": "2010-01-01T09:10:01",
                                                    "employeeId": 7
                                                }
                                            ]
                          }
                   ]
      2. Post : http://localhost:1253/api/Employees
      3. Push : http://localhost:1253/api/Employees
      4. Delete : http://localhost:1253/api/Employees/{employee_id}


CRUD for Employee Task:
      1.Get: http://localhost:1253/api/Employees/{employee_id}/EmployeeTasks
      2.Put: http://localhost:1253/api/Employees/{employee_id}/EmployeeTasks
      3.Post: http://localhost:1253/api/Employees/{employee_id}/EmployeeTasks
      4:Delete: http://localhost:1253/api/Employees/{employee_id}/EmployeeTasks/{EmployeeTasks_id}
