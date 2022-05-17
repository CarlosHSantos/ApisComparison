using ApiComGraphQL.Repositories;
using SharedClasses.Models;

namespace ApiComGraphQL.Mutations
{
    public class Mutation
    {
        public async Task<UserPayload> AddUser(User input, [Service] IUserRepository repository)
        {
            var usuarioGravado = await repository.AddUser(input);
            return usuarioGravado;
        }
    }
}
