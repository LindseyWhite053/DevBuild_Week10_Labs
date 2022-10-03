using Dapper.Contrib.Extensions;

namespace BusinessMVC.Models
{
    [Table("department")]
    public class Department
    {
        [ExplicitKey]
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
    }
}
