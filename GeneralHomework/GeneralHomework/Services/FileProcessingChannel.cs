using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class FileProcessingChannel
    {
        private Channel<(string, byte[])> _channel;

        public FileProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<(string, byte[])>();
        }

        public async Task SetAsync(IFormFile file)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                await _channel.Writer.WriteAsync((file.FileName, stream.ToArray()));
            }
        }

        private (string, byte[]) Get()
        {
            (string, byte[]) file;
            _channel.Reader.TryRead(out file);
            return file;
        }

        public async Task<(string, byte[])> GetAsync()
        {
            return await Task.Run(()=>Get());
        }

        public IAsyncEnumerable<(string, byte[])> GetAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }
    }
}
