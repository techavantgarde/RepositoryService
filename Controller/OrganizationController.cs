using DTO.Organization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        [HttpPost("GetAllOrganizations")]
        public IActionResult GetAllOrganizations(OrganizationRequest organizationRequest)
        {
            try
            {
                OrganizationService organizationService = new();
                return Ok(organizationService.GetAllOrganizations(organizationRequest));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}