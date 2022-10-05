using Microsoft.AspNetCore.Mvc;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using BookClubApp.Models;

namespace BookClubApp.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View(DAL.GetAllPeople());
        }

        public IActionResult Detail(int id)
        {
            return View(DAL.GetOnePerson(id));
        }
        
        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Person pers)
        {
            bool isValid = true;

            if (pers.FirstName == null)
            {
                ViewBag.FirstNameMsg = "Enter a valid first name";
                isValid = false;
            }

            if (pers.LastName == null)
            {
                ViewBag.LastNameMsg = "Enter a valid last name";
                isValid = false;
            }

            if (pers.Email == null || !pers.Email.Contains("@"))
            {
                ViewBag.EmailMsg = "Enter a valid email";
                isValid = false;
            }
            
            if (isValid)
            {
                DAL.InsertPerson(pers);
                return Redirect("/Person");
            }
            else
            {
                List<Person> people = DAL.GetAllPeople();
                ViewBag.first = pers.FirstName;
                ViewBag.last = pers.LastName;
                ViewBag.email = pers.Email;
                return View("AddForm", people);
            }

        }
        public IActionResult EditForm(int id)
        {
            return View(DAL.GetOnePerson(id));
        }

        public IActionResult Save(Person pers)
        {
            bool isValid = true;

            if (pers.FirstName == null)
            {
                ViewBag.FirstNameMsg = "Enter a valid first name";
                isValid = false;
            }

            if (pers.LastName == null)
            {
                ViewBag.LastNameMsg = "Enter a valid last name";
                isValid = false;
            }

            if (pers.Email == null || !pers.Email.Contains("@"))
            {
                ViewBag.EmailMsg = "Enter a valid email";
                isValid = false;
            }

            if (isValid)
            {
                DAL.UpdatePerson(pers);
                return Redirect("/Person");
            }
            else
            {
                ViewBag.first = pers.FirstName;
                ViewBag.last = pers.LastName;
                ViewBag.email = pers.Email;
                return View("EditForm", pers);
            }

        }

        public IActionResult ConfirmDelete(int id)
        {
            return View(DAL.GetOnePerson(id));
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePerson(id);
            return Redirect("/Person");
        }
    }
}
