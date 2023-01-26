using CWProject.Services;
using CWProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICourseWorkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFReportController : ControllerBase
    {
        private readonly IPDFReport _pdfReport;

        public PDFReportController(IPDFReport pdfReport)
        {
            _pdfReport = pdfReport;
        }

        [HttpGet]
        public IActionResult GetPDF()
        {
            _pdfReport.ExportPDF();
            return Ok("PDF Report Created.");
        }
    }
}
