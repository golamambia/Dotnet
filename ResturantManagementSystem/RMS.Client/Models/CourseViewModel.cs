using RMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMS.Client.Models
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
            Course = new CourseModel();
            Cuisines = new List<CuisineModel>();
        }
        public CourseModel Course { get; set; }
        public List<CuisineModel> Cuisines { get; set; }
    }
}