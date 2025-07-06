using Microsoft.AspNetCore.Mvc;

public class BaseController : ControllerBase
{
    protected CancellationToken CancellationToken => HttpContext.RequestAborted;
}
