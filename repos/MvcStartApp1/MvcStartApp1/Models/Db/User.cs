using System;
using System.ComponentModel.DataAnnotations;

namespace MvcStartApp1.Models.Db 
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}