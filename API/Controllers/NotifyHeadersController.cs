using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("api/notifyHeaders")]
    [ApiController]
    public class NotifyHeadersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public NotifyHeadersController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetNotifyHeaders()
        {
            try
            {
                var notifyHeaders = _repository.NotifyHeader.GetAllNotifyHeadersAsync(trackChanges: false);
                return Ok(notifyHeaders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
