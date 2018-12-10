using Eventures.ViewModels;

namespace Eventures.Services.AccountServices
{
    public interface IAccountService
    {
        void CreateUser(RegisterViewModel model);
    }
}
