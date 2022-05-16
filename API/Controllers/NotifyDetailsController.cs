using AutoMapper;
using Newtonsoft.Json;
using Contracts.Interfaces;
using DataModel.Parameters;
using DataModel.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataModel.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Controllers
{
    [Route("api/notifyDetails/{notifyHeaderId}/notifyDetails")]
    [ApiController]
    public class NotifyDetailsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public NotifyDetailsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetNotifyDetailsForNotifyHeader(int notifyHeaderId)
        {

            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyHeaderId, trackChanges: false);
            if (notifyHeader == null)
            {
                //TODO: here add message response or logger message
                return NotFound();
            }

            var notifyDetailsFromDb = await _repository.NotifyDetail.GetNotifyDetailsAsync(notifyHeaderId, trackChanges: false);

            var notifyDetailsDto = _mapper.Map<IEnumerable<NotifyDetailDto>>(notifyDetailsFromDb);
            return Ok(notifyDetailsDto);

        }

        [HttpGet("{id}", Name = "GetNotifyDetailForNotifyHeader")]
        public async Task<IActionResult> GetNotifyDetailForNotifyHeader(int notifyHeaderId, int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyHeaderId, trackChanges: false);
            if (notifyHeader == null)
            {
                //TODO: here add message response or logger message
                return NotFound();
            }

            var notifyDetailDb = await _repository.NotifyDetail.GetNotifyDetailAsync(notifyHeaderId, id, trackChanges: false);
            if (notifyDetailDb == null)
            {
               //TODO: here add message response or logger message
                return NotFound();
            }

            var notifyDetail = _mapper.Map<NotifyDetailDto>(notifyDetailDb);

            return Ok(notifyDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotifyDetailForNotifyHeader(int notifyHeaderId, [FromBody] NotifyDetailForCreationDto notifyDetail)
        {
            if (notifyDetail == null)
            {
                //TODO: here add message response or logger message
                return BadRequest("NotifyDetailForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                //TODO: here add message response or logger message
                return UnprocessableEntity(ModelState);
            }
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyHeaderId, trackChanges: false);
            if(notifyHeader == null)
            {
                 //TODO: here add message response or logger message
                return NotFound();
            }

            var notifyDetailEntity = _mapper.Map<NotifyDetail>(notifyDetail);

            _repository.NotifyDetail.CreateNotifyDetailForNotifyHeader(notifyHeaderId, notifyDetailEntity);
            await _repository.SaveAsync();
            var notifyDetailToReturn = _mapper.Map<NotifyDetailDto>(notifyDetailEntity);
            return CreatedAtRoute("GetNotifyDetailForNotifyHeader", new { notifyHeaderId, id = notifyDetailToReturn.id }, notifyDetailToReturn);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotifyDetailForNotifyHeader(int notifyHeaderId, int id, [FromBody] NotifyDetailForUpdateDto notifyDetail)
        {
            if (notifyDetail == null)
            {
                //TODO: here add message response or logger message
                return BadRequest("NotifyDetailForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                 //TODO: here add message response or logger message
                return UnprocessableEntity(ModelState);
            }

            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyHeaderId, trackChanges: false);
            if (notifyHeader == null)
            {
                //TODO: here add message response or logger message
                return NotFound();
            }
            var notifyDetailEntity = await _repository.NotifyDetail.GetNotifyDetailAsync(notifyHeaderId, id, trackChanges: true);
            if (notifyDetailEntity == null)
            {
                //TODO: here add message response or logger message
                return NotFound();
            }

            _mapper.Map(notifyDetail, notifyDetailEntity);
            await _repository.SaveAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifyHeader(int notifyHeaderId, int id)
        {
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyHeaderId, trackChanges: false);
            if (notifyHeader == null)
            {
                 //TODO: here add message response or logger message
                return NotFound();
            }

            var notifyDetailForNotifyHeader = await _repository.NotifyDetail.GetNotifyDetailAsync(notifyHeaderId, id, trackChanges: false);
            if (notifyDetailForNotifyHeader == null)
            {
                 //TODO: here add message response or logger message
                return NotFound();
            }

            _repository.NotifyDetail.DeleteNotifyDetail(notifyDetailForNotifyHeader);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
