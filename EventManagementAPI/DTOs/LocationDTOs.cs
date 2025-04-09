namespace EventManagementAPI.DTOs
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Capacity { get; set; } = default!;
    }

    public class CreateLocationDTO
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Capacity { get; set; } = default!;
    }
}
