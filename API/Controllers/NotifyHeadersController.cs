using AutoMapper;
using Newtonsoft.Json;
using Contracts.Interfaces;
using DataModel.Parameters;
using DataModel.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataModel.Models.Entities;

namespace API.Controllers
{
    [Route("api/notifyHeaders")]
    [ApiController]
    public class NotifyHeadersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public NotifyHeadersController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetNotifyHeaders")]
        public async Task<IActionResult> GetNotifyHeaders()
        {
            var notifyHeaders = await _repository.NotifyHeader.GetAllNotifyHeadersAsync(trackChanges: false);

            var notifyHeaderDtos = _mapper.Map<IEnumerable<NotifyHeaderDto>>(notifyHeaders);

            return Ok(notifyHeaderDtos);
        }
        [HttpGet("{id}", Name = "NotifyHeaderById")]
        public async Task<IActionResult> GetStoreHeader(int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(id, trackChanges: false);
            if (notifyHeader == null)
            {
                //TODO: here add message response or logger message
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
            var notifyHeaderEntity = _mapper.Map<NotifyHeader>(notifyHeader);

            _repository.NotifyHeader.CreateNotifyHeader(notifyHeaderEntity);
            await _repository.SaveAsync();

            var notifyHeaderToReturn = _mapper.Map<NotifyHeaderDto>(notifyHeaderEntity);

            return CreatedAtRoute("notifyHeaderById", new { id = notifyHeaderToReturn.id }, notifyHeaderToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotifyHeader(int id, [FromBody] NotifyHeaderForUpdateDto notifyHeader)
        {
            var notifyHeaderEntity = HttpContext.Items["notifyHeader"] as NotifyHeader;

            _mapper.Map(notifyHeader, notifyHeaderEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifyHeader(int id)
        {
            var notifyHeader = HttpContext.Items["notifyHeader"] as NotifyHeader;

            _repository.NotifyHeader.DeleteNotifyHeader(notifyHeader);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
