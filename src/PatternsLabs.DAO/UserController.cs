using Microsoft.AspNetCore.Mvc;

namespace PatternsLabs.DAO;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;
    public UserController(AppDbContext context)
    {
        _service = new UserService(context);
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<User>> Get(Guid id)
    {
        var user = await _service.GetUser(id);
        return Ok(user);
    }

    [HttpPost("")]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        await _service.SaveUser(user);
        return Created("", user);
    }
    
    [HttpPut("{id:guid}/block")]
    public async Task<IActionResult> Block(Guid id)
    {
        await _service.BlockedUser(id);
        return NoContent();
    }

    [HttpPut("{id:guid}/admin")]
    public async Task<IActionResult> Admin(Guid id)
    {
        await _service.BlockedUser(id);
        return NoContent();
    }


}