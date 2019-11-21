using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    public class CourseModel:CommonModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        public DescriptionModel Description { get; set; }
        public CuisineModel Cuisine { get; set; }
        public TeaType SelectTeaType { get; set; }
    }
    public enum TeaType
    {
        Tea, Coffee, GreenTea, BlackTea
    }

}
