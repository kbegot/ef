namespace EventManagementAPI.Data.Models
{
    public class Location
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required string Capacity { get; set; }

        public required ICollection<Event> Events { get; set; }
        public required ICollection<Room> Rooms { get; set; }
    }

}