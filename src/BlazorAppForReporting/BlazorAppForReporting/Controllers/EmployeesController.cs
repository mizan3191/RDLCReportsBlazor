using AspNetCore.Reporting;
using BlazorAppForReporting.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlazorAppForReporting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private Employee_Services _employee_Services = new();

        public EmployeesController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [HttpGet("EmployeeList")]
        public IActionResult EmployeeList()
        {
           var employeeList =  _employee_Services.GetEmployeeList();

            return Ok(employeeList);
        }

        [HttpGet("print")]
        public IActionResult Print()
        {
            var dt = new DataTable();
            dt = _employee_Services.GetEmployee();

            string mimetype = "";
            int extension = 1;

            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\EmployeeReports.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportParameter", "RDLC in Blazor Web Application.");

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSetEmpolyee", dt);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet("student")]
        public IActionResult PrintStudent()
        {
            var dt = new DataTable();
            dt = _employee_Services.GetStudent();

            string mimetype = "";
            int extension = 1;

            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Student.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportParameterStudent", "Student Details");

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSetStudent", dt);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet("EmployeeDetails/{EmpId}")]
        public IActionResult PrintStudent(string empId)
        {
            var dt = new DataTable();
            dt = _employee_Services.PrintStudentById(empId);

            string mimetype = "";
            int extension = 1;

            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\EmployeeDetails.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ReportParameterEmpolyee", "Empolyee Details");

            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSetEmpolyee", dt);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");
        }
    }
}
