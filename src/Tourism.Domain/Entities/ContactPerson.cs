namespace Tourism.Domain.Entities;

public class ContactPerson
{
    public string? FullName { get; set; }
    public Guid? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Guid? Relationship { get; set; }
}