using Microsoft.AspNetCore.Mvc;
using UMS.Domain.Handler;
using UMS.Messages;
using UMS.Messages.Requests;

namespace UMS.Web.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LoginUserHandler _loginUserHandler;
        private readonly GetUsersHandler _getUsersHandler;
        private readonly GetUserByIdHandler _getUserByIdHandler;
        private readonly CreateUserHandler _createUserHandler;
        private readonly UpdateUserByIdHandler _updateUserHandler;
        private readonly DeleteUserByIdHandler _deleteUserByIdHandler;

        public UserController(LoginUserHandler loginUserHandler,
            GetUsersHandler getUsersHandler,
            GetUserByIdHandler getUserByIdHandler,
            CreateUserHandler createUserHandler,
            UpdateUserByIdHandler updateUserHandler,
            DeleteUserByIdHandler deleteUserByIdHandler)
        {
            _loginUserHandler = loginUserHandler;
            _getUsersHandler = getUsersHandler;
            _getUserByIdHandler = getUserByIdHandler;
            _createUserHandler = createUserHandler;
            _updateUserHandler = updateUserHandler;
            _deleteUserByIdHandler = deleteUserByIdHandler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserRequest request)
        {
            var result = await _loginUserHandler.HandleAsync(request);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(ExceptionMessages.INVALID_CREDENTIALS);
            }
        }

        [HttpGet("userList")]
        public async Task<IActionResult> GetUsers([FromBody] GetUsersRequest request)
        {
            return Ok(await _getUsersHandler.HandleAsync(request));
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] GetUserByIdRequest request)
        {
            var result = await _getUserByIdHandler.HandleAsync(request);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(ExceptionMessages.INVALID_USERID);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var userId = await _createUserHandler.HandleAsync(request);
            return StatusCode(201, $"UserId: {userId} created successfully.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserById([FromBody] UpdateUserByIdRequest request)
        {
            var userId = await _updateUserHandler.HandleAsync(request);
            if (userId != null)
            {
                return Ok($"UserId: {userId} updated successfully.");
            }
            else
            {
                return StatusCode(404, ExceptionMessages.INVALID_USERID);
            }
        }

        [HttpDelete("delete/{userId:int}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] DeleteUserByIdRequest request)
        {
            var userId = await _deleteUserByIdHandler.HandleAsync(request);
            if (userId != null)
            {
                return StatusCode(204, $"UserId: {request.UserId} deleted successfully.");
            }
            else
            {
                return StatusCode(404, ExceptionMessages.INVALID_USERID);
            }
        }
    }
}
