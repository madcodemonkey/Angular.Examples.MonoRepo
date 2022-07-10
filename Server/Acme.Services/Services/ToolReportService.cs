using Acme.Models;
using CsvConverter;

namespace Acme.Services
{
    public class ToolReportService : IToolReportService
    {
        private readonly IZipService _zipService;

        /// <summary>Constructor</summary>
        public ToolReportService(IZipService zipService)
        {
            _zipService = zipService;
        }

        /// <summary>Creates a zip file with a CSV file inside of it.</summary>
        /// <param name="toolCount">The number of records to put in the CSV file.</param>
        public FileStreamResult GetReport(int toolCount)
        {
            var result = new FileStreamResult
            {
                FileName = "Tool.zip",
                MimeType = "application/octet-stream",
            };

            if (toolCount == 0) return result;

            using var csvFileStream = new MemoryStream();

            using (var sw = new StreamWriter(csvFileStream, leaveOpen: true))
            {
                var writerService = new CsvWriterService<ToolItem>(sw);

                foreach (var tool in CreateToolItemList(toolCount))
                {
                    writerService.WriteRecord(tool);
                }
            }

            csvFileStream.Position = 0;

            result.FileData = _zipService.CreateZipStreamForOneFile(csvFileStream, "Tool.csv", leaveOpen: true);
            result.FileData.Position = 0;

            return result;
        }

        private static List<ToolItem> CreateToolItemList(int numberToCreate)
        {
            var result = new List<ToolItem>();

            var rand = new Random(DateTime.Now.Millisecond);

            for (int i = 1; i <= numberToCreate; i++)
            {
                result.Add(new ToolItem()
                {
                    Id = i,
                    Name = $"Tool-{i}",
                    Cost = rand.Next(1, 100) + (rand.Next(1, 100) * 0.01),
                    DateCreated = DateTime.Now.AddDays(rand.Next(200, 3000) * -1)
                });

            }

            return result;
        }

    }
}
