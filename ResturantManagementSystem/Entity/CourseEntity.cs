using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Entity
{
   public class CourseEntity:CommonField
    {
        public CourseEntity()
        {
            Description = new DescriptionEntity();
            Cuisine = new CuisineEntity();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DescriptionEntity Description { get; set; }
        public CuisineEntity Cuisine { get; set; }
    }
}
