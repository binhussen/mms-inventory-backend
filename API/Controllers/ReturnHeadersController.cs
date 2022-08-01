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
    [Route("api/returnheaders")]
    [ApiController]
    public class ReturnHeadersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ReturnHeadersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetReturnHeaders")]
        public async Task<IActionResult> GetReturnHeaders([FromQuery] ReturnHeaderParameters returnHeaderParameters)
        {
            var returnHeaders = await _repository.ReturnHeader.GetAllReturnHeadersAsync(returnHeaderParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(returnHeaders.MetaData));

            var returnHeaderDtos = _mapper.Map<IEnumerable<ReturnHeaderDto>>(returnHeaders);

            return Ok(returnHeaderDtos);
        }
        [HttpGet("{id}", Name = "ReturnHeaderById")]
        public async Task<IActionResult> GetReturnHeader(int id)
        {
            var returnHeader = await _repository.ReturnHeader.GetReturnHeaderAsync(id, trackChanges: false);
            if (returnHeader == null)
            {
                _logger.LogInfo($"RequestHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var returnHeaderDto = _mapper.Map<ReturnHeaderDto>(returnHeader);
                return Ok(returnHeaderDto);
            }

        }

        [HttpPost(Name = "CreateReturnHeader")]
        public async Task<IActionResult> CreateReturnHeader([FromBody] ReturnHeaderForCreationDto returnHeader)
        {
            if (returnHeader == null)
            {
                _logger.LogError("ReturnHeaderForCreationDto object sent from client is null.");
                return BadRequest("ReturnHeaderForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ReturnHeaderForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var returnHeaderEntity = _mapper.Map<ReturnHeader>(returnHeader);

            _repository.ReturnHeader.CreateReturnHeader(returnHeaderEntity);

            await _repository.SaveAsync();

            var returnHeaderToReturn = _mapper.Map<ReturnHeaderDto>(returnHeaderEntity);
            return CreatedAtRoute("returnHeaderById", new { id = returnHeaderToReturn.id }, returnHeaderToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReturnHeader(int id, [FromBody] ReturnHeaderForUpdateDto returnHeader)
        {
            if (returnHeader == null)
            {
                _logger.LogError("ReturnHeaderForUpdateDto object sent from client is null.");
                return BadRequest("ReturnHeaderForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ReturnHeaderForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var returnHeaderEntity = await _repository.ReturnHeader.GetReturnHeaderAsync(id, trackChanges: true);
            if (returnHeaderEntity == null)
            {
                _logger.LogInfo($"ReturnHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(returnHeader, returnHeaderEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturnHeader(int id)
        {
            var returnHeader = await _repository.ReturnHeader.GetReturnHeaderAsync(id, trackChanges: false);
            if (returnHeader == null)
            {
                _logger.LogInfo($"ReturnHeader with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.ReturnHeader.DeleteReturnHeader(returnHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
