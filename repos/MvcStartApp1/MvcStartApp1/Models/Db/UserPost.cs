using System;
using System.ComponentModel.DataAnnotations;

namespace MvcStartApp1.Models.Db
{
    public class UserPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; } 
    }
}