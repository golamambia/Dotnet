namespace RMS.Entity
{
    public class DescriptionEntity:CommonField
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string LongContent { get; set; }
    }
}
