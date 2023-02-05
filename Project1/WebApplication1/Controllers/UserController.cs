using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using System.Reflection;


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
        [HttpGet("FetchUser")]
        public IActionResult Get()
        {
            try
            {
                var userDetails = _logic.GetUserDetails();
                return Ok(userDetails);
                /*if (userDetails == null)
                {
                    return Ok(userDetails);
                }
                else
                {
                    return BadRequest("No Details found");
                }*/
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

        /*[HttpDelete("Delete")]
        public IActionResult Delete([fr])
        {

        }*/

    }
}
