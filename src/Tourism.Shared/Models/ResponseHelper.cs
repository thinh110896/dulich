namespace Tourism.Shared.Models
{
    public static class ResponseHelper
    {
        public static BaseResponse<T> Success<T>(T data, string message = "Success")
        {
            return new BaseResponse<T>(data, message, ReturnCode.SUCCESS, null);
        }

        public static BaseResponse<T> Fail<T>(string message,  ReturnCode code, IEnumerable<Error>? errors = null)
        {
            return new BaseResponse<T>(default, message, code, errors);
        }
    }
}
