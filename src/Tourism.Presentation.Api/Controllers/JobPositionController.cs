using Tourism.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tourism.Shared.Models;
using Tourism.Application.Models.Dto;

namespace Tourism.Presentation.Api.Controllers
{

    [Route("api/v1/positions")]
    [ApiController]
    public class JobPositionController : ControllerBase
    {
        public JobPositionController() { }

        #region job-positon
        [HttpGet("job-positon")]
        [ProducesResponseType(typeof(BaseResponse<List<JobPositionModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPositionAsync([FromServices] IJobPositionService _jobPositionService, [FromQuery] PagedRequest request, CancellationToken cancellationToken)
        {
            var data = await _jobPositionService.GetAllJobPositionAsync(request, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpGet("job-positon/{id}")]
        [ProducesResponseType(typeof(BaseResponse<JobPositionModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IJobPositionService _jobPositionService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _jobPositionService.GetByIdAsync(id, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPost("job-positon")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatedPositionAsync([FromServices] IJobPositionService _jobPositionService, [FromBody] JobPositionRequest position, CancellationToken cancellationToken)
        {
            var data = await _jobPositionService.CreateJobPositionAsync(position, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPut("job-positon/{id}")]
        [ProducesResponseType(typeof(BaseResponse<JobPositionModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatedPositionAsync([FromServices] IJobPositionService _jobPositionService, Guid id, [FromBody] JobPositionModel model, CancellationToken cancellationToken)
        {
            var data = await _jobPositionService.UpdateJobPositionAsync(id, model, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpDelete("job-positon/{id}")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletedPositionAsync([FromServices] IJobPositionService _jobPositionService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _jobPositionService.DeleteJobPositionAsync(id, cancellationToken);
            return this.HandleResponse(data);
        }
        #endregion job-positon
    }
}
