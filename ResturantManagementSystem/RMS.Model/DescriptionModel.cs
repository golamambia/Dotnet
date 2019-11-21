using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RMS.Model
{
    public class DescriptionModel:CommonModel
    {
        public int Id { get; set; }
        //[DataType(DataType.Password)]
        [Required(ErrorMessage ="Please enter a title")]
        [DisplayName("Title for Display")]
        public string Title { get; set; }
        [DisplayName("Short Description")]
        public string ShortContent { get; set; }
        [DisplayName("Description")]
        public string LongContent { get; set; }

        private class PlaceholderAttribute : Attribute
        {
        private string v;

        public PlaceholderAttribute(string v)
        {
            this.v = v;
        }
        }
    }
}
