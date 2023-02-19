using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        ISkillLogic _logic;
        public SkillController(ISkillLogic logic)
        {
            _logic = logic;
        }
        [HttpGet("FetchSkillsDetails")]
        public IActionResult Get([FromQuery] string email)
        {
            try
            {
                var skill = _logic.Get(email);
                if(skill != null)
                {
                    return Ok(skill);
                }
                else
                {
                    return BadRequest("No Details found");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("FetchSkill")]
        public IActionResult GetAll()
        {
            try
            {
                var skill = _logic.GetskillDetails();
                if(skill != null)
                {
                    return Ok(skill);
                }
                else
                {
                    return BadRequest("No Details found");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddSkills")]
        public IActionResult Add([FromQuery] string email,[FromBody] Models.Skills skills)
        {
            try
            {
                var newskill = _logic.AddSkillDetails(email,skills);
                return Created("Add", newskill);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] string email,string name)
        {
            try
            {
                var skill = _logic.Remove(email,name);
                if(skill != null)
                {
                    return Ok(skill);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] string email, string oldskill, [FromBody] Models.Skills skill)
        {
            try
            {
                if(!string.IsNullOrEmpty(email))
                {
                    _logic.UpdateUser(email, oldskill, skill);
                    return Ok(skill);
                }
                else
                {
                    return NotFound("No Details found");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
