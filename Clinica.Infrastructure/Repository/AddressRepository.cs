using Clinica.Domain.Entities;
using Clinica.Domain.Interfaces;
using Clinica.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Infrastructure.Repository
{
    public class AddressRepository(DapperContext _context) : IAddressRepository
    {
        public async Task CreateAsync(UserAddress request)
        {
            string query = @"INSERT INTO useraddresses 
                            (AddressLine1,
                            AddressLine2,
                            Neighborhood,
                            City,
                            Country,
                            State,
                            ZipCode,
                            UserId) 
                            VALUES(
                            @AddressLine1,
                            @AddressLine2,
                            @Neighborhood,
                            @City,
                            @Country,
                            @State,
                            @ZipCode,
                            @UserId)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, request);
        }

        public async Task<UserAddress?> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM useraddresses WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync(query, new { Id = id });
        }

        public async Task<bool> UpdateAsync(UserAddress request)
        {
            string query = @"UPDATE useraddresses
                            SET
                            AddressLine1 = @AddressLine1,
                            AddressLine2 = @AddressLine2,
                            Neighborhood = @Neighborhood,
                            City = @City,
                            State = @State,
                            ZipCode = @ZipCode
                        WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, request) > 0;

        }
    }
}
