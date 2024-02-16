using MentalHealthApp.PWA.Models;

namespace MentalHealthApp.PWA.Services.Interfaces
{
    public interface IApiService 
    {
        Task<LoginResponse?> SignInUser(string email, string password); 

        Task<SignUpResponse?> SignUpUser(string userName, string firstName, string lastName, string phoneNumber, string email, string password);

        Task<ApiAppUser?> GetAppUser(string token);
    }
}
