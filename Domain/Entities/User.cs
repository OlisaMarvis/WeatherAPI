namespace WeatherApp.Domain.Entities
{
    public class User 
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Age { get; set; }
    }
}
