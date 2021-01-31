using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public void UploadFile(IFormFile file)
        {
            if (file == null)
                return;

            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.POST);
            using (var stream = new MemoryStream())
            {
                try
                {
                    file.CopyTo(stream);
                }
                catch (Exception e)
                {
                    var message = e.Message;
                }
                request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));

                request.AddQueryParameter("fileName", file.FileName);
                client.Execute(request);
            }
        }
    }
}
