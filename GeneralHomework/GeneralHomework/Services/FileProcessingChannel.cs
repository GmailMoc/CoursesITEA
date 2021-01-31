using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class FileProcessingChannel
    {
        private Channel<IFormFile> _channel;

        public FileProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<IFormFile>();
        }

        public async Task SetAsync(IFormFile file)
        {
             await _channel.Writer.WriteAsync(file);
        }

        private IFormFile Get()
        {
            IFormFile file;
            _channel.Reader.TryRead(out file);
            return file;
        }

        public async Task<IFormFile> GetAsync()
        {
            return await Task.Run(()=>Get());
        }

        public IAsyncEnumerable<IFormFile> GetAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }
    }
}
