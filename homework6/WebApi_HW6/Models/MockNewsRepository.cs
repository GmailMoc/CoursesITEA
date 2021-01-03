using System.Collections.Generic;
using System.Linq;

namespace BasicInfo.Models
{
    public class MockNewsRepository : INewsRepository 
    {
        private List<News> _news = new List<News>
        {
            new News { Id = 0, Title = "Humanity finally colonized the Mercury!!", Text = "", AuthorName = "Jeremy Clarkson", IsFake = true},
            new News { Id = 1, Title = "Increase your lifespan by 10 years, every morning you need...", Text = "", AuthorName = "Svetlana Sokolova", IsFake = true},
            new News { Id = 2, Title = "Scientists estimed the time of the vaccine invension: it is a summer of 2021", Text = "", AuthorName = "John Jones", IsFake = false},
            new News { Id = 3, Title = "Ukraine reduces the cost of its obligations!", Text = "", AuthorName = "Cerol Denvers", IsFake = false},
            new News { Id = 4, Title = "A species were discovered in Africa: it is blue legless cat", Text = "", AuthorName = "Jimmy Felon", IsFake = true}
        };

        public List<News> GetNews()
        {
            return _news;
        }

        public void AddNews(News news)
        {
            if (_news.FirstOrDefault(x => x.Id == news.Id) == null)
                _news.Add(news);

            //в else можно было бы выкидывать Exception, но я подумал, что это лишнее, так как мы просто считаем что элемент уже был добавлен ранее и не добавляем заново. 
        }

        public void DeleteNews(int id)
        {
            News news = _news.Single(x => x.Id == id);
            _news.Remove(news);
        }
    }
}