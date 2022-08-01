using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Distribute;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/distributes")]
    [ApiController]
    public class DistributesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public DistributesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetDistributes([FromQuery] DistributeParameters distributeParameters)
        {
            var distributesFromDb = await _repository.Distribute.GetDistributesAsync(distributeParameters, trackChanges: false);
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(distributesFromDb.MetaData));

            var distributeDtos = _mapper.Map<IEnumerable<DistributeDto>>(distributesFromDb);
            return Ok(distributeDtos);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistribute(int id)
        {
            var distributeDb = await _repository.Distribute.GetDistributeAsync(id, trackChanges: false);
            if (distributeDb == null)
            {
                _logger.LogInfo($"Distribute with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var distributeDto = _mapper.Map<DistributeDto>(distributeDb);

            return Ok(distributeDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDistribute([FromBody] DistributeForCreationDto distribute)
        {
            if (distribute == null)
            {
                _logger.LogError("Distribute object sent from client is null.");
                return BadRequest("Distribute object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the Distribute object");
                return UnprocessableEntity(ModelState);
            }
            var distributeEntity = _mapper.Map<Distribute>(distribute);

            _repository.Distribute.CreateDistribute(distributeEntity);
            await _repository.SaveAsync();
            var distributeToReturn = _mapper.Map<DistributeDto>(distributeEntity);
            return CreatedAtRoute(new { id = distributeToReturn.id }, distributeToReturn);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDistribute(int id, [FromBody] DistributeForUpdateDto distribute)
        {
            if (distribute == null)
            {
                _logger.LogError("DistributeDTO object sent from client is null.");
                return BadRequest("DistributeDTO object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the DistributeDTO object");
                return UnprocessableEntity(ModelState);
            }
            var distributeEntity = await _repository.Distribute.GetDistributeAsync(id, trackChanges: true);
            if (distributeEntity == null)
            {
                _logger.LogInfo($"Distribute with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(distribute, distributeEntity);
            await _repository.SaveAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistribute(int id)
        {
            var distribute = await _repository.Distribute.GetDistributeAsync(id, trackChanges: false);
            if (distribute == null)
            {
                _logger.LogInfo($"Distribute with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Distribute.DeleteDistribute(distribute);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
