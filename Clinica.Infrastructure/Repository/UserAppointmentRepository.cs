using Clinica.Domain.Entities;
using Clinica.Domain.Interfaces;
using Clinica.Infrastructure.Data;
using Dapper;

namespace Clinica.Infrastructure.Repository
{
    public class UserAppointmentRepository
        (
        DapperContext _context
        ) : IUserAppointmentRepository
    {
        public async Task<int> CreateAsync(UserAppointment request)
        {
            string query = @"INSERT INTO appointments
                            (AppointmentDate,
                                Description,
                            Status,
                            UserId)
                        VALUES (
                        @AppointmentDate,
                        @Description,
                        @Status,
                        @UserId)
                    RETURNING Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query, request);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            string query = @"DELETE FROM appointments WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, new { Id = id }) > 0;
        }

        public async Task<IEnumerable<UserAppointment?>> GetAllAsync()
        {
            string query = @"SELECT * FROM appointments";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserAppointment>(query);
        }

        public async Task<UserAppointment?> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM appointments WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UserAppointment?>(query, new { Id = id });
        }

        public async Task<bool> UpdateAsync(UserAppointment request)
        {
            string query = @"UPDATE appointments
                            SET
                                AppointmentDate = @AppointmentDate,
                                Description = @Description,
                                Status = @Status,
                                UserId = @UserId
                            WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, request) > 0;
        }
    }
}
