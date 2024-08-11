using BlazorAppForReporting.Components.Pages;
using System.Data;

namespace BlazorAppForReporting.Services
{
    public class Employee
    {
        public string EmpId { get; set; }
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
                    EmpId = "Emp0" + i.ToString(),
                    Name = "Miznaur-" + i,
                    Designation = "Developer-" + i,
                    Phone = "+8019-" + randomNumber.ToString()
                };

                employees.Add(employee);
            }

            return employees;
        }

        public DataTable PrintStudentById(string empId)
        {
            var list = GetEmployeeList();
            var employee = list.FirstOrDefault(x => x.EmpId == empId);
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId");
            dt.Columns.Add("Name");
            dt.Columns.Add("Designation");
            dt.Columns.Add("Phone");

            DataRow dataRow = dt.NewRow();

            dataRow["EmpId"] = employee.EmpId;
            dataRow["Name"] = employee.Name;
            dataRow["Designation"] = employee.Designation;
            dataRow["Phone"] = employee.Phone;

            dt.Rows.Add(dataRow);

            return dt;
        }

        public DataTable GetEmployee()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Designation");
            dt.Columns.Add("Phone");

            DataRow dataRow;

            for (int i = 1; i <= 1000; i++)
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

        public DataTable GetStudent()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Role");
            dt.Columns.Add("Name");
            dt.Columns.Add("Department");

            DataRow dataRow;

            dataRow = dt.NewRow();
            dataRow["Role"] = "001";
            dataRow["Name"] = "Mizna" ;
            dataRow["Department"] = "CSE";

            dt.Rows.Add(dataRow);

            return dt;
        }
    }
}
