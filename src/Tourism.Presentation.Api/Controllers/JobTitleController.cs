using Tourism.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tourism.Shared.Models;
using Tourism.Application.Models.Dto;

namespace Tourism.Presentation.Api.Controllers
{

    [Route("api/v1/titles")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        public JobTitleController() { }

        [HttpGet("job-title")]
        [SwaggerOperation(Summary = "Get all list job title")]
        [ProducesResponseType(typeof(BaseResponse<List<JobTitleModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromServices] IJobTitleService _jobTitleService, [FromQuery] PagedRequest request, CancellationToken cancellationToken)
        {
            var data = await _jobTitleService.GetAllJobTitles(request, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpGet("job-title/{id}")]
        [ProducesResponseType(typeof(BaseResponse<JobTitleModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IJobTitleService _jobTitleService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _jobTitleService.GetJobTitleById(id, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPost("job-title")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatedAsync([FromServices] IJobTitleService _jobTitleService, [FromBody] JobTitleRequest jobTitle, CancellationToken cancellationToken)
        {
            var data = await _jobTitleService.AddJobTitle(jobTitle, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPut("job-title/{id}")]
        [ProducesResponseType(typeof(BaseResponse<JobTitleModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatedAsync([FromServices] IJobTitleService _jobTitleService, Guid id, [FromBody] JobTitleModel jobTitle, CancellationToken cancellationToken)
        {
            var data = await _jobTitleService.UpdateJobTitle(id, jobTitle, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpDelete("job-title/{id}")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletedAsync([FromServices] IJobTitleService _jobTitleService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _jobTitleService.DeleteJobTitle(id, cancellationToken);
            return this.HandleResponse(data);
        }
    }
}
