using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileService _fileService;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportFile(IFormFile file)
        {
            
            await _fileService.ImportFileAsync(new CreateModelsFromImportFileRequest(file.OpenReadStream(), file.FileName));
            return Ok();
        }
        [HttpGet("export")]
        public FileResult ExportModelsToXmlFile()
        {
            return new FileStreamResult(_fileService.ExportModelsToXml(), "application/octet-stream");
        }

    }
}
