using AutoMapper;
using Contracts.Service;
using Contracts.Interfaces;
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
        public async Task<IActionResult> GetAllStoreItems()
        {
            var storeItems = await _repository.StoreItem.GetAllStoreItemsAsync(trackChanges: false);

            var storeItemDtos = _mapper.Map<IEnumerable<StoreItemDto>>(storeItems);

            return Ok(storeItemDtos);
        }
    }
}
