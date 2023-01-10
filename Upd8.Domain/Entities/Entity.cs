namespace Upd8.Domain.Entities
{
    public class Entity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
