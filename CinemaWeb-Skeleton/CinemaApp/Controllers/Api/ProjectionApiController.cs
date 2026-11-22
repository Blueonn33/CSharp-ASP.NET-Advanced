using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Projection.Response;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionApiController : ControllerBase
    {
        private readonly IProjectionService _projectionService;

        public ProjectionApiController(IProjectionService projectionService)
        {
            _projectionService = projectionService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType<GetProjectionDatesResponseModel[]>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetProjectionDatesResponseModel[]>> GetDates([FromQuery] Guid? cinemaId, Guid? movieId)
        {
            if (!cinemaId.HasValue || !movieId.HasValue)
            {
                return BadRequest();
            }

            IEnumerable<GetProjectionDatesResponseModel> responseData =
                await _projectionService.GetProjectionDatesAsync(cinemaId.Value, movieId.Value);

            return responseData.ToArray();
        }
    }
}
