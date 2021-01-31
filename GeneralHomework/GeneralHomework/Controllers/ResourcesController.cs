using GeneralHomework.Services;
using GeneralHomework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly IRestApiExampleClient _restClient;
        private readonly FileProcessingChannel _channel;
        private readonly ILoadFile _loadFile;

        public ResourcesController(IRestApiExampleClient restClient, ILoadFile loadFile, FileProcessingChannel channel)
        {
            _loadFile = loadFile;
            _restClient = restClient;
            _channel = channel;
        }

        public FileContentResult Get(string imageName)
        {
            byte[] image = _loadFile.GetImage(imageName);

            if (image == null)
            {
                image = _restClient.GetFile(imageName);
                _loadFile.CacheSet(image, imageName);
            }

            return new FileContentResult(image, "image/jpeg");
        }

        [HttpGet]
        public IActionResult Upload()
        {
            ResourceUploadViewModel viewModel = new ResourceUploadViewModel();
            viewModel.UploadStage = UploadStage.Upload;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Upload(ResourceUploadViewModel viewModel)
        {
            MemoryCacheEntryOptions entryOptions = new MemoryCacheEntryOptions();
            entryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

            if (viewModel.File?.Length > 0)
            {
                _channel.SetAsync(viewModel.File);
                viewModel.File = null;
                viewModel.UploadStage = UploadStage.Comleted;
            }

            return View(viewModel);
        }
    }
}
