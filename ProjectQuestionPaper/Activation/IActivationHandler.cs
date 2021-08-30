using System.Threading.Tasks;

namespace ProjectQuestionPaper.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
