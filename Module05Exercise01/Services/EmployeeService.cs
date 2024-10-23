using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module05Exercise01.Model;


namespace Module05Exercise01.Services
{
    public class EmployeeService
    {
        public readonly string _connectionString;

        public EmployeeService()
        {
            var dbService = new DatabaseConnectionService();
            _connectionString = dbService.GetConnectionString();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var employeeService = new List<Employee>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("SELECT * FROM tblemployee", conn);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        employeeService.Add(new Employee
                        {
                            //ID = reader.GetInt32("ID"),
                            //NAME = reader.GetString("NAME"),
                            //Gender = reader.GetString("Gender"),
                            //ContactNo = reader.GetString("ContactNo")
                            EmployeeID = reader.GetInt32("EmployeeID"),
                            Name = reader.GetString("Name"),
                            Address = reader.GetString("Address"),
                            Email = reader.GetString("Email"),
                            ContactNo = reader.GetString("ContactNo"),

                        });
                    }
                }
            }
            return employeeService;

        }
    }
}
