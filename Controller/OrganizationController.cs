using Microsoft.AspNetCore.Mvc;

namespace Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        public IActionResult GetAllOrganizations()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}