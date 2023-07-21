using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Assignemnt.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string Title { get; set; }

        [Required]
        public string Content{ get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}