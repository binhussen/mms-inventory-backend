using AutoMapper;
using Newtonsoft.Json;
using Contracts.Service;
using Contracts.Interfaces;
using DataModel.Parameters;
using DataModel.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("api/storeitems")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public StoresController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet(Name = "GetStoreItems")]
        public async Task<IActionResult> GetAllStoreItems([FromQuery] StoreItemParameters storeItemParameters)
        {
            var storeItems = await _repository.StoreItem.GetAllStoreItemsAsync(storeItemParameters, trackChanges: false);
             Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(storeItems.MetaData));

            var storeItemDtos = _mapper.Map<IEnumerable<StoreItemDto>>(storeItems);

            return Ok(storeItemDtos);
        }
    }
}
