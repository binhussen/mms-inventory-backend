using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Approve;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApprovesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ApprovesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("approves", Name = "GetAllApproves")]
        public async Task<IActionResult> GetAllApproves([FromQuery] ApproveParameters approveParameters)
        {
            var approves = await _repository.Approve.GetAllApprovesAsync(approveParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(approves.MetaData));

            var approveDtos = _mapper.Map<IEnumerable<ApproveDto>>(approves);
            return Ok(approveDtos);
        }
        [HttpGet("approve/{id}", Name = "ApproveById")]
        public async Task<IActionResult> GetApproveById(int id)
        {
            var approve = await _repository.Approve.GetApproveByIdAsync(id, trackChanges: false);
            if (approve == null)
            {
                _logger.LogInfo($"Customer with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var approveDto = _mapper.Map<ApproveDto>(approve);
                return Ok(approveDto);
            }
        }
        [HttpGet("approves/{requestid}", Name = "GetApproveForRequest")]
        public async Task<IActionResult> GetApprovesForRequest(int requestid, [FromQuery] ApproveParameters approveParameters)
        {
            var request = await _repository.RequestItem.GetRequestAsync(requestid, trackChanges: false);
            if (request == null)
            {
                _logger.LogInfo($"RequestItem with id: {requestid} doesn't exist in the database.");
                return NotFound();
            }

            var approvesFromDb = await _repository.Approve.GetAllApprovesAsync(requestid, approveParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(approvesFromDb.MetaData));

            var approvesDto = _mapper.Map<IEnumerable<ApproveDto>>(approvesFromDb);
            return Ok(approvesDto);
        }
    }
}
