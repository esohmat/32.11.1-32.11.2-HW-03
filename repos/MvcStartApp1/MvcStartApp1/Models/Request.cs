using System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcStartApp1.Models.Db
{
    [Table("Requests")]
    public class Request
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Url { get; set; } = string.Empty;
    }
}
