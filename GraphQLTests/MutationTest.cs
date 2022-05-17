using ApiComGraphQL.Mutations;
using ApiComGraphQL.Queries;
using ApiComGraphQL.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedClasses.Context;
using SharedClasses.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GraphQLTests
{
    public class MutationTest
    {
        [Fact]
        public async Task AddUsuario_PerformMutation_ExistingEmail_ShouldBeWithError()
        {
            // Arrange
            var query = @"mutation addUser{
                            addUser (input: {id: 0, name : ""Carlos"", surname : ""Santos"", email : ""carlosteste@outlook.com"", 
                                                dDD: 11, phone : 12317491, password : ""1231qadASDAsd"", role : DIACONO}) {  
                            user {
                                id,
                                name
                            },
                            error
                            }
                        }";

            IReadOnlyQueryRequest request = QueryRequestBuilder.New()
                .SetQuery(query)
                .Create();

            var connectionString = "data source=localhost\\sqlexpress;initial catalog=IasdMaringa;persist security info=True;user id=Default;password=1234;MultipleActiveResultSets=True";

            var graphQlServer = new ServiceCollection()
                .AddDbContext<DefaultDbContext>(option => option.UseSqlServer(connectionString))
                .AddSingleton<IUserRepository, UserRepository>()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections().AddFiltering().AddSorting()
                .AddMutationType<Mutation>();

            // Act
            var response = await graphQlServer.ExecuteRequestAsync(request);

            var jsonObject = JsonConvert.DeserializeObject(response.ToJson()) as JObject;
            var userObj = JObject.Parse(response.ToJson());
            var addUser = Convert.ToString(userObj["data"]["addUser"]);
            var usuarioPayload = JsonConvert.DeserializeObject<UserPayload>(addUser.ToString());


            // Assert
            Assert.Null(response.Errors);
            Assert.NotNull(usuarioPayload);
            Assert.Equal("Existing email in our database", usuarioPayload.Error);

        }
    }
}