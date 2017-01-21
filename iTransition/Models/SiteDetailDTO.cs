using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTransition.Models
{
    public class SiteDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
    }
}