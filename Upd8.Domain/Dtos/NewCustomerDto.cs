namespace Upd8.Domain.Dtos
{
    public class NewCustomerDto
    {
        public string Cpf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public char Gender { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
    }
}
