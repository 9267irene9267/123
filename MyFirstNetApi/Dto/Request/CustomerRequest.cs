namespace MyFirstNetApi.Dto.Request
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
}
