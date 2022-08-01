using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Returns;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ReturnItemsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IReturnToStore returnToStore;
        public ReturnItemsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IReturnToStore returnToStore)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            this.returnToStore = returnToStore;
        }
        [HttpGet("returnheaders/{headerid}/items")]
        public async Task<IActionResult> GetReturnItemsForReturnHeader(int headerid, [FromQuery] ReturnItemParameters returnItemParameters)
        {


            var returnHeader = await _repository.ReturnHeader.GetReturnHeaderAsync(headerid, trackChanges: false);
            if (returnHeader == null)
            {
                _logger.LogInfo($"ReturnHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var returnItemsFromDb = await _repository.ReturnItem.GetReturnItemsAsync(headerid, returnItemParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(returnItemsFromDb.MetaData));

            var returnItemsDto = _mapper.Map<IEnumerable<ReturnItemDto>>(returnItemsFromDb);
            return Ok(returnItemsDto);


        }

        [HttpGet("returnheaders/{headerid}/items/{id}", Name = "GetReturnItemForReturnHeader")]
        public async Task<IActionResult> GetReturnItemForReturnHeader(int headerid, int id)
        {
            var returnHeader = await _repository.ReturnHeader.GetReturnHeaderAsync(headerid, trackChanges: false);
            if (returnHeader == null)
            {
                _logger.LogInfo($"ReturnHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var returnItemDb = await _repository.ReturnItem.GetReturnItemAsync(headerid, id, trackChanges: false);
            if (returnItemDb == null)
            {
                _logger.LogInfo($"ReturnItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var returnItem = _mapper.Map<ReturnItemDto>(returnItemDb);

            return Ok(returnItem);
        }

        [HttpPost("returnheaders/{headerid}/items")]
        public async Task<IActionResult> CreateReturnItemForReturnHeader(int headerid, [FromBody] ReturnItemForCreationDto returnItem)
        {
            if (returnItem == null)
            {
                _logger.LogError("ReturnItemForCreationDto object sent from client is null.");
                return BadRequest("ReturnItemForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ReturnItemForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var returnHeader = await _repository.ReturnHeader.GetReturnHeaderAsync(headerid, trackChanges: false);
            if (returnHeader == null)
            {
                _logger.LogInfo($"ReturnHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var returnItemEntity = _mapper.Map<ReturnItem>(returnItem);

            _repository.ReturnItem.CreateReturnItemForReturnHeader(headerid, returnItemEntity);
            await _repository.SaveAsync();
            var returnItemToReturn = _mapper.Map<ReturnItemDto>(returnItemEntity);
            return CreatedAtRoute("GetReturnItemForReturnHeader", new { headerid, id = returnItemToReturn.id }, returnItemToReturn);

        }


        [HttpPut("returnheaders/{headerid}/items/{id}")]
        public async Task<IActionResult> UpdateReturnItemForReturnHeader(int headerid, int id, [FromBody] ReturnItemForUpdateDto returnItem)
        {
            if (returnItem == null)
            {
                _logger.LogError("ReturnItemForUpdateDto object sent from client is null.");
                return BadRequest("ReturnItemForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ReturnItemForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var returnHeader = await _repository.ReturnHeader.GetReturnHeaderAsync(headerid, trackChanges: false);
            if (returnHeader == null)
            {
                _logger.LogInfo($"ReturnHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }
            var returnItemEntity = await _repository.ReturnItem.GetReturnItemAsync(headerid, id, trackChanges: true);
            if (returnItemEntity == null)
            {
                _logger.LogInfo($"ReturnItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(returnItem, returnItemEntity);
            await _repository.SaveAsync();

            return NoContent();

        }

        [HttpDelete("returnheaders/{headerid}/items/{id}")]
        public async Task<IActionResult> DeleteReturnHeader(int headerid, int id)
        {
            var returnHeader = await _repository.ReturnHeader.GetReturnHeaderAsync(headerid, trackChanges: false);
            if (returnHeader == null)
            {
                _logger.LogInfo($"ReturnHeader with id: {headerid} doesn't exist in the database.");
                return NotFound();
            }

            var returnItemForRequestHeader = await _repository.ReturnItem.GetReturnItemAsync(headerid, id, trackChanges: false);
            if (returnItemForRequestHeader == null)
            {
                _logger.LogInfo($"ReturnItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.ReturnItem.DeleteReturnItem(returnItemForRequestHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
        //[HttpPost]
        //public async Task<IActionResult> ReturnToStore([FromBody] string rtnNumber, StoreItem storeItem, int quantity, string doneBy)
        //{
        //    returnToStore.ExecuteAsync(rtnNumber, storeItem, quantity, doneBy);
        //    await _repository.SaveAsync();
        //    return NoContent();

        //}
    }
}
