using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Hrs;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/hrs")]
    [ApiController]
    public class HrsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public HrsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetAllHrs")]
        public async Task<IActionResult> GetAllHrs([FromQuery] HrParameters hrParameters)
        {
            var hrs = await _repository.Hrs.GetAllHrsAsync(hrParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(hrs.MetaData));

            var hrDtos = _mapper.Map<IEnumerable<HrDto>>(hrs);
            return Ok(hrDtos);
        }
        [HttpGet("{id}", Name = "HrById")]
        public async Task<IActionResult> GetHr(int id)
        {
            var hr = await _repository.Hrs.GetHrByIdAsync(id, trackChanges: false);
            if (hr == null)
            {
                _logger.LogInfo($"HR with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var hrDto = _mapper.Map<HrDto>(hr);
                return Ok(hrDto);
            }
        }
        [HttpPost(Name = "CreateHr")]
        public async Task<IActionResult> CreateHrs([FromBody] HrForCreationDto hr)
        {
            if (hr == null)
            {
                _logger.LogError("HrForCreationDto object sent from client is null.");
                return BadRequest("HrForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the HrForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var hrEntity = _mapper.Map<HR>(hr);

            _repository.Hrs.CreateHr(hrEntity);
            await _repository.SaveAsync();

            var hrToReturn = _mapper.Map<HrDto>(hrEntity);

            // Disable BCC4002
            return CreatedAtRoute("hrByID", new { id = hrToReturn.id }, hrToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHr(int id, [FromBody] HrForUpdateDto hr)
        {
            if (hr == null)
            {
                _logger.LogError("HrForUpdateDto object sent from client is null.");
                return BadRequest("HrForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the HrForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var hrEntity = await _repository.Hrs.GetHrByIdAsync(id, trackChanges: true);
            if (hrEntity == null)
            {
                _logger.LogInfo($"HR with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(hr, hrEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehr(int id)
        {
            var hr = await _repository.Hrs.GetHrByIdAsync(id, trackChanges: false);
            if (hr == null)
            {
                _logger.LogInfo($"HR with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Hrs.DeleteHr(hr);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
