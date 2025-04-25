using MediatR;
using SolvexTechnicalTest.Core.Application.DTOs.Users;
using SolvexTechnicalTest.Core.Application.Interfaces.Identity;
using SolvexTechnicalTest.Core.Application.Wrappers;

namespace SolvexTechnicalTest.Core.Application.Features.User.Queries.GetUsersById
{
    public class GetUserById : IRequest<Response<UserDto>>
    {
        public string Id { get; set; }
    }
    public class GetUserByIdHandler : IRequestHandler<GetUserById, Response<UserDto>>
    {
        private readonly IUserService _userService;
        public GetUserByIdHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Response<UserDto>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(request.Id);
            return new Response<UserDto>(user);
        }
    }
}
