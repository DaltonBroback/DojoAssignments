namespace RESTauranter.Models
{
    public class Reviews : BaseEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public int Rating { get; set; }

        public Users user { get; set; }
        public Restaurants restaurant { get; set; }
    }
}