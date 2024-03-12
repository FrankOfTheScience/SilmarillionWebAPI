using MapService.Models;
using MapService.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net;

namespace MapService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapController : ControllerBase
    {
        private readonly IPathRepository _pathToNodeRepository;
        private readonly IPointOfInterestRepository _pointOfInterestRepository;

        public MapController(IPathRepository pathRepository, IPointOfInterestRepository pointOfInterestRepository)
        {
            this._pathToNodeRepository = pathRepository;
            this._pointOfInterestRepository = pointOfInterestRepository;
        }

        // GET List
        [HttpGet("pointOfInterest")]
        public async Task<ActionResult<IEnumerable<PointOfInterestNode>>> GetPointOfInterestNodeListAsync()
        {
            try
            {
                return Ok(await this._pointOfInterestRepository.GetPointOfInterestAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(GetPointOfInterestNodeListAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        [HttpGet("pathToNode")]
        public async Task<ActionResult<IEnumerable<PathToNode>>> GetPathListAsync()
        {
            try
            {
                return Ok(await this._pathToNodeRepository.GetPathAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(GetPathListAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        // GET by Id
        [HttpGet("pointOfInterest/{id}")]
        public async Task<ActionResult<PointOfInterestNode>> GetPointOfInterestByIdAsync(string id)
        {
            try
            {
                return Ok(await this._pointOfInterestRepository.GetPointOfInterestByIdAsync(id));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(GetPointOfInterestByIdAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        [HttpGet("path/{id}")]
        public async Task<ActionResult<PathToNode>> GetPathByIdAsync(string id)
        {
            try
            {
                return Ok(await this._pathToNodeRepository.GetPathByIdAsync(id));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(GetPathByIdAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        // POST
        [HttpPost("pointOfInterest")]
        public async Task<ActionResult<HttpStatusCode>> PostPointOfInterestAsync(PointOfInterestNode newPointOfInterest)
        {
            try
            {
                if (newPointOfInterest == null)
                    return HttpStatusCode.BadRequest;
                if (!await this._pointOfInterestRepository.PostPointOfInterestAsync(newPointOfInterest))
                    return HttpStatusCode.InternalServerError;
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(PostPointOfInterestAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        [HttpPost("pathToNode")]
        public async Task<ActionResult<HttpStatusCode>> PostPathAsync(PathToNode newPath)
        {
            try
            {
                if (newPath == null)
                    return HttpStatusCode.BadRequest;
                if (!await this._pathToNodeRepository.PostPathAsync(newPath))
                    return HttpStatusCode.InternalServerError;
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(PostPathAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        // UPDATE
        [HttpPut("pointOfInterest")]
        public async Task<ActionResult<HttpStatusCode>> UpdatePointOfInterestAsync(PointOfInterestNode updatedPointOfInterest)
        {
            try
            {
                if (updatedPointOfInterest == null)
                    return HttpStatusCode.BadRequest;
                await this._pointOfInterestRepository.UpdatePointOfInterestAsync(updatedPointOfInterest);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(UpdatePointOfInterestAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        [HttpPut("pathToNode")]
        public async Task<ActionResult<HttpStatusCode>> UpdatePathAsync(PathToNode updatedPath)
        {
            try
            {
                if (updatedPath == null)
                    return HttpStatusCode.BadRequest;
                if (!await this._pathToNodeRepository.UpdatePathAsync(updatedPath))
                    return HttpStatusCode.InternalServerError;
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(UpdatePathAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        // DELETE
        [HttpDelete("pointOfInterest/{id}")]
        public async Task<ActionResult<HttpStatusCode>> DeletePointOfInterestByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return HttpStatusCode.BadRequest;
                await this._pointOfInterestRepository.DeletePointOfInterestByIdAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(DeletePointOfInterestByIdAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        [HttpDelete("pathToNode/{id}")]
        public async Task<ActionResult<HttpStatusCode>> DeletePathByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return HttpStatusCode.BadRequest;
                if (!await this._pathToNodeRepository.DeletePathByIdAsync(id))
                    return HttpStatusCode.InternalServerError;
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(DeletePathByIdAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }

        // Find best path
        [HttpGet("findPath/{startNodId}/to/{finishNodeId}")]
        public async Task<ActionResult<IEnumerable<PointOfInterestNode>>> FindBestPathAsync(string startNodeId, string finishNodeId)
        {
            try
            {
                if (string.IsNullOrEmpty(startNodeId) || string.IsNullOrEmpty(finishNodeId))
                    return StatusCode(StatusCodes.Status400BadRequest);
                var startPoint = await this._pointOfInterestRepository.GetPointOfInterestByIdAsync(startNodeId);
                var destinationPoint = await this._pointOfInterestRepository.GetPointOfInterestByIdAsync(finishNodeId);

                return Ok(Utilities.AStarAlgorithm(startPoint, destinationPoint));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generated in {nameof(FindBestPathAsync)}: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An error occurred" });
            }
        }
    }
}