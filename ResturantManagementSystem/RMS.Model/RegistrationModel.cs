
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    public class RegistrationModel:CommonModel
    {
        [Display(Name ="Enter Register Numbrer")]
        public int Id { get; set; }
       
        //[Display(Name = "Enter Name")]

        [Required(ErrorMessage ="Name not null")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
       
    }
}