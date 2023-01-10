namespace Upd8.Domain.Dtos
{
    public class EditCustomerDto
    {
        public long Id { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthday { get; set; }
        public char? Gender { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
    }
}
