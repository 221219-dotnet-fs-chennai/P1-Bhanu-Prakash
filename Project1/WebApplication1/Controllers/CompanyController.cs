using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyLogic _logic;
        
        public CompanyController(ICompanyLogic logic)
        {
                _logic = logic;
        }

        [HttpGet("FetchCompany/{email}")]
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
        [HttpGet("FetchCompany")]
        public IActionResult GtAll()
        {
            try
            {
                var ed = _logic.GetCompanies();
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

        [HttpPost("AddCompany/{email}")]
        public IActionResult Add([FromRoute] string email, [FromBody] Models.Company ed)
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
        public IActionResult Update([FromRoute] string email, [FromBody] Models.Company ed)
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
