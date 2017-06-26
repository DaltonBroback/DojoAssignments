namespace lostinthewoods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity    
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public int ElevationChange { get; set; }
        public double Longitude { get; set; }
        public string NorS { get; set; }
        public double Latitude { get; set; }
        public string EorW { get; set; }
    }
}