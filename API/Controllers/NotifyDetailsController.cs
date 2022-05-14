using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("api/notifyDetails")]
    [ApiController]
    public class NotifyDetailsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public NotifyDetailsController(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetNotifyDetails()
        {
            try
            {
                var notifyDetails = _repository.NotifyDetail.GetAllNotifyDetailsAsync(trackChanges: false);
                return Ok(notifyDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
