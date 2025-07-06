using Tourism.Domain.Helper;
using Tourism.Shared.Models;
namespace Tourism.Domain.Helpers;

public static class ErrorHepler {
    public static Error ToErrorCode(this ReturnCode returnCode){
        return new Error(returnCode, returnCode.GetDescription());
    }
}