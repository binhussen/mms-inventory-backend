using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Notify;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/notifyheaders/{headerid}/items")]
    [ApiController]
    public class NotifyItemsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public NotifyItemsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetNotifyItemsForNotifyHeader(int headerid, [FromQuery] NotifyItemParameters notifyItemParameters)
        {

            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(headerid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemsFromDb = await _repository.NotifyItem.GetNotifyItemsAsync(headerid, notifyItemParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(notifyItemsFromDb.MetaData));

            var notifyItemsDto = _mapper.Map<IEnumerable<NotifyItemDto>>(notifyItemsFromDb);
            return Ok(notifyItemsDto);

        }

        [HttpGet("{id}", Name = "GetNotifyItemForNotifyHeader")]
        public async Task<IActionResult> GetNotifyItemForNotifyHeader(int headerid, int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(headerid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemDb = await _repository.NotifyItem.GetNotifyItemAsync(headerid, id, trackChanges: false);
            if (notifyItemDb == null)
            {
                _logger.LogInfo($"NotifyItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItem = _mapper.Map<NotifyItemDto>(notifyItemDb);

            return Ok(notifyItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotifyItemForNotifyHeader(int headerid, [FromBody] NotifyItemForCreationDto notifyItem)
        {
            if (notifyItem == null)
            {
                _logger.LogError("NotifyItemForCreationDto object sent from client is null.");
                return BadRequest("NotifyItemForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the NotifyItemForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(headerid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemEntity = _mapper.Map<NotifyItem>(notifyItem);

            _repository.NotifyItem.CreateNotifyItemForNotifyHeader(headerid, notifyItemEntity);
            await _repository.SaveAsync();
            var notifyItemToReturn = _mapper.Map<NotifyItemDto>(notifyItemEntity);
            return CreatedAtRoute("GetNotifyItemForNotifyHeader", new { headerid, id = notifyItemToReturn.id }, notifyItemToReturn);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotifyItemForNotifyHeader(int headerid, int id, [FromBody] NotifyItemForUpdateDto notifyItem)
        {
            if (notifyItem == null)
            {
                _logger.LogError("NotifyItemForUpdateDto object sent from client is null.");
                return BadRequest("NotifyItemForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the NotifyItemForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(headerid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }
            var notifyItemEntity = await _repository.NotifyItem.GetNotifyItemAsync(headerid, id, trackChanges: true);
            if (notifyItemEntity == null)
            {
                _logger.LogInfo($"NotifyItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(notifyItem, notifyItemEntity);
            await _repository.SaveAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifyHeader(int headerid, int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(headerid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemForNotifyHeader = await _repository.NotifyItem.GetNotifyItemAsync(headerid, id, trackChanges: false);
            if (notifyItemForNotifyHeader == null)
            {
                _logger.LogInfo($"NotifyItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.NotifyItem.DeleteNotifyItem(notifyItemForNotifyHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateNotifyItemForNotifyHeader(int headerid, int id, [FromBody] JsonPatchDocument<NotifyItemForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(headerid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemEntity = await _repository.NotifyItem.GetNotifyItemAsync(headerid, id, trackChanges: true);
            if (notifyItemEntity == null)
            {
                _logger.LogInfo($"NotifyItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemToPatch = _mapper.Map<NotifyItemForUpdateDto>(notifyItemEntity);

            patchDoc.ApplyTo(notifyItemToPatch, ModelState);

            TryValidateModel(notifyItemToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(notifyItemToPatch, notifyItemEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
