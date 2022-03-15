namespace proxy.storage.local.service;

public class FileService
{
    public async Task<FileServiceResponse> SaveMemoryStreamToFile(FileServiceRequest fileServiceRequest)
    {
        var uploadFileResponse = new FileServiceResponse();
        var tempPath = Path.GetTempPath();
        var fileName = fileServiceRequest.FileName;
        var fileLocation = Path.Combine(tempPath, fileName);

        await File.WriteAllBytesAsync(fileLocation, fileServiceRequest.MemoryStream.ToArray());
        uploadFileResponse.FileLocation = fileLocation;
        return await Task.FromResult(uploadFileResponse);
    }

}

public class FileServiceResponse
{
    public string FileLocation { get; set; }
}

public class FileServiceRequest
{
    public string FileName { get; init; }
    public MemoryStream MemoryStream { get; init; }
}