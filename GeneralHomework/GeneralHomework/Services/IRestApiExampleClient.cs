using Microsoft.AspNetCore.Http;
namespace GeneralHomework.Services
{
    public interface IRestApiExampleClient
    {
        public byte[] GetFile(string imageName);
        public void UploadFile(IFormFile file);
    }
}
