
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string FullName { get; set; }

        [MaxLength(12)]
        public string Password { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }
    }
}
