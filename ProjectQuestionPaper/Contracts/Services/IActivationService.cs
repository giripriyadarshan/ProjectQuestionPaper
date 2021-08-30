using System.Threading.Tasks;

namespace ProjectQuestionPaper.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
