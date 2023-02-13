using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        IEducationLogic _logic;
        public EducationController(IEducationLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("FetchEducation/{email}")]
        public IActionResult Get([FromRoute] string email)
        {
            try
            {
                var ed = _logic.Get(email);
                if (ed != null)
                {
                    return Ok(ed);
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
        [HttpGet("FetchEducation")]
        public IActionResult GetAll()
        {
            try
            {
                var ed = _logic.GetEducations();
                if (ed != null)
                {
                    return Ok(ed);
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

        [HttpPost("AddEducation/{email}")]
        public IActionResult Add([FromRoute] string email, [FromBody] Models.Education ed)
        {
            try
            {
                var newed = _logic.AddEdDetails(email, ed);
                return Created("Add", newed);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromHeader] string email)
        {
            try
            {
                var ed = _logic.Remove(email);
                if (ed != null)
                {
                    return Ok(ed);
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

        [HttpPut("Update/{email}")]
        public IActionResult Update([FromRoute] string email,[FromBody] Models.Education ed)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateEd(email,ed);
                    return Ok(ed);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
