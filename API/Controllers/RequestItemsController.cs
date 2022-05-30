using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Requests;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/requestheaders/{headerid}/items")]
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
        public async Task<IActionResult> GetRequestItemsForRequestHeader(int headerid, [FromQuery] RequestItemParameters requestItemParameters)
        {

            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(headerid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemsFromDb = await _repository.RequestItem.GetRequestItemsAsync(headerid, requestItemParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(requestItemsFromDb.MetaData));

            var requestItemsDto = _mapper.Map<IEnumerable<RequestItemDto>>(requestItemsFromDb);
            return Ok(requestItemsDto);

        }

        [HttpGet("{id}", Name = "GetRequestItemForRequestHeader")]
        public async Task<IActionResult> GetRequestItemForRequestHeader(int headerid, int id)
        {
            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(headerid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemDb = await _repository.RequestItem.GetRequestItemAsync(headerid, id, trackChanges: false);
            if (requestItemDb == null)
            {
                _logger.LogInfo($"RequestItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var requestItem = _mapper.Map<RequestItemDto>(requestItemDb);

            return Ok(requestItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequestItemForRequestHeader(int headerid, [FromBody] RequestItemForCreationDto requestItem)
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
            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(headerid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemEntity = _mapper.Map<RequestItem>(requestItem);

            _repository.RequestItem.CreateRequestItemForRequestHeader(headerid, requestItemEntity);
            await _repository.SaveAsync();
            var requestItemToReturn = _mapper.Map<RequestItemDto>(requestItemEntity);
            return CreatedAtRoute("GetRequestItemForRequestHeader", new { headerid, id = requestItemToReturn.id }, requestItemToReturn);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestItemForRequestHeader(int headerid, int id, [FromBody] RequestItemForUpdateDto requestItem)
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

            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(headerid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }
            var requestItemEntity = await _repository.RequestItem.GetRequestItemAsync(headerid, id, trackChanges: true);
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
        public async Task<IActionResult> DeleteRequestHeader(int headerid, int id)
        {
            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(headerid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemForRequestHeader = await _repository.RequestItem.GetRequestItemAsync(headerid, id, trackChanges: false);
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
        public async Task<IActionResult> PartiallyUpdateRequestItemForRequestHeader(int headerid, int id, [FromBody] JsonPatchDocument<RequestItemForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(headerid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemEntity = await _repository.RequestItem.GetRequestItemAsync(headerid, id, trackChanges: true);
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
        [HttpPatch("approve/{id}")]
        public async Task<IActionResult> RequestApproveReject(int headerid, int id, [FromBody] JsonPatchDocument<RequestItemForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var requestHeader = await _repository.RequestHeader.GetRequestHeaderAsync(headerid, trackChanges: false);
            if (requestHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var requestItemEntity = await _repository.RequestItem.GetRequestItemAsync(headerid, id, trackChanges: true);
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
