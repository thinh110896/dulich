namespace Tourism.Shared.Models;
public class PagedRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Search { get; set; } // Tìm kiếm chung
    public string? SortColumn { get; set; } // Cột sắp xếp
    public bool IsDescending { get; set; } = false; // Thứ tự sắp xếp
}
