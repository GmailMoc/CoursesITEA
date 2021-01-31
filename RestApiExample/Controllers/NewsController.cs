using BasicInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicInfo.Controllers
{
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsRepository _newsRepository { get; }

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet("News")]
        public IActionResult Index()
        {
            try
            {
                return Ok(_newsRepository.GetNews());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("News")]
        public IActionResult AddNews([FromBody] News news)
        {
            try
            {
                _newsRepository.AddNews(news);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("News")]
        public IActionResult DeleteNews([FromHeader] int newsId)
        {
            try
            {
                _newsRepository.DeleteNews(newsId);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}