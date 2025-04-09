namespace EventManagementAPI.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Capacity { get; set; }
        public int LocationId { get; set; }
    }

    public class CreateRoomDTO
    {
        public string Name { get; set; } = default!;
        public int Capacity { get; set; }
        public int LocationId { get; set; }
    }
}
