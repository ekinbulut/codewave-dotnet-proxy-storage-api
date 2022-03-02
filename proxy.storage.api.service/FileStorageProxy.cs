using proxy.storage.local.service;

namespace proxy.storage.api.service;

public interface IFileStorageProxy
{
    Task<UploadFileServiceResponse> UploadFile(string fileName, MemoryStream stream);
}

public class FileStorageProxy : IFileStorageProxy
{
    public async Task<UploadFileServiceResponse> UploadFile(string fileName, MemoryStream stream)
    {
        var localStorageFactory = new LocalStorageService();
        var fileService = localStorageFactory.GetFileService();

        var response = await fileService.SaveMemoryStreamIntoFile(new UploadFileServiceRequest()
        {
            FileName = fileName,
            MemoryStream = stream
        });

        return await Task.FromResult(response);
    }
}