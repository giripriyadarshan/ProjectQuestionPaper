using System;

namespace ProjectQuestionPaper.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
