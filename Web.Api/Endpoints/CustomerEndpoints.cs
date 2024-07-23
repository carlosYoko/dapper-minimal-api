using Dapper;
using Microsoft.Data.SqlClient;
using Web.Api.Models;

namespace Web.Api.Endpoints
{
    public static class CustomerEndpoints
    {
        public static void MapCustomerEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("customers", async (IConfiguration configuration) =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection")!;

                using var connection = new SqlConnection(connectionString);

                const string sql = "SELECT Id, FirstName, LastName, Email, DateOfBirth FROM Customers";

                var customers = await connection.QueryAsync<Customer>(sql);

                return Results.Ok(customers);
            });

        }
    }
}
