using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;
using Pillit.api.Contracts.IServices;
using Pillit.api.Models;
using Pillit.api.Services;
using System;
using System.Threading.Tasks;

namespace Pillit.api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        #region Constructor
        public UserController(IUserService userService)
        {
            _userService= userService;
        }
        #endregion

        [HttpGet]
        #region
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAllUsers() 
        {
            var allUsers =  await _userService.GetAllAsync();
            return Ok(  allUsers);
        }
        #endregion


        #region
        /// <summary>
        /// Create user for pillit account
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdUser = await _userService.CreateUser(user);
            return Ok(createdUser);
        }
        #endregion

        [Route("deleteUser")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid userId) 
        {
            if (userId != Guid.Empty)
            {
                var result = await _userService.DeleteAsync(userId);
                //success message deleted successfully
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
