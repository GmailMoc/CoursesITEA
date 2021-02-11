using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public interface IRestApiExampleClient
    {
        public byte[] GetFile(string imageName);
        public void UploadFile([NotNull]string fileName, byte[] fileByte);
    }
}
