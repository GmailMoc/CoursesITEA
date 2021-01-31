using System.Collections.Generic;

namespace BasicInfo.Models
{
    public interface INewsRepository
    {
        List<News> GetNews();

        void AddNews(News news);

        void DeleteNews(int id);
    }
}