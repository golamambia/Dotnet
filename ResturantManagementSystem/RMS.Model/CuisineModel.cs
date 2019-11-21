using System.ComponentModel.DataAnnotations;

namespace RMS.Model
{
    public class CuisineModel:CommonModel
    {
        public int Id { get;set;}
        [Required(ErrorMessage ="Please enter name")]
        [Display(Name = "Cuisine Name")]
        public string Name { get; set; }
        public DescriptionModel Description { get; set; }
    }
}
