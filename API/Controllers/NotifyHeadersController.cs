using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Notify;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/notifyheaders")]
    [ApiController]
    public class NotifyHeadersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public NotifyHeadersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets the notify headers.
        /// </summary>
        /// <returns>A Task.</returns>
        [HttpGet(Name = "GetNotifyHeaders")]
        public async Task<IActionResult> GetNotifyHeaders([FromQuery] NotifyHeaderParameters notifyHeaderParameters)
        {
            var notifyHeaders = await _repository.NotifyHeader.GetAllNotifyHeadersAsync(notifyHeaderParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(notifyHeaders.MetaData));

            var notifyHeaderDtos = _mapper.Map<IEnumerable<NotifyHeaderDto>>(notifyHeaders);

            return Ok(notifyHeaderDtos);
        }
        [HttpGet("{id}", Name = "NotifyHeaderById")]
        public async Task<IActionResult> GetStoreHeader(int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(id, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var notifyHeaderDto = _mapper.Map<NotifyHeaderDto>(notifyHeader);
                return Ok(notifyHeaderDto);
            }
        }
        [HttpPost(Name = "CreateNotifyHeader")]
        public async Task<IActionResult> CreateNotifyHeader([FromBody] NotifyHeaderForCreationDto notifyHeader)
        {
            if (notifyHeader == null)
            {
                _logger.LogError("NotifyHeaderForCreationDto object sent from client is null.");
                return BadRequest("NotifyHeaderForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the NotifyHeaderForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var notifyHeaderEntity = _mapper.Map<NotifyHeader>(notifyHeader);

            _repository.NotifyHeader.CreateNotifyHeader(notifyHeaderEntity);
            await _repository.SaveAsync();

            var notifyHeaderToReturn = _mapper.Map<NotifyHeaderDto>(notifyHeaderEntity);

            // Disable BCC4002
            return CreatedAtRoute("notifyHeaderById", new { id = notifyHeaderToReturn.id }, notifyHeaderToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotifyHeader(int id, [FromBody] NotifyHeaderForUpdateDto notifyHeader)
        {
            if (notifyHeader == null)
            {
                _logger.LogError("NotifyHeaderForUpdateDto object sent from client is null.");
                return BadRequest("NotifyHeaderForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the NotifyHeaderForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var notifyHeaderEntity = await _repository.NotifyHeader.GetNotifyHeaderAsync(id, trackChanges: true);
            if (notifyHeaderEntity == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(notifyHeader, notifyHeaderEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifyHeader(int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(id, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.NotifyHeader.DeleteNotifyHeader(notifyHeader);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
