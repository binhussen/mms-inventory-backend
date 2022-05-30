using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Requests;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/requestheaders")]
    [ApiController]
    public class RequestHeadersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public RequestHeadersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetRequestHeaders")]
        public async Task<IActionResult> GetRequestHeaders([FromQuery] RequestHeaderParameters requestHeaderParameters)
        {
            var requestHeaders = await _repository.RequestHeader.GetAllRequestHeadersAsync(requestHeaderParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(requestHeaders.MetaData));

            var requestHeaderDtos = _mapper.Map<IEnumerable<RequestHeaderDto>>(requestHeaders);

            return Ok(requestHeaderDtos);
        }
        [HttpGet("{id}", Name = "RequestHeaderById")]
        public async Task<IActionResult> GetRequestHeader(int id)
        {
            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(id, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var requestHeaderDto = _mapper.Map<RequestHeaderDto>(requestHeader);
                return Ok(requestHeaderDto);
            }
        }
        [HttpPost(Name = "CreateRequestHeader")]
        public async Task<IActionResult> CreateNotifyHeader([FromBody] RequestHeaderForCreationDto requestHeader)
        {
            if (requestHeader == null)
            {
                _logger.LogError("RequestHeaderForCreationDto object sent from client is null.");
                return BadRequest("RequestHeaderForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the RequestHeaderForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var requestHeaderEntity = _mapper.Map<RequestHeader>(requestHeader);

            _repository.RequestHeader.CreateRequestHeader(requestHeaderEntity);
            await _repository.SaveAsync();

            var requestHeaderToReturn = _mapper.Map<RequestHeaderDto>(requestHeaderEntity);

            // Disable BCC4002
            return CreatedAtRoute("requestHeaderById", new { id = requestHeaderToReturn.id }, requestHeaderToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestHeader(int id, [FromBody] RequestHeaderForUpdateDto requestHeader)
        {
            if (requestHeader == null)
            {
                _logger.LogError("RequestHeaderForUpdateDto object sent from client is null.");
                return BadRequest("RequestHeaderForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the RequestHeaderForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var requestHeaderEntity = await _repository.RequestHeader.GetRequestHeaderAsync(id, trackChanges: true);
            if (requestHeaderEntity == null)
            {
                _logger.LogInfo($"RequestHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(requestHeader, requestHeaderEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestHeader(int id)
        {
            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(id, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.RequestHeader.DeleteRequestHeader(requestHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
