using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_Assignemnt.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<News> NewsItem { get; set; }

        public Category() {
            NewsItem = new List<News>();  
        }
    }
}