using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

            var storeItemDtos = _mapper.Map<IEnumerable<StoreItemDto>>(storeItems)
                                  .GroupBy(m => m.model)
                                  .Select(g => new { model = g.Key, quantity = g.Sum(x => x.quantity) });



            return Ok(storeItemDtos);
        }

    }
}






//List<StoreItemDto> Lines = new List<StoreItemDto>();
//storeItemDtos = Lines
//          .GroupBy(m => m.model)
//          //.Select(g => new { model = g.Key, quantity = g.Sum(x => x.quantity) });
//          .Select(c => new StoreItemDto
//          {
//              itemDescription = c.First().itemDescription,
//              type = c.Count().ToString(),
//              quantity = c.Sum(c => c.quantity).ToString(),
//          }).ToListAsync();