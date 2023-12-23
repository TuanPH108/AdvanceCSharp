using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.dto.Users.Response;
namespace AdvanceCSharp.service.Interface
{
    public interface IUsersService
    {
        public Task <GetUserResponse> Get (GetUserRequest request);
        public Task <GetListUserResponse> GetList (GetListUserRequest request);
        public Task <UpdateUserResponse> Update(UpdateUserRequest request);
        public Task <DeleteUserResponse> Delete(DeleteUserRequest request);
        public Task <NewUserResponse> Create(NewUserRequest request);
    }
}
