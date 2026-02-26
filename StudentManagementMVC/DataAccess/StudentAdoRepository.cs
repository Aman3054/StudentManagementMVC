using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace StudentManagementMVC.DataAccess;

public class StudentAdoRepository
{
    private readonly string _connectionString;

    public StudentAdoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    public int GetStudentCount()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT COUNT(*) FROM Students", connection);
        return (int)(command.ExecuteScalar() ?? 0);
    }

    public int GetActiveStudentsCount()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT COUNT(*) FROM Students WHERE IsActive = 1", connection);
        return (int)(command.ExecuteScalar() ?? 0);
    }
}
