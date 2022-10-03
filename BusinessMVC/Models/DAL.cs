using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BusinessMVC.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=business;Uid=root;Pwd=generalpw1");


        // Crud operations for Employee
        // Read all 
        public static List<Employee> GetAllEmployees()
        {
            return DB.GetAll<Employee>().ToList();
        }

        // Read One 
        public static Employee GetOneEmployee(int id)
        {
            return DB.Get<Employee>(id);
        }

        // Create One (insert)
        public static Employee InsertEmployee (Employee emp)
        {
            DB.Insert(emp);
            return emp;
        }

        // Delete One
        public static void DeleteEmployee (int id)
        {
            Employee emp = new Employee();
            emp.id = id;

            DB.Delete(emp);
        }


        // Update One
        public static void UpdateEmployee(Employee emp)
        {
            DB.Update(emp);
        }


        // Crud operations for Department
        // Read all 


        // Read One 


        // Create One (insert)


        // Delete One


        // Update One
    }
}
