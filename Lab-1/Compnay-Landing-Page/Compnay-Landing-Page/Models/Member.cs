using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Compnay_Landing_Page.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string personImage { get; set; }
    }
}