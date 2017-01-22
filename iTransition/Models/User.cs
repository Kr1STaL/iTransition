using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace iTransition.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string E_mail { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
    }
}