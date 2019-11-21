using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Entity
{
    public class MenuEntity:CommonField
    {
        public MenuEntity()
        {
            Description = new DescriptionEntity();
            Cuisine = new CuisineEntity();
            Course = new CourseEntity();
        }
        public int Id { get; set; }        
        public DescriptionEntity Description { get; set; }
        public CuisineEntity Cuisine { get; set; }
        public CourseEntity Course { get; set; }
        public string Name { get; set; }
    }
}
