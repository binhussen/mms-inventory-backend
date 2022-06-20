using AutoMapper;
using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.DTOs.Customers;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CustomersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet(Name = "GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] CustomerParameters customerParameters)
        {
            var customers = await _repository.Customer.GetAllCustomersAsync(customerParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(customers.MetaData));

            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }
        [HttpGet("{id}", Name = "CustomerById")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _repository.Customer.GetCustomerByIdAsync(id, trackChanges: false);
            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var customerDto = _mapper.Map<CustomerDto>(customer);
                return Ok(customerDto);
            }
        }
        [HttpPost(Name = "CreateCustomer")]
        public async Task<IActionResult> CreateCustomers([FromBody] CustomerForCreationDto customer)
        {
            if (customer == null)
            {
                _logger.LogError("CustomerForCreationDto object sent from client is null.");
                return BadRequest("CustomerForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CustomerForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var customerEntity = _mapper.Map<Customer>(customer);

            _repository.Customer.CreateCustomer(customerEntity);
            await _repository.SaveAsync();

            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);

            // Disable BCC4002
            return CreatedAtRoute("customerByID", new { id = customerToReturn.id }, customerToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerForUpdateDto customer)
        {
            if (customer == null)
            {
                _logger.LogError("CustomerForUpdateDto object sent from client is null.");
                return BadRequest("CustomerForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the CustomerForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var customerEntity = await _repository.Customer.GetCustomerByIdAsync(id, trackChanges: true);
            if (customerEntity == null)
            {
                _logger.LogInfo($"Customer with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(customer, customerEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _repository.Customer.GetCustomerByIdAsync(id, trackChanges: false);
            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Customer.DeleteCustomer(customer);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
