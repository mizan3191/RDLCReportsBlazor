using System.Collections.Generic;
using System.Data;

namespace BlazorAppForReporting.Services
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
    }



    public class Employee_Services
    {
        public IList<Employee> GetEmployeeList()
        {
            IList<Employee> employees = new List<Employee>();

            Random rnd = new Random();

            for (int i = 1; i <= 50; i++)
            {
                int randomNumber = rnd.Next(10000000, 100000000);

                Employee employee = new Employee
                {
                    Id = i.ToString(),
                    Name = "Miznaur-" + i,
                    Designation = "Developer-" + i,
                    Phone = "+8019-" + randomNumber.ToString()
                };

                employees.Add(employee);
            }

            return employees;
        }



        public DataTable GetEmployee()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Designation");
            dt.Columns.Add("Phone");

            DataRow dataRow;

            for (int i = 1; i <= 50; i++)
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(10000000, 100000000);

                dataRow = dt.NewRow();
                dataRow["Id"] = "Emp0" + i;
                dataRow["Name"] = "Mizna-" + i.ToString();
                dataRow["Designation"] = "Developer-" + i.ToString();
                dataRow["Phone"] = "+8019-" + randomNumber.ToString();

                dt.Rows.Add(dataRow);
            }

            return dt;
        }

        public DataTable SetEmployeeById(Employee employee)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Designation");
            dt.Columns.Add("Phone");

            DataRow dataRow = dt.NewRow();

            dataRow["Id"] = employee.Id;
            dataRow["Name"] = employee.Name;
            dataRow["Designation"] = employee.Designation;
            dataRow["Phone"] = employee.Phone;

            dt.Rows.Add(dataRow);

            return dt;
        }
    }
}
