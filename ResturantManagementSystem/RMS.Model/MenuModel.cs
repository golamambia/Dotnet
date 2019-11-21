using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model
{
    public class MenuModel:CommonModel
    {
        public MenuModel()
        {
            Description = new DescriptionModel();
            Cuisine = new CuisineModel();
            Course = new CourseModel();
        }
        public int Id { get; set; }
        public DescriptionModel Description { get; set; }
        public CuisineModel Cuisine { get; set; }
        public CourseModel Course { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
    }
}
