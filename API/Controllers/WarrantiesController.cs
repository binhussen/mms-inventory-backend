using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Warranty;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/customers/{customerid}/warranties")]
    [ApiController]
    public class WarrantiesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public WarrantiesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerWarrantiesForCustomer(int customerid, [FromQuery] CustomerWarrantyParameters warrantyParameters)
        {

            var customer = await _repository.Customer.GetCustomerByIdAsync(customerid, trackChanges: false);
            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {customerid} doesn't exist in the database.");
                return NotFound();
            }

            var warrantyFromDb = await _repository.CustomerWarranty.GetCustomerWarrantysAsync(customerid, warrantyParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(warrantyFromDb.MetaData));

            var warrantiesDto = _mapper.Map<IEnumerable<WarrantyDto>>(warrantyFromDb);
            return Ok(warrantiesDto);

        }
        [HttpGet("{id}", Name = "GetWarrantyForCustomer")]
        public async Task<IActionResult> GetWarrantiesForCustomer(int customerid, int id)
        {
            var customer = await _repository.Customer.GetCustomerByIdAsync(customerid, trackChanges: false);
            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {customerid} doesn't exist in the database.");
                return NotFound();
            }

            var warrantyDb = await _repository.CustomerWarranty.GetCustomerWarrantyAsync(customerid, id, trackChanges: false);
            if (warrantyDb == null)
            {
                _logger.LogInfo($"CustomerWarranty with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var warranty = _mapper.Map<WarrantyDto>(warrantyDb);

            return Ok(warranty);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWarrantyForCustomer(int customerid, [FromBody] WarrantiyForCreationDto warranty)
        {
            if (warranty == null)
            {
                _logger.LogError("StoreItemForCreationDto object sent from client is null.");
                return BadRequest("StoreItemForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the StoreItemForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var customer = await _repository.Customer.GetCustomerByIdAsync(customerid, trackChanges: false);
            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {customerid} doesn't exist in the database.");
                return NotFound();
            }


            var warrantyEntity = _mapper.Map<CustomerWarranty>(warranty);

            _repository.CustomerWarranty.CreateCustomerWarrantyForCustomer(customerid, warrantyEntity);
            await _repository.SaveAsync();
            var warrantyToReturn = _mapper.Map<WarrantyDto>(warrantyEntity);
            return CreatedAtRoute("GetWarrantyForCustomer", new { customerid, id = warrantyToReturn.id }, warrantyToReturn);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarrantyForCustomer(int customerid, int id, [FromBody] WarrantyForUpdateDto warranty)
        {
            if (warranty == null)
            {
                _logger.LogError("WarrantyForUpdateDto object sent from client is null.");
                return BadRequest("WarrantyForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the WarrantyForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var customer = await _repository.Customer.GetCustomerByIdAsync(customerid, trackChanges: false);
            if (customer == null)
            {
                _logger.LogInfo($"NotifyHeader with id: {customerid} doesn't exist in the database.");
                return NotFound();
            }
            var warrantEntity = await _repository.CustomerWarranty.GetCustomerWarrantyAsync(customerid, id, trackChanges: true);
            if (warrantEntity == null)
            {
                _logger.LogInfo($"Warranty with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(warranty, warrantEntity);
            await _repository.SaveAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarranty(int customerid, int id)
        {
            var customer = await _repository.Customer.GetCustomerByIdAsync(customerid, trackChanges: false);
            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {customerid} doesn't exist in the database.");
                return NotFound();
            }

            var warrantyForCustomer = await _repository.CustomerWarranty.GetCustomerWarrantyAsync(customerid, id, trackChanges: false);
            if (warrantyForCustomer == null)
            {
                _logger.LogInfo($"NotifyItem with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.CustomerWarranty.DeleteCustomerWarranty(warrantyForCustomer);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
