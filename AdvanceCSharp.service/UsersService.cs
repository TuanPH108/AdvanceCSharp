using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.dto.Users.Response;
using AdvanceCSharp.database;
using AdvanceCSharp.database.Model;
using AdvanceCSharp.service.Interface;

namespace AdvanceCSharp.service
{
    public class UsersService : IUsersService
    {
        public Task<GetUserResponse> Get (GetUserRequest request)
        {
            GetUserResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Users? getUser = dbContext.Users.Where(user => user.UserID == request.UserID).FirstOrDefault();
                response.UserID = getUser.UserID;
                response.UserName = getUser.UserName;
                response.UserEmail = getUser.UserEmail;
                response.UserContact = getUser.UserContact;
            }
            return Task.FromResult(response);
        }

        public Task<GetListUserResponse> GetList(GetListUserRequest request)
        {
            GetListUserResponse response = new();
            using (AppDbContext dbContext = new())
            {
                List<Users> listUser = [.. dbContext.Users.Where(user => user.UserEmail == request.UserEmail)];
                foreach (Users user in listUser)
                {
                    response.ListUser.Add(item: new GetUserResponse()
                    {
                        UserID = user.UserID,
                        UserName = user.UserName,
                        UserContact = user.UserContact,
                        UserEmail = user.UserEmail
                    });
                }
            }
            return Task.FromResult(response);
        }

        public Task<NewUserResponse> Create (NewUserRequest request)
        {
            NewUserResponse response = new();
            using (AppDbContext dbContext = new())
            {
                _ = dbContext.Users.Add(new Users()
                {
                    UserID = request.UserID,
                    UserName = request.UserName,
                    UserContact = request.UserContact,
                    UserEmail = request.UserEmail
                });
                _ = dbContext.SaveChanges();

                Users? getUser = dbContext.Users.Where(user => user.UserID == request.UserID).FirstOrDefault();
                response.UserID = getUser.UserID;
                response.UserName = getUser.UserName;
                response.UserEmail = getUser.UserEmail;
                response.UserContact = getUser.UserContact;
            }
            return Task.FromResult(response);
        }

        public Task<UpdateUserResponse> Update (UpdateUserRequest request)
        {
            UpdateUserResponse response = new();
            Users tmpUser = new()
            {
                UserID = request.UserID,
                UserName = request.UserName,
                UserContact = request.UserContact,
                UserEmail = request.UserEmail
            };
            using (AppDbContext dbContext = new())
            {
                _ = dbContext.Users.Update(tmpUser);
                _ = dbContext.SaveChanges();

                Users? getUser = dbContext.Users.Where(user => user.UserID == request.UserID).FirstOrDefault();
                response.UserID = getUser.UserID;
                response.UserName = getUser.UserName;
                response.UserEmail = getUser.UserEmail;
                response.UserContact = getUser.UserContact;
            }
            return Task.FromResult(response);
        }

        public Task<DeleteUserResponse> Delete (DeleteUserRequest request)
        {
            DeleteUserResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Users? findUser = dbContext.Users.Find(request.UserID);
                _ = dbContext.Users.Remove(findUser);
                _ = dbContext.SaveChanges();
            }
            response.UserID = Guid.Empty;
            response.UserName = "";
            response.UserEmail = "";
            response.UserContact = "";
            return Task.FromResult(response);
        }
    }
}

