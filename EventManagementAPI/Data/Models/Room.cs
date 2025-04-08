namespace EventManagementAPI.Data.Models
{
    public class Room
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public int LocationId { get; set; }
        public required Location Location { get; set; }

        public required ICollection<Session> Sessions { get; set; }
    }

}