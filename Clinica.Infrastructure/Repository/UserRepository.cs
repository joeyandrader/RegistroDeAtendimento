using Clinica.Domain.Entities;
using Clinica.Domain.Interfaces;
using Clinica.Infrastructure.Data;
using Dapper;

namespace Clinica.Infrastructure.Repository
{
    public class UserRepository(DapperContext _context) : IUserRepository
    {
        public async Task<int> CreateAsync(User request)
        {
            string query = @"INSERT INTO 
                    Users(
                            Name,
                            DateOfBirth,
                            Cpf,
                            Sex,
                            Status)
                    VALUES (
                            @Name,
                            @DateOfBirth,
                            @Cpf,
                            @Sex,
                            @Status)
                    RETURNING Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query, request);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string query = @"DELETE * FROM Users Where Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, new { Id = id }) > 0;
        }

        public async Task<IEnumerable<User?>> GetAllAsync()
        {
            string query = @"SELECT * FROM Users";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<User>(query);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            string query = @"SELECT u.*,
                            ud.Id AS AddressId,
                            ud.AddressLine1,
                            ud.AddressLine2,
                            ud.Neighborhood,
                            ud.City,
                            ud.Country,
                            ud.State,
                            ud.ZipCode,
                            ud.UserId
                            FROM Users u
                            INNER JOIN useraddresses ud on u.Id = ud.UserId
                            Where u.Id = @Id";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<User, UserAddress, User>(query, (user, address) =>
            {
                user.Address = address;
                return user;
            },
            new { Id = id },
            splitOn: "AddressId"
            );

            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(User request)
        {
            string query = @"UPDATE Users
                           SET 
                                Name = @Name,
                                DateOfBirth = @DateOfBirth,
                                Cpf = @Cpf,
                                Sex = @Sex,
                                WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, request) > 0;
        }
    }
}
