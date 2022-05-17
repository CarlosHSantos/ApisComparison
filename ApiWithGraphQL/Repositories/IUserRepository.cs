using SharedClasses.Models;

namespace ApiComGraphQL.Repositories
{
    public interface IUserRepository
    {
        Task<UserPayload> AddUser(User usuario);
    }
}
