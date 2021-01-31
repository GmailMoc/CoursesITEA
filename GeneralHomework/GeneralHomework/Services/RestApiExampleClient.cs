using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace GeneralHomework.Services
{
    public class RestApiExampleClient : IRestApiExampleClient
    {
        public byte[] GetFile(string imageName)
        {
            RestClient client = new RestClient("http://localhost:56090");
            RestRequest request = new RestRequest("File", Method.GET);
            request.AddParameter("imageName", imageName);
            IRestResponse response = client.Execute(request);
            byte[] content = response.RawBytes;
            return content;
        }

        public void UploadFile([MaybeNull] IFormFile file)
        {
            if (file == null)
                return;

            RestClient client = new RestClient("http://localhost:56090");
            RestRequest request = new RestRequest("File", Method.POST);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));
            }

            request.AddQueryParameter("fileName", file.FileName);
            IRestResponse response = client.Execute(request);
        }
    }
}
