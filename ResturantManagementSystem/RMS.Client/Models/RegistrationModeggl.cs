
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS.Client.Models
{
    public class RegistrationModeggl
    {
        [Display(Name ="Enter Register Numbrer")]
        public int Id { get; set; }
        [Display(Name = "Enter Name")]

        [Required(ErrorMessage ="Name not null")]
        public string Name { get; set; }
    }
}