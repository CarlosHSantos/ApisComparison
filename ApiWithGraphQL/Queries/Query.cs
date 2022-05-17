using SharedClasses.Context;
using SharedClasses.Models;

namespace ApiComGraphQL.Queries
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> SearchUsers([Service] DefaultDbContext context) => context.Users;
    }
}
