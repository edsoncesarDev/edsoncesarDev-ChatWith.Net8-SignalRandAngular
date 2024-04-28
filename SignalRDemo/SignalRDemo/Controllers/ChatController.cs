using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SignalRDemo.DTOs;
using SignalRDemo.Services;

namespace SignalRDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly ChatService _chatService;

    public ChatController(ChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost]
    [Route("register-user")]
    public IActionResult RegisterUser(UserDto model)
    {
        if (_chatService.AddUserToList(model.Name))
            return NoContent();

        return BadRequest("This name is taken, please choose another name.");
    }
}