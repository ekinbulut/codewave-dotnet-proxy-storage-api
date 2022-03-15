using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proxy.storage.api.Models;
using proxy.storage.api.service;

namespace proxy.storage.api.Controllers
{
    [ApiController]
    [Route("/api")]
    public class FileReceiverController
    {
        private readonly IFileStorageProxy _fileStorageProxy;
        private ILogger<FileReceiverController> _logger;

        public FileReceiverController(IFileStorageProxy fileStorageProxy, ILogger<FileReceiverController> logger)
        {
            _fileStorageProxy = fileStorageProxy;
            _logger = logger;
        }

        [HttpPost("/file/upload")]
        [ProducesResponseType(typeof(ApiResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Upload([FromHeader] string documentType, [FromForm] IFormFile file)
        {
            var apiResponse = new ApiResponse();
            await using (var memoryStream = new MemoryStream())
            {
               await file.CopyToAsync(memoryStream);
               var proxyResponse = await _fileStorageProxy.UploadFile(file.FileName, memoryStream);
               apiResponse.Message = proxyResponse;
            }
            return await Task.FromResult<IActionResult>(new JsonResult(apiResponse));
        }
        
    }
}