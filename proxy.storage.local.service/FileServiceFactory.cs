namespace proxy.storage.local.service;

public abstract class FileServiceFactory
{
    public abstract FileService GetFileService();
}

public class LocalStorageService : FileServiceFactory
{
    public override FileService GetFileService()
    {
        return new FileService();
    }
}