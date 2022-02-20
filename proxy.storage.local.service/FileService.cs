namespace proxy.storage.local.service;

public class FileService
{
    public async Task<UploadFileServiceResponse> SaveMemoryStreamIntoFile(UploadFileServiceRequest uploadFileRequest)
    {
        var uploadFileResponse = new UploadFileServiceResponse();
        var tempPath = Path.GetTempPath();
        var fileName = uploadFileRequest.FileName;
        var fileLocation = Path.Combine(tempPath, fileName);

        await File.WriteAllBytesAsync(fileLocation, uploadFileRequest.MemoryStream.ToArray());
        uploadFileResponse.FileLocation = fileLocation;
        return await Task.FromResult(uploadFileResponse);
    }

}

public class UploadFileServiceResponse
{
    public string FileLocation { get; set; }
}

public class UploadFileServiceRequest
{
    public string FileName { get; init; }
    public MemoryStream MemoryStream { get; init; }
}