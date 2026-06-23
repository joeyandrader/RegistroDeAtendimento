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
            string query = @"
                        SELECT 
                            a.Id,
                            a.AppointmentDate,
                            a.Description,
                            a.Status,
                            a.UserId,
                            a.CreatedAt,
                            a.UpdatedAt,

                            b.Id as UserIdSplit,
                            b.Name,
                            b.DateOfBirth,
                            b.Cpf,
                            b.Sex,
                            b.Status,
                            b.CreatedAt as UserCreatedAt,
                            b.UpdatedAt as UserUpdatedAt
                        FROM appointments a
                        INNER JOIN users b ON a.userId = b.Id
                        ";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserAppointment, User, UserAppointment>(query, (appointment, user) =>
            {
                appointment.User = user;
                return appointment;
            }, splitOn: "UserIdSplit");
        }

        public async Task<UserAppointment?> GetByIdAsync(int id)
        {
            string query = @"
                        SELECT 
                            a.Id,
                            a.AppointmentDate,
                            a.Description,
                            a.Status,
                            a.UserId,
                            a.CreatedAt,
                            a.UpdatedAt,

                            b.Id as UserIdSplit,
                            b.Name,
                            b.DateOfBirth,
                            b.Cpf,
                            b.Sex,
                            b.Status,
                            b.CreatedAt as UserCreatedAt,
                            b.UpdatedAt as UserUpdatedAt
                        FROM appointments a
                        INNER JOIN users b ON a.userId = b.Id
                        ";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<UserAppointment, User, UserAppointment>(query, (appointment, user) =>
            {
                appointment.User = user;
                return appointment;
            }, new { Id = id }, splitOn: "UserIdSplit");
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(UserAppointment request)
        {
            request.UpdatedAt = DateTime.Now;
            string query = @"UPDATE appointments
                            SET
                                AppointmentDate = @AppointmentDate,
                                Description = @Description,
                                Status = @Status,
                                UserId = @UserId,
                                UpdatedAt = @UpdatedAt
                            WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(query, request) > 0;
        }
    }
}
