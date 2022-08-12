using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Procurements;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/procurements")]
    [ApiController]
    public class ProcurementsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ProcurementsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetProcurements")]
        public async Task<IActionResult> GetProcurements([FromQuery] ProcurementParameters procurementsParameters)
        {
            var procurements = await _repository.Procurement.GetAllProcurementsAsync(procurementsParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(procurements.MetaData));

            var ProcurementDtos = _mapper.Map<IEnumerable<ProcurementDto>>(procurements);

            return Ok(ProcurementDtos);
        }
        [HttpGet("{id}", Name = "ProcurementById")]
        public async Task<IActionResult> GetProcurement(int id)
        {
            var procurement = await _repository.Procurement.GetProcurementAsync(id, trackChanges: false);
            if (procurement == null)
            {
                _logger.LogInfo($"Procurement with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var procurementDto = _mapper.Map<ProcurementDto>(procurement);
                return Ok(procurementDto);
            }
        }
        [HttpPost(Name = "CreateProcurement")]
        public async Task<IActionResult> CreateProcurement([FromBody] ProcurementForCreationDto procurement)
        {
            if (procurement == null)
            {
                _logger.LogError("ProcurementForCreationDto object sent from client is null.");
                return BadRequest("ProcurementForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProcurementForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var procurementEntity = _mapper.Map<Procurement>(procurement);

            _repository.Procurement.CreateProcurement(procurementEntity);
            await _repository.SaveAsync();

            var procurementToReturn = _mapper.Map<ProcurementDto>(procurementEntity);

            // Disable BCC4002
            return CreatedAtRoute("procurementById", new { id = procurementToReturn.id }, procurementToReturn);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcurement(int id)
        {
            var procurement = await _repository.Procurement.GetProcurementAsync(id, trackChanges: false);
            if (procurement == null)
            {
                _logger.LogInfo($"Procurement with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Procurement.DeleteProcurement(procurement);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
