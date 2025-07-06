using Tourism.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Tourism.Shared.Models;
using Tourism.Application.Models.Dto;

namespace Tourism.Presentation.Api.Controllers
{

    [Route("api/v1/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region department
        [HttpGet("department")]
        [ProducesResponseType(typeof(BaseResponse<List<DepartmentModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDepartmentAsync([FromServices] IDepartmentService _departmentService, [FromQuery] PagedRequest request, CancellationToken cancellationToken)
        {
            var data = await _departmentService.GetAllDepartmentAsync(request, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpGet("department/{id}")]
        [ProducesResponseType(typeof(BaseResponse<DepartmentModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IDepartmentService _departmentService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _departmentService.GetByIdAsync(id, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPost("department")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatedDepartmentAsync([FromServices] IDepartmentService _departmentService, [FromBody] DepartmentRequest department, CancellationToken cancellationToken)
        {
            var data = await _departmentService.CreateDepartmentAsync(department, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPut("department/{id}")]
        [ProducesResponseType(typeof(BaseResponse<DepartmentModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatedDepartmentAsync([FromServices] IDepartmentService _departmentService, Guid id, [FromBody] DepartmentModel model, CancellationToken cancellationToken)
        {
            var data = await _departmentService.UpdateDepartmentAsync(id, model, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpDelete("department/{id}")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletedDepartmentAsync([FromServices] IDepartmentService _departmentService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _departmentService.DeleteDepartmentAsync(id, cancellationToken);
            return this.HandleResponse(data);
        }
        #endregion department

    }
}
