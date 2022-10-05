using Microsoft.AspNetCore.Mvc;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using BookClubApp.Models;

namespace BookClubApp.Controllers
{
    public class PresentationController : Controller
    {
        public IActionResult Index()
        {
            List<Presentation> presentations = DAL.GetAllPresentations();
            return View(presentations);
        }
        public IActionResult Details(int id)
        {
            ViewData["people"] = DAL.GetAllPeople().ToList();
            return View(DAL.GetOnePresentation(id));
        }

        public IActionResult AddForm()
        {
            return View(DAL.GetAllPeople());
        }

        public IActionResult Add(Presentation pres)
        {
            bool isValid = true;

            if ( pres.PersonId == 0)
            {
                ViewBag.PersonMsg = "Please enter a valid host.";
                isValid = false;
            }

            //if ( pres.PresentationDate == 1/1/0001 12:00:00)
            //{
            //    ViewBag.Msg = "";
            //    isValid = false;
            //}

            if ( pres.BookTitle == null)
            {
                ViewBag.BookMsg = "Enter a valid book";
                isValid = false;
            }

            if ( pres.BookAuthor == null)
            {
                ViewBag.AuthorMsg = "Enter a valid author";
                isValid = false;
            }

            if ( pres.Genre== null)
            {
                ViewBag.GenreMsg = "Enter a valid genre";
                isValid = false;
            }

            if (isValid)
            {            
                DAL.InsertPresentation(pres);
                return Redirect("/Presentation");
            }
            else
            {
                List<Person> people = DAL.GetAllPeople();
                
                return View("AddForm", people);
            }

        }

        public IActionResult EditForm(int id)
        {
            ViewData["people"] = DAL.GetAllPeople().ToList();
            
            return View(DAL.GetOnePresentation(id));
        }

        public IActionResult Save(Presentation pres)
        {
            //bool isValid = true;

            //if (pres.PersonId == 0)
            //{
            //    ViewBag.PersonMsg = "Please enter a valid host.";
            //    isValid = false;
            //}

            ////if ( pres.PresentationDate == 1/1/0001 12:00:00)
            ////{
            ////    ViewBag.Msg = "";
            ////    isValid = false;
            ////}

            //if (pres.BookTitle == null)
            //{
            //    ViewBag.BookMsg = "Enter a valid book";
            //    isValid = false;
            //}

            //if (pres.BookAuthor == null)
            //{
            //    ViewBag.AuthorMsg = "Enter a valid author";
            //    isValid = false;
            //}

            //if (pres.Genre == null)
            //{
            //    ViewBag.GenreMsg = "Enter a valid genre";
            //    isValid = false;
            //}

            //if (isValid)
            //{
                           
                DAL.UpdatePresentation(pres);
                return Redirect("/Presentation");
            //} 
            //else
            //{         
            //    Presentation presentation = DAL.GetOnePresentation(pres.id);
            //    return View("EditForm", presentation);
            //}

        }


        public IActionResult ConfirmDelete(int id)
        {
            return View(DAL.GetOnePresentation(id));
        }

        public IActionResult Delete(int id)
        {
            Presentation pres = new Presentation();
            pres.id = id;
            DAL.DeletePresentation(id);
            return Redirect("/Presentation");
        }


    }
}
