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

        [HttpGet("FetchContactDetails")]
        public IActionResult Get([FromQuery] string email)
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

        [HttpPost("AddContact")]
        public IActionResult Add([FromQuery] string email, [FromBody] Models.Contact ed)
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
        public IActionResult Delete([FromQuery] string email)
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

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] string email, [FromBody] Models.Contact ed)
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
