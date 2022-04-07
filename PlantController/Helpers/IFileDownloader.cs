namespace PlantController.Helpers
{
    public interface IFileDownloader
    {
        void DownloadFile(string fileUrl, string fileDestination);
    }
}