using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace iTransition.Models
{
    public class Site
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        // Navigation property
        public User User { get; set; }
    }
}