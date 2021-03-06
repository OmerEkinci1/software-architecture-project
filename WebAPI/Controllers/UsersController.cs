using Business.Abstract;
using Core.Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int userID)
        {
            var result = _userService.GetById(userID);

            if (result.Data != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalluserbystatustrue")]
        public IActionResult GetAllUserByStatusTrue()
        {
            var result = _userService.GetUserByStatusTrue();

            if (result.Data != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
