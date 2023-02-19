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

        [HttpGet("FetchCompanyDetails")]
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

        [HttpPost("AddCompany")]
        public IActionResult Add([FromQuery] string email, [FromBody] Models.Company ed)
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
        public IActionResult Delete([FromQuery] string email,string prev)
        {
            try
            {
                var ed = _logic.Remove(email,prev);
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
        public IActionResult Update([FromQuery] string email,string prev, [FromBody] Models.Company ed)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateEd(email,prev, ed);
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
