using Microsoft.AspNetCore.Mvc;
using ModShop.IServices;

namespace ModShop.Controller;

[ApiController]
public class UserController(IUserService userServices) : ControllerBase
{
    [HttpPost("users/Create")]
    public IActionResult Create(string userName, string phoneNumber, string password)
    {
        var userId = userServices.Create(userName, phoneNumber, password);
        return Ok(userId);
    }
    [HttpPost("users/complete-registration")]
    public IActionResult CompleteRegistration(Guid id, string firstName, string lastName, string email)
    {
        userServices.CompleteRegistration(id, firstName, lastName, email);
        return Ok();
    }
    [HttpPut("users/Update")]
    public IActionResult Update(Guid id, string userName, string firstName, string lastName, string email, string phoneNumber, string password)
    {
        userServices.Update(id, userName, firstName, lastName, email, phoneNumber, password);
        return Ok();
    }
    [HttpGet("users/Get")]
    public IActionResult Get(Guid id)
    {
        var user = userServices.Get(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpGet("users/GetAll")]
    public IActionResult GetAll()
    {
        var users = userServices.GetAll();
        return Ok(users);
    }
    [HttpDelete("users/Delete")]
    public IActionResult Delete(Guid id)
    {
        userServices.Delete(id);
        return Ok();
    }
}
