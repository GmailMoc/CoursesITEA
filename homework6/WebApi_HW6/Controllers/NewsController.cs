using BasicInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BasicInfo.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsRepository _newsRepository { get; }

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string filterId, [FromQuery] string filterAuthor, [FromQuery] string filterFake)
        {
            List<News> news = _newsRepository.GetNews();
            try
            {
                if (!string.IsNullOrEmpty(filterId))
                    news = news.Where(n => n.Id == int.Parse(filterId)).ToList();

                if (!string.IsNullOrEmpty(filterAuthor))
                    news = news.Where(n => n.AuthorName == filterAuthor).ToList();

                if (!string.IsNullOrEmpty(filterFake))
                    news = news.Where(n => n.IsFake == bool.Parse(filterFake)).ToList();

                //return Ok(_newsRepository.GetNews());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(news);
        }

        [HttpPost]
        public IActionResult AddNews([FromBody] News news)
        {
            try
            {
                _newsRepository.AddNews(news);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateNews([FromBody] News news)
        {
            try
            {
                _newsRepository.DeleteNews(news.Id);
                _newsRepository.AddNews(news);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateNews(int id, [FromBody] JsonPatchDocument<News> patchDoc)
        {
            if (patchDoc != null)
            {
                News news = _newsRepository.GetNews().First(x => x.Id == id);

                patchDoc.ApplyTo(news, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(news);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public IActionResult DeleteNews([FromHeader] int newsId)
        {
            try
            {
                _newsRepository.DeleteNews(newsId);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}