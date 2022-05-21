using AutoMapper;
using Contracts.Service;
using Contracts.Interfaces;
using DataModel.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataModel.Models.Entities;

namespace API.Controllers
{
    [Route("api/storeheaders")]
    [ApiController]
    public class StoreHeadersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public StoreHeadersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetStoreHeaders")]
        public async Task<IActionResult> GetStoreHeaders()
        {
            var storeHeaders = await _repository.StoreHeader.GetAllStoreHeadersAsync(trackChanges: false);

            var storeHeaderDtos = _mapper.Map<IEnumerable<StoreHeaderDto>>(storeHeaders);

            return Ok(storeHeaderDtos);
        }
        [HttpGet("{id}", Name = "StoreHeaderById")]
        public async Task<IActionResult> GetStoreHeader(int id)
        {
            var storeHeader = await _repository.StoreHeader.GetStoreHeaderAsync(id, trackChanges: false);
            if (storeHeader == null)
            {
                _logger.LogInfo($"StoreHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var storeHeaderDto = _mapper.Map<StoreHeaderDto>(storeHeader);
                return Ok(storeHeaderDto);
            }
        }
        [HttpPost(Name = "CreateStoreHeader")]
        public async Task<IActionResult> CreateStoreHeader([FromBody] StoreHeaderForCreationDto storeHeader)
        {
            if (storeHeader == null)
            {
                _logger.LogError("StoreHeaderForCreationDto object sent from client is null.");
                return BadRequest("StoreHeaderForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the StoreHeaderForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var storeHeaderEntity = _mapper.Map<StoreHeader>(storeHeader);

            _repository.StoreHeader.CreateStoreHeader(storeHeaderEntity);
            await _repository.SaveAsync();

            var storeHeaderToReturn = _mapper.Map<StoreHeaderDto>(storeHeaderEntity);

            // Disable BCC4002
            return CreatedAtRoute("storeHeaderById", new { id = storeHeaderToReturn.id }, storeHeaderToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStoreHeader(int id, [FromBody] StoreHeaderForUpdateDto storeHeader)
        {
            if (storeHeader == null)
            {
                _logger.LogError("StoreHeaderForUpdateDto object sent from client is null.");
                return BadRequest("StoreHeaderForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the StoreHeaderForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var storeHeaderEntity = await _repository.StoreHeader.GetStoreHeaderAsync(id, trackChanges: true);
            if (storeHeaderEntity == null)
            {
                _logger.LogInfo($"StoreHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(storeHeader, storeHeaderEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreHeader(int id)
        {
            var storeHeader = await _repository.StoreHeader.GetStoreHeaderAsync(id, trackChanges: false);
            if (storeHeader == null)
            {
                _logger.LogInfo($"StoreHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.StoreHeader.DeleteStoreHeader(storeHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
