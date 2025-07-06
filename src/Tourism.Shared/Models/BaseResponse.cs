namespace Tourism.Shared.Models;

public record BaseResponse<T>(T? Data, string Message, ReturnCode Code, IEnumerable<Error>? Errors);
