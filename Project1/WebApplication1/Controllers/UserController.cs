using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using System.Reflection;
using Serilog;
using Microsoft.AspNetCore.Cors;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILogic _logic;
        IAgeLogic _agelogic;
        Validate _valid;
        public UserController(ILogic logic, IAgeLogic agelogic,Validate Valid)
        {
            _logic = logic;
            _agelogic = agelogic;
            _valid = Valid;
        }
        [HttpGet("FetchUserDetail")]
        public IActionResult Get([FromQuery] string email)
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
        public IActionResult Delete([FromQuery]string email,string password)
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

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] string email, [FromBody] Models.UserDetails userDetails)
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

        [HttpGet("Filter-Age")]
        public IActionResult Filter(int age)
        {
            try
            {
                var userDetails = _agelogic.Fetch(age);
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

        [HttpGet("Filter-Skill")]
        public IActionResult Filter(string skill)
        {
            try
            {
                var userDetails = _agelogic.Fetch(skill);
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

        [EnableCors("cors")]
        [HttpGet("Validate")]
        public IActionResult Validate(string email,string pswd) 
        {
            if(!_valid.CheckUser(email,pswd))
            {
                return Unauthorized("No Details Found");
            }
            else
            {
                return Ok("Details Found");
            }
        }
    }
}
