namespace Tourism.Domain.Entities;

public class Address
{
    public Guid? CountryId { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? WardId { get; set; }
    public string? HouseNumber { get; set; }
}