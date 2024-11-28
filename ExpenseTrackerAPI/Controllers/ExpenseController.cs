using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerAPI.Models;
using Microsoft.Data.SqlClient;
using ExpenseTrackerAPI.Helpers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DatabaseHelper _dbHelper;

    public UsersController(DatabaseHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        string query = "INSERT INTO Users (UserName, Email, Password) VALUES (@UserName, @Email, @Password)";
        var parameters = new[]
        {
            new SqlParameter("@UserName", user.UserName),
            new SqlParameter("@Email", user.Email),
            new SqlParameter("@Password", user.Password)
        };
        _dbHelper.ExecuteNonQuery(query, parameters);
        return Ok(new { Message = "User registered successfully" });
    }
}
