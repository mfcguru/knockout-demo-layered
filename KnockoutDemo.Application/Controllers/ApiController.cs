using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KnockoutDemo.Application.Controllers
{
    using KnockoutDemo.Business.BusinessRules;
    using KnockoutDemo.Business.Services.Csv;
    using KnockoutDemo.Business.Services.Report;

    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private ICsvService csvService;
        private IReportService reportService;

        public ApiController(ICsvService csvService, IReportService reportService)
        {
            this.csvService = csvService;
            this.reportService = reportService;
        }

        [DisableRequestSizeLimit]
        [HttpPost("csv/upload")]
        public async Task<ActionResult> UploadCsvFile([FromForm]IFormFile file)
        {
            try
            {
                await csvService.ParseAndSave(file);

                return Ok();
            }
            catch(BusinessRulesException e)
            {
                return StatusCode((int)e.StatusCode, e.Message);
            }
        }

        [HttpGet("report")]
        public async Task<ActionResult> GetAllUsers()
        {
            var result = await reportService.GetAllUsers();

            return Ok(result);
        }

        [HttpDelete("report")]
        public async Task<ActionResult> DeleteAllUsers()
        {
            await reportService.DeleteAllUsers();

            return Ok();
        }
    }
}
