namespace Tourism.Shared.Models;

public record BaseProcess<T>(T? Data, List<Error> Errors)
{
    public bool HasError => Errors.Any();

    public static BaseProcess<T> Success(T data) => new(data, []);

    public static BaseProcess<T> Failure(params Error[] errors) => new(default, errors.ToList());
    
}

