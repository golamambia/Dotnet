namespace RMS.Entity
{
    public class CuisineEntity:CommonField
    {
        public int Id { get;set;}
        public string Name { get; set; }
        public DescriptionEntity Description { get; set; }
    }
}
