﻿using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Procurements;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/procurements/{procurementid}/items")]
    [ApiController]
    public class ProcurementItemsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ProcurementItemsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProcurementItemsForProcurement(int procurementid, [FromQuery] ProcurementItemParameters procurementItemParameters)
        {

            var procurement = await _repository.Procurement.GetProcurementAsync(procurementid, trackChanges: false);
            if (procurement == null)
            {
                _logger.LogInfo($"Procurement with id: {procurementid} doesn't exist in the database.");
                return NotFound();
            }

            var procurementItemsFromDb = await _repository.ProcurementItem.GetProcurementItemsAsync(procurementid, procurementItemParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(procurementItemsFromDb.MetaData));

            var procurementItemsDto = _mapper.Map<IEnumerable<ProcurementItemDto>>(procurementItemsFromDb);
            return Ok(procurementItemsDto);

        }
        [HttpGet("{id}", Name = "GetProcurementItemForProcurement")]
        public async Task<IActionResult> GetProcurementItemForProcurement(int procurementid, int id)
        {
            var procurement = await _repository.Procurement.GetProcurementAsync(procurementid, trackChanges: false);
            if (procurement == null)
            {
                _logger.LogInfo($"Procurement with id: {procurementid} doesn't exist in the database.");
                return NotFound();
            }

            var procurementItemDb = await _repository.ProcurementItem.GetProcurementItemAsync(procurementid, id, trackChanges: false);
            if (procurementItemDb == null)
            {
                _logger.LogInfo($"ProcurementItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var procurementItem = _mapper.Map<ProcurementItemDto>(procurementItemDb);

            return Ok(procurementItem);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProcurementItemForProcurement(int procurementid, [FromBody] ProcurementItemForCreationDto procurementItem)
        {
            if (procurementItem == null)
            {
                _logger.LogError("ProcurementItemForCreationDto object sent from client is null.");
                return BadRequest("ProcurementItemForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProcurementItemForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var procurement = await _repository.Procurement.GetProcurementAsync(procurementid, trackChanges: false);
            if (procurement == null)
            {
                _logger.LogInfo($"Procurement with id: {procurementid} doesn't exist in the database.");
                return NotFound();
            }

            var procurementItemEntity = _mapper.Map<ProcurementItem>(procurementItem);

            _repository.ProcurementItem.CreateProcurementItemForProcurement(procurementid, procurementItemEntity);
            await _repository.SaveAsync();
            var procurementItemToReturn = _mapper.Map<ProcurementItemDto>(procurementItemEntity);
            return CreatedAtRoute("GetProcurementItemForProcurement", new { procurementid, id = procurementItemToReturn.id }, procurementItemToReturn);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProcuremenetItemForProcuremenet(int procurementid, int id, [FromBody] ProcurementItemForUpdateDto procuremenetItem)
        {
            if (procuremenetItem == null)
            {
                _logger.LogError("ProcurementItemForUpdateDto object sent from client is null.");
                return BadRequest("ProcurementItemForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProcurementItemForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var procuremenet = await _repository.Procurement.GetProcurementAsync(procurementid, trackChanges: false);
            if (procuremenet == null)
            {
                _logger.LogInfo($"Procurement with id: {procurementid} doesn't exist in the database.");
                return NotFound();
            }
            var procuremenetItemEntity = await _repository.ProcurementItem.GetProcurementItemAsync(procurementid, id, trackChanges: true);
            if (procuremenetItemEntity == null)
            {
                _logger.LogInfo($"Procurement with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(procuremenetItem, procuremenetItemEntity);
            await _repository.SaveAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcuremenet(int procuremenetid, int id)
        {
            var procuremenet = await _repository.Procurement.GetProcurementAsync(procuremenetid, trackChanges: false);
            if (procuremenet == null)
            {
                _logger.LogInfo($"Procurement with id: {procuremenetid} doesn't exist in the database.");
                return NotFound();
            }

            var procurementItemForProcurement = await _repository.ProcurementItem.GetProcurementItemAsync(procuremenetid, id, trackChanges: false);
            if (procurementItemForProcurement == null)
            {
                _logger.LogInfo($"ProcurementItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.ProcurementItem.DeleteProcurementItem(procurementItemForProcurement);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
