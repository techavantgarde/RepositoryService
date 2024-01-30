using Microsoft.AspNetCore.Mvc;
using Service;

namespace Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CommitAnalyzerController : ControllerBase
    {
        [HttpGet(Name = "GetCommitStatus")]
        public IActionResult GetCommitStatus()
        {
            try
            {
                CommitAnalyzerService commitAnalyzerService = new();
                return Ok(commitAnalyzerService.GetCommitStatus());
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}