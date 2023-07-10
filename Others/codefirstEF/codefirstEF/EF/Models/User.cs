﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codefirstEF.EF.Models
{
    public class User
    {
        public int Id {get; set;}

        [Required]
        [StringLength(12)]
        public string Username { get; set;}
        [Required,StringLength(60)]
        public string Name { get; set;}
        [Required]
        [StringLength(32)]
        public string Password { get; set;}


    }
}