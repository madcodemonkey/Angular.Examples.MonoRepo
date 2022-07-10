using Acme.Services;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToolReportController : ControllerBase
{
    private readonly IToolReportService _toolReportService;

    public ToolReportController(IToolReportService toolReportService)
    {
        _toolReportService = toolReportService;
    }

    /// <summary>Generates a zip file stream for you to download.  The zip file will contain a CSV file inside of it.</summary>
    /// <param name="numberToCreate">The number of lines in the CSV file report.</param>
    [HttpGet("{numberToCreate}")]
    public async Task<ActionResult> GetToolReport([FromRoute] int numberToCreate)
    {
        var fileResult = _toolReportService.GetReport(numberToCreate);

        if (fileResult?.FileData == null) return new NoContentResult();

        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

        return File(fileResult.FileData, fileResult.MimeType, fileResult.FileName);
    }
}