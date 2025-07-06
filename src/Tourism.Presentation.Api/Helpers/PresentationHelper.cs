using Microsoft.AspNetCore.Mvc;
using Tourism.Shared.Models;

public static class PresentationHelper
{
    public static IActionResult HandleResponse<T>(this ControllerBase controller, BaseProcess<T?> data)
    {
        if (data.HasError)
        {
            var response = data.Errors.Any() ? new BaseResponse<T>(default, data.Errors.First().Message, data.Errors.First().Code, data.Errors) : new BaseResponse<T>(data.Data, ReturnCode.SUCCESS.ToString(), ReturnCode.SUCCESS, null);
            return response.Code switch
            {
                ReturnCode.SUCCESS => controller.Ok(response),
                ReturnCode.BADREQUEST => controller.BadRequest(response),
                _ => controller.BadRequest(response)
            };
        }
        return controller.Ok(ResponseHelper.Success(data.Data!));
    }
}
