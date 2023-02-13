using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactLogic _logic;
        public ContactController(IContactLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("FetchContact/{email}")]
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
        [HttpGet("FetchContact")]
        public IActionResult GetAll()
        {
            try
            {
                var ed = _logic.GetContacts();
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

        [HttpPost("AddContact/{email}")]
        public IActionResult Add([FromRoute] string email, [FromBody] Models.Contact ed)
        {
            try
            {
                var newed = _logic.AddEdDetails(email, ed);
                return Created("Add", newed);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
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
        public IActionResult Update([FromRoute] string email, [FromBody] Models.Contact ed)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateEd(email, ed);
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
