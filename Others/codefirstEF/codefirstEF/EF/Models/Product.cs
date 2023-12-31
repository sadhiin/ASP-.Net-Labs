﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace codefirstEF.EF.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }

        [ForeignKey("Cate")]
        public int CId { get; set; }
        public virtual Category Cate { get; set; }
    }
}