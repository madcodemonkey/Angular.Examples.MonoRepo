using Acme.Models;

namespace Acme.Services;

public interface IToolReportService
{
    /// <summary>Creates a zip file with a CSV file inside of it.</summary>
    /// <param name="toolCount">The number of records to put in the CSV file.</param>
    FileStreamResult GetReport(int toolCount);
}