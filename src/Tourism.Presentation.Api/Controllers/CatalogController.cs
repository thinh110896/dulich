
using Microsoft.AspNetCore.Mvc;
using Tourism.Application.Interfaces;
using Tourism.Application.Models.Dto;
using Tourism.Shared.Models;
using Tourism.Shared.Models.Predefine;

namespace Tourism.Presentation.Api.Controllers
{
    [Route("api/catalogs")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<List<BaseSelectModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromServices] ICatalogService _catalogService, CancellationToken cancellationToken)
        {
            var data = await _catalogService.GetAllAsync(cancellationToken);
            return this.HandleResponse(data);
        }
        #region education 
        [HttpGet("education/{id}")]
        [ProducesResponseType(typeof(BaseResponse<PredefineDataRequest>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IDepartmentService _departmentService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _departmentService.GetByIdAsync(id, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPost("education")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatedAsync([FromServices] ICatalogService _catalogService, [FromBody] PredefineDataModel predefine, CancellationToken cancellationToken)
        {
            predefine.Group = PredefineGroups.EducationLevel;
            var data = await _catalogService.CreateAsync(predefine, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPut("education/{id}")]
        [ProducesResponseType(typeof(BaseResponse<PredefineDataRequest>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatedEducationAsync([FromServices] ICatalogService _catalogService, Guid id, [FromBody] PredefineDataRequest model, CancellationToken cancellationToken)
        {
            model.Group = PredefineGroups.EducationLevel;
            var data = await _catalogService.UpdateAsync(id, model, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpDelete("education/{id}")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletedEducationAsync([FromServices] ICatalogService _catalogService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _catalogService.DeleteAsync(id, PredefineGroups.EducationLevel, cancellationToken);
            return this.HandleResponse(data);
        }
        #endregion education

        #region major 
        [HttpGet("major/{id}")]
        [ProducesResponseType(typeof(BaseResponse<PredefineDataRequest>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMajorByIdAsync([FromServices] IDepartmentService _departmentService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _departmentService.GetByIdAsync(id, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPost("major")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatedMajorAsync([FromServices] ICatalogService _catalogService, [FromBody] PredefineDataModel predefine, CancellationToken cancellationToken)
        {
            predefine.Group = PredefineGroups.Major;
            var data = await _catalogService.CreateAsync(predefine, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPut("major/{id}")]
        [ProducesResponseType(typeof(BaseResponse<PredefineDataRequest>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatedMajorAsync([FromServices] ICatalogService _catalogService, Guid id, [FromBody] PredefineDataRequest model, CancellationToken cancellationToken)
        {
            model.Group = PredefineGroups.Major;
            var data = await _catalogService.UpdateAsync(id, model, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpDelete("major/{id}")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletedMajorAsync([FromServices] ICatalogService _catalogService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _catalogService.DeleteAsync(id, PredefineGroups.Major, cancellationToken);
            return this.HandleResponse(data);
        }
        #endregion major 

        #region gender 
        [HttpPost("gender")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatedGenderAsync([FromServices] ICatalogService _catalogService, [FromBody] PredefineDataModel predefine, CancellationToken cancellationToken)
        {
            predefine.Group = PredefineGroups.Gender;
            var data = await _catalogService.CreateAsync(predefine, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPut("gender/{id}")]
        public async Task<IActionResult> UpdatedGenderAsync([FromServices] ICatalogService _catalogService, Guid id, [FromBody] PredefineDataRequest model, CancellationToken cancellationToken)
        {
            model.Group = PredefineGroups.Gender;
            var data = await _catalogService.UpdateAsync(id, model, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpDelete("gender/{id}")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletedGenderAsync([FromServices] ICatalogService _catalogService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _catalogService.DeleteAsync(id, PredefineGroups.Gender, cancellationToken);
            return this.HandleResponse(data);
        }
        #endregion gender 

        #region marital-status 
        [HttpPost("marital-status")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatedMaritalStatusAsync([FromServices] ICatalogService _catalogService, [FromBody] PredefineDataModel predefine, CancellationToken cancellationToken)
        {
            predefine.Group = PredefineGroups.MaritalStatus;
            var data = await _catalogService.CreateAsync(predefine, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPut("arital-status/{id}")]
        [ProducesResponseType(typeof(BaseResponse<PredefineDataRequest>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatedMaritalStatusAsync([FromServices] ICatalogService _catalogService, Guid id, [FromBody] PredefineDataRequest model, CancellationToken cancellationToken)
        {
            model.Group = PredefineGroups.MaritalStatus;
            var data = await _catalogService.UpdateAsync(id, model, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpDelete("arital-status/{id}")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletedMaritalStatusAsync([FromServices] ICatalogService _catalogService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _catalogService.DeleteAsync(id, PredefineGroups.MaritalStatus, cancellationToken);
            return this.HandleResponse(data);
        }
        #endregion marital-status 

        #region Relationship
        [HttpPost("relationship")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatedRelationshipAsync([FromServices] ICatalogService _catalogService, [FromBody] PredefineDataModel predefine, CancellationToken cancellationToken)
        {
            predefine.Group = PredefineGroups.Relationship;
            var data = await _catalogService.CreateAsync(predefine, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpPut("relationship/{id}")]
        [ProducesResponseType(typeof(BaseResponse<PredefineDataRequest>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatedRelationshipAsync([FromServices] ICatalogService _catalogService, Guid id, [FromBody] PredefineDataRequest model, CancellationToken cancellationToken)
        {
            model.Group = PredefineGroups.Relationship;
            var data = await _catalogService.UpdateAsync(id, model, cancellationToken);
            return this.HandleResponse(data);
        }
        [HttpDelete("relationship/{id}")]
        [ProducesResponseType(typeof(BaseResponse<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletedRelationshipAsync([FromServices] ICatalogService _catalogService, Guid id, CancellationToken cancellationToken)
        {
            var data = await _catalogService.DeleteAsync(id, PredefineGroups.Relationship, cancellationToken);
            return this.HandleResponse(data);
        }
        #endregion relationship

    }
}
