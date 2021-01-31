using Microsoft.AspNetCore.Http;

namespace GeneralHomework.ViewModels
{
    public class ResourceUploadViewModel
    {
        public IFormFile File { get; set; }
        public UploadStage UploadStage { get; set; }
    }

    public enum UploadStage
    {
        Upload,
        Comleted
    }
}
