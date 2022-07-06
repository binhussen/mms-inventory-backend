using AutoMapper;
using Contracts.Service;
using DataModel;
using DataModel.Identity.Models;
using DataModel.Models.DTOs.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using System.Net;

namespace API.Controllers.Identity
{
    [Route("api/users")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly MMSDbContext _mmsDbContext;
        public AccountsController(ILoggerManager logger, IMapper mapper, UserManager<ApplicationUser> userManager, MMSDbContext mmsDbContext,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _mmsDbContext = mmsDbContext;
        }

        [HttpGet(Name = "users")/*, Authorize*/]
        public async Task<IActionResult> GetListUsers()
        {
            var users = await _mmsDbContext.Users.ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<AcountResponse>>(users);
            return Ok(usersDto);

        }

        [HttpPut("{id}"), /*Authorize*/]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForUpdateDto userForUpdateDto)
        {
            var users = await _userManager.FindByIdAsync(id.ToString());
            if (users == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return BadRequest();
            }
            var user = _mapper.Map(userForUpdateDto, users);

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("lock/{id}"), /*Authorize*/]
        public async Task<IActionResult> AccountLockedOut(Guid id)
        {
            var users = await _userManager.FindByIdAsync(id.ToString());
            if (users == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return BadRequest();
            }

            users.LockoutEnabled = !users.LockoutEnabled;

            IdentityResult result = await _userManager.UpdateAsync(users);
            if (result.Succeeded)
            {
                return Ok($"active : {users.LockoutEnabled}");
            }
            return BadRequest();
        }

        [HttpPost("signOut")]
        [SwaggerResponse(HttpStatusCode.NoContent, null, Description = "Valid Sign Out")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }


    }
}
