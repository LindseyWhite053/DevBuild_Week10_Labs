using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BookClubApp.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=bookclub;Uid=root;Pwd=generalpw1");
		// Crud operations for Person
		// Get all 
		public static List<Person> GetAllPeople()
        {
			return DB.GetAll<Person>().ToList();
        }

		// Get One 
		public static Person GetOnePerson(int id)
        {
			return DB.Get<Person>(id);
        }


		// Create One (insert)
		public static Person InsertPerson(Person pers)
        {
			DB.Insert(pers);
			return pers;
        }


		// Delete One
		public static void DeletePerson(int id)
        {
			DB.Execute($"delete from presentation where personid=@persid", new { persid = id });
			
			Person pers = new Person();
			pers.id = id;

			DB.Delete(pers);
        }

		// Update One
		public static void UpdatePerson(Person pers)
        {
			DB.Update(pers);
        }


		// Crud operations for Presentation
		// Get all 
		public static List<Presentation> GetAllPresentations()
        {
			return DB.GetAll<Presentation>().ToList();
        }

		// Get One 
		public static Presentation GetOnePresentation(int id)
        {
			return DB.Get<Presentation>(id);
        }

		//public static List<Presentation> GetMemberPresentations(int id)
  //      {
		//	List<Presentation> memberPresentations = DB.Execute($"select * from presentation where category=@persid", new { persid = id });
		//	return memberPresentations.ToList();
  //      }


		// Create One (insert)
		public static Presentation InsertPresentation(Presentation pres)
        {
			DB.Insert(pres);

			return pres;
        }


		// Delete One
		public static void DeletePresentation(int id)
        {
			Presentation pres = new Presentation();
			pres.id = id;

			DB.Delete(pres);
        }


		// Update One
		public static void UpdatePresentation(Presentation pres)
        {
			DB.Update(pres);
        }

	}
}
