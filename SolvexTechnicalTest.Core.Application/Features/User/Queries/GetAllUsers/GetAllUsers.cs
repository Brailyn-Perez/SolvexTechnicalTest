using MediatR;
using SolvexTechnicalTest.Core.Application.DTOs.Users;
using SolvexTechnicalTest.Core.Application.Interfaces.Identity;
using SolvexTechnicalTest.Core.Application.Wrappers;

namespace SolvexTechnicalTest.Core.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsers : IRequest<Response<List<UserDto>>>
    {
    }

    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, Response<List<UserDto>>>
    {
        private readonly IUserService _userService;
        public GetAllUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Response<List<UserDto>>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync();
            return new Response<List<UserDto>>(users);
        }
    }
}