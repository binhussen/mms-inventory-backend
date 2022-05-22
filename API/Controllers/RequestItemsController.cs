using AutoMapper;
using Contracts.Service;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataModel.Models.Entities;
using DataModel.Models.DTOs.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Controllers
{
    [Route("api/requestheaders/{requestheaderid}/requestitems")]
    [ApiController]
    public class RequestItemsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public RequestItemsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRequestItemsForRequestHeader(int requestheaderid)
        {

            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(requestheaderid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {requestheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemsFromDb = await _repository.RequestItem.GetRequestItemsAsync(requestheaderid, trackChanges: false);

            var requestItemsDto = _mapper.Map<IEnumerable<RequestItemDto>>(requestItemsFromDb);
            return Ok(requestItemsDto);

        }

        [HttpGet("{id}", Name = "GetRequestItemForRequestHeader")]
        public async Task<IActionResult> GetRequestItemForRequestHeader(int requestheaderid, int id)
        {
            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(requestheaderid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {requestheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemDb = await _repository.RequestItem.GetRequestItemAsync(requestheaderid, id, trackChanges: false);
            if (requestItemDb == null)
            {
               _logger.LogInfo($"RequestItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var requestItem = _mapper.Map<RequestItemDto>(requestItemDb);

            return Ok(requestItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequestItemForRequestHeader(int requestheaderid, [FromBody] RequestItemForCreationDto requestItem)
        {
            if (requestItem == null)
            {
                _logger.LogError("RequestItemForCreationDto object sent from client is null.");
                return BadRequest("RequestItemForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the RequestItemForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(requestheaderid, trackChanges: false);
            if(requestHeader == null)
            {
                 _logger.LogInfo($"RequestHeader with id: {requestheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemEntity = _mapper.Map<RequestItem>(requestItem);

            _repository.RequestItem.CreateRequestItemForRequestHeader(requestheaderid, requestItemEntity);
            await _repository.SaveAsync();
            var requestItemToReturn = _mapper.Map<RequestItemDto>(requestItemEntity);
            return CreatedAtRoute("GetRequestItemForRequestHeader", new { requestheaderid, id = requestItemToReturn.id }, requestItemToReturn);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestItemForRequestHeader(int requestheaderid, int id, [FromBody] RequestItemForUpdateDto requestItem)
        {
            if (requestItem == null)
            {
                _logger.LogError("RequestItemForUpdateDto object sent from client is null.");
                return BadRequest("RequestItemForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                 _logger.LogError("Invalid model state for the RequestItemForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(requestheaderid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {requestheaderid} doesn't exist in the database.");
                return NotFound();
            }
            var requestItemEntity = await _repository.RequestItem.GetRequestItemAsync(requestheaderid, id, trackChanges: true);
            if (requestItemEntity == null)
            {
                 _logger.LogInfo($"RequestItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(requestItem, requestItemEntity);
            await _repository.SaveAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestHeader(int requestheaderid, int id)
        {
            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(requestheaderid, trackChanges: false);
            if (requestHeader == null)
            {
                 _logger.LogInfo($"RequestHeader with id: {requestheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemForRequestHeader = await _repository.RequestItem.GetRequestItemAsync(requestheaderid, id, trackChanges: false);
            if (requestItemForRequestHeader == null)
            {
                 _logger.LogInfo($"RequestItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.RequestItem.DeleteRequestItem(requestItemForRequestHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateRequestItemForRequestHeader(int requestheaderid, int id, [FromBody] JsonPatchDocument<RequestItemForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(requestheaderid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {requestheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemEntity = await _repository.RequestItem.GetRequestItemAsync(requestheaderid, id, trackChanges: true);
            if (requestItemEntity == null)
            {
                _logger.LogInfo($"RequestItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemToPatch = _mapper.Map<RequestItemForUpdateDto>(requestItemEntity);

            patchDoc.ApplyTo(requestItemToPatch, ModelState);

            TryValidateModel(requestItemToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(requestItemToPatch, requestItemEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
