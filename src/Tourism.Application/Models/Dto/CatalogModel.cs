using Tourism.Shared.Models.Predefine;

namespace Tourism.Application.Models.Dto;

public class CatalogModel
{
    public List<PredefineDataRequest> predefineDataModels { get; set; } = new List<PredefineDataRequest>();
}
