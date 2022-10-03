using Microsoft.AspNetCore.Mvc;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using BusinessMVC.Models;

namespace BusinessMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(DAL.GetAllEmployees());
        }

        public IActionResult Detail(int id)
        {
            return View(DAL.GetOneEmployee(id));
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Employee emp)
        {
            DAL.InsertEmployee(emp);
            return Redirect("/employee");
        }

        public IActionResult EditForm(int id)
        {
            return View(DAL.GetOneEmployee(id));
        }

        public IActionResult Save(Employee emp)
        {
            DAL.UpdateEmployee(emp);
            return Redirect("/employee");
        }

        public IActionResult Delete(int id)
        {
            DAL.DeleteEmployee(id);
            return Redirect("/employee");
        }
    }
}
