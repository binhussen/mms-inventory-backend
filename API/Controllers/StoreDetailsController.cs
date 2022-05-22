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
    [Route("api/storeheaders/{storeheaderid}/storeitems")]
    [ApiController]
    public class StoreItemsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public StoreItemsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetStoreItemsForStoreHeader(int storeheaderid, [FromQuery] StoreItemParameters storeItemParameters)
        {

            var storeHeader = await _repository.StoreHeader.GetStoreHeaderAsync(storeheaderid, trackChanges: false);
            if (storeHeader == null)
            {
                _logger.LogInfo($"StoreHeader with id: {storeheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var storeItemsFromDb = await _repository.StoreItem.GetStoreItemsAsync(storeheaderid, storeItemParameters, trackChanges: false);
             Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(storeItemsFromDb.MetaData));

            var storeItemsDto = _mapper.Map<IEnumerable<StoreItemDto>>(storeItemsFromDb);
            return Ok(storeItemsDto);

        }
        [HttpGet("{id}", Name = "GetStoreItemForStoreHeader")]
        public async Task<IActionResult> GetStoreItemForStoreHeader(int storeheaderid, int id)
        {
            var storeHeader = await _repository.StoreHeader.GetStoreHeaderAsync(storeheaderid, trackChanges: false);
            if (storeHeader == null)
            {
                _logger.LogInfo($"StoreHeader with id: {storeheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var storeItemDb = await _repository.StoreItem.GetStoreItemAsync(storeheaderid, id, trackChanges: false);
            if (storeItemDb == null)
            {
                _logger.LogInfo($"StoreItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var storeItem = _mapper.Map<StoreItemDto>(storeItemDb);

            return Ok(storeItem);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStoreItemForStoreHeader(int storeheaderid, [FromBody] StoreItemForCreationDto storeItem)
        {
            if (storeItem == null)
            {
                _logger.LogError("StoreItemForCreationDto object sent from client is null.");
                return BadRequest("StoreItemForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the StoreItemForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var storeHeader = await _repository.StoreHeader.GetStoreHeaderAsync(storeheaderid, trackChanges: false);
            if (storeHeader == null)
            {
                _logger.LogInfo($"StoreHeader with id: {storeheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var storeItemEntity = _mapper.Map<StoreItem>(storeItem);

            _repository.StoreItem.CreateStoreItemForStoreHeader(storeheaderid, storeItemEntity);
            await _repository.SaveAsync();
            var storeItemToReturn = _mapper.Map<StoreItemDto>(storeItemEntity);
            return CreatedAtRoute("GetStoreItemForStoreHeader", new { storeheaderid, id = storeItemToReturn.id }, storeItemToReturn);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStoreItemForStoreHeader(int storeheaderid, int id, [FromBody] StoreItemForUpdateDto storeItem)
        {
            if (storeItem == null)
            {
                _logger.LogError("StoreItemForUpdateDto object sent from client is null.");
                return BadRequest("StoreItemForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the StoreItemForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var storeHeader = await _repository.StoreHeader.GetStoreHeaderAsync(storeheaderid, trackChanges: false);
            if (storeHeader == null)
            {
                _logger.LogInfo($"StoreHeader with id: {storeheaderid} doesn't exist in the database.");
                return NotFound();
            }
            var storeItemEntity = await _repository.StoreItem.GetStoreItemAsync(storeheaderid, id, trackChanges: true);
            if (storeItemEntity == null)
            {
                _logger.LogInfo($"StoreItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(storeItem, storeItemEntity);
            await _repository.SaveAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreHeader(int storeheaderid, int id)
        {
            var storeHeader = await _repository.StoreHeader.GetStoreHeaderAsync(storeheaderid, trackChanges: false);
            if (storeHeader == null)
            {
                _logger.LogInfo($"StoreHeader with id: {storeheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var storeItemForStoreHeader = await _repository.StoreItem.GetStoreItemAsync(storeheaderid, id, trackChanges: false);
            if (storeItemForStoreHeader == null)
            {
                _logger.LogInfo($"StoreItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.StoreItem.DeleteStoreItem(storeItemForStoreHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateStoreItemForStoreHeader(int storeheaderid, int id, [FromBody] JsonPatchDocument<StoreItemForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var storeHeader = await _repository.StoreHeader.GetStoreHeaderAsync(storeheaderid, trackChanges: false);
            if (storeHeader == null)
            {
                _logger.LogInfo($"StoreHeader with id: {storeheaderid} doesn't exist in the database.");
                return NotFound();
            }

            var storeItemEntity = await _repository.StoreItem.GetStoreItemAsync(storeheaderid, id, trackChanges: true);
            if (storeItemEntity == null)
            {
                _logger.LogInfo($"StoreItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var storeItemToPatch = _mapper.Map<StoreItemForUpdateDto>(storeItemEntity);

            patchDoc.ApplyTo(storeItemToPatch, ModelState);

            TryValidateModel(storeItemToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(storeItemToPatch, storeItemEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
