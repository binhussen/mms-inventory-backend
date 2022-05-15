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
        public async Task<IActionResult> GetNotifyDetailsForNotifyHeader(int notifyHeaderId, [FromQuery] NotifyDetailParameters notifyDetailParameters)
        {

            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyHeaderId, trackChanges: false);
            if (notifyHeader == null)
            {
                //TODO: here add message response or logger message
                return NotFound();
            }

            var notifyDetailsFromDb = await _repository.NotifyDetail.GetNotifyDetailsAsync(notifyHeaderId, notifyDetailParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(notifyDetailsFromDb.MetaData));

            var notifyDetailsDto = _mapper.Map<IEnumerable<NotifyDetailDto>>(notifyDetailsFromDb);
            return Ok(notifyDetailsFromDb);

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
            var notifyHeader = await _repository.NotifyHeader.GetNotifyHeaderAsync(notifyHeaderId, trackChanges: false);
            if(notifyHeader == null)
            {
                 //TODO: here add message response or logger message
                return NotFound();
            }

            var notifyDetailEntity = _mapper.Map<NotifyDetail>(notifyDetail);

            _repository.NotifyDetail.CreateNotifyDetailForNotifyHeader(notifyHeaderId, notifyDetailEntity);
            await _repository.SaveAsync();
            var notifyDetailToReturn = _mapper.Map<NotifyDetailDto>(notifyDetail);
            return CreatedAtRoute("GetNotifyDetailForNotifyHeader", new { notifyHeaderId, id = notifyDetailToReturn.id }, notifyDetailToReturn);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotify(Guid id, [FromBody] NotifyHeaderForUpdateDto notify)
        {
            var notifyEntity = HttpContext.Items["notify"] as NotifyHeader;

            _mapper.Map(notify, notifyEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifyHeader(int id)
        {
            var notify = HttpContext.Items["notify"] as NotifyHeader;

            _repository.NotifyHeader.DeleteNotifyHeader(notify);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
