using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using System.Reflection;
using Serilog;


namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILogic _logic;
        public UserController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpGet("FetchUser/{email}")]
        public IActionResult Get([FromRoute] string email)
        {
            try
            {
                var userDetails = _logic.Get(email);
                if (userDetails != null)
                {
                    return Ok(userDetails);
                }
                else
                {
                    return BadRequest("No Details found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FetchUser")]
        public IActionResult GetAll()
        {
            try
            {
                var userDetails = _logic.GetUserDetails();
                if (userDetails != null)
                {
                    return Ok(userDetails);
                }
                else
                {
                    return BadRequest("No Details found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddTrainer")]
        public IActionResult Add([FromBody] Models.UserDetails userDetails)
        {
            try
            {
                var newuser = _logic.AddUserDetails(userDetails);
                return Created("Add", newuser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromHeader]string email,string password)
        {
            try
            {
                var userDel = _logic.Remove(email,password);
                if(userDel != null)
                {
                    return Ok(userDel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{email}")]
        public IActionResult Update([FromRoute] string email, [FromBody] Models.UserDetails userDetails)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateUser(email, userDetails);
                    return Ok(userDetails);
                }
                else
                    return NotFound();  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

    }
}
