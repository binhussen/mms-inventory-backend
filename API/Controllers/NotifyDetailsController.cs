using AutoMapper;
using Newtonsoft.Json;
using Contracts.Service;
using Contracts.Interfaces;
using DataModel.Parameters;
using DataModel.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataModel.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Controllers
{
    [Route("api/notifyheaders/{notifyheaderid}/notifyitems")]
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
        public async Task<IActionResult> GetNotifyItemsForNotifyHeader(int notifyheaderid)
        {

            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyheaderid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {notifyheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemsFromDb = await _repository.NotifyItem.GetNotifyItemsAsync(notifyheaderid, trackChanges: false);

            var notifyItemsDto = _mapper.Map<IEnumerable<NotifyItemDto>>(notifyItemsFromDb);
            return Ok(notifyItemsDto);

        }

        [HttpGet("{id}", Name = "GetNotifyItemForNotifyHeader")]
        public async Task<IActionResult> GetNotifyItemForNotifyHeader(int notifyheaderid, int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyheaderid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {notifyheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemDb = await _repository.NotifyItem.GetNotifyItemAsync(notifyheaderid, id, trackChanges: false);
            if (notifyItemDb == null)
            {
               _logger.LogInfo($"NotifyItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItem = _mapper.Map<NotifyItemDto>(notifyItemDb);

            return Ok(notifyItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotifyItemForNotifyHeader(int notifyheaderid, [FromBody] NotifyItemForCreationDto notifyItem)
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
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyheaderid, trackChanges: false);
            if(notifyHeader == null)
            {
                 _logger.LogInfo($"NotifyHeader with id: {notifyheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemEntity = _mapper.Map<NotifyItem>(notifyItem);

            _repository.NotifyItem.CreateNotifyItemForNotifyHeader(notifyheaderid, notifyItemEntity);
            await _repository.SaveAsync();
            var notifyItemToReturn = _mapper.Map<NotifyItemDto>(notifyItemEntity);
            return CreatedAtRoute("GetNotifyItemForNotifyHeader", new { notifyheaderid, id = notifyItemToReturn.id }, notifyItemToReturn);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotifyItemForNotifyHeader(int notifyheaderid, int id, [FromBody] NotifyItemForUpdateDto notifyItem)
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

            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyheaderid, trackChanges: false);
            if (notifyHeader == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {notifyheaderid} doesn't exist in the database.");
                return NotFound();
            }
            var notifyItemEntity = await _repository.NotifyItem.GetNotifyItemAsync(notifyheaderid, id, trackChanges: true);
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
        public async Task<IActionResult> DeleteNotifyHeader(int notifyheaderid, int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyheaderid, trackChanges: false);
            if (notifyHeader == null)
            {
                 _logger.LogInfo($"NotifyHeader with id: {notifyheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var notifyItemForNotifyHeader = await _repository.NotifyItem.GetNotifyItemAsync(notifyheaderid, id, trackChanges: false);
            if (notifyItemForNotifyHeader == null)
            {
                 _logger.LogInfo($"NotifyItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.NotifyItem.DeleteNotifyItem(notifyItemForNotifyHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
