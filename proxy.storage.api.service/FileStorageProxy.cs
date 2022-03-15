using proxy.storage.local.service;

namespace proxy.storage.api.service;

public interface IFileStorageProxy
{
    Task<FileServiceResponse> UploadFile(string fileName, MemoryStream stream);
}

public class FileStorageProxy : IFileStorageProxy
{
    public async Task<FileServiceResponse> UploadFile(string fileName, MemoryStream stream)
    {
        var localStorageFactory = new LocalStorageService();
        var fileService = localStorageFactory.GetFileService();

        var response = await fileService.SaveMemoryStreamToFile(new FileServiceRequest()
        {
            FileName = fileName,
            MemoryStream = stream
        });

        return await Task.FromResult(response);
    }
}