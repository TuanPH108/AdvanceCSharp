using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.dto.Users.Response;
using AdvanceCSharp.database;
using AdvanceCSharp.database.Model;

namespace AdvanceCSharp.service
{
    public class UsersService
    {
        public Task<GetUserResponse> GetById(GetUserRequest request)
        {
            GetUserResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Users? GetUser = dbContext.Users.Where(user => user.User_ID == request.User_ID).FirstOrDefault();
                response.User_ID = GetUser.User_ID;
                response.User_Name = GetUser.User_Name;
                response.User_Email = GetUser.User_Email;
                response.User_Contact = GetUser.User_Contact;
            }
            return Task.FromResult(response);
        }

        public Task<GetListUserResponse> GetList(GetListUserRequest request)
        {
            GetListUserResponse response = new();
            using (AppDbContext dbContext = new())
            {
                List<Users> ListUser = [.. dbContext.Users.Where(user => user.User_Email == request.User_Email)];
                foreach (Users user in ListUser)
                {
                    response.ListUser.Add(item: new GetUserResponse()
                    {
                        User_ID = user.User_ID,
                        User_Name = user.User_Name,
                        User_Contact = user.User_Contact,
                        User_Email = user.User_Email
                    });
                }
            }
            return Task.FromResult(response);
        }

        public Task<NewUserResponse> CreateUser(NewUserRequest request)
        {
            NewUserResponse response = new();
            using (AppDbContext dbContext = new())
            {
                _ = dbContext.Users.Add(new Users()
                {
                    User_ID = request.User_ID,
                    User_Name = request.User_Name,
                    User_Contact = request.User_Contact,
                    User_Email = request.User_Email
                });
                _ = dbContext.SaveChanges();

                Users? GetUser = dbContext.Users.Where(user => user.User_ID == request.User_ID).FirstOrDefault();
                response.User_ID = GetUser.User_ID;
                response.User_Name = GetUser.User_Name;
                response.User_Email = GetUser.User_Email;
                response.User_Contact = GetUser.User_Contact;
            }
            return Task.FromResult(response);
        }

        public Task<UpdateUserResponse> UpdateUser (UpdateUserRequest request)
        {
            UpdateUserResponse response = new();
            Users tmpUser = new()
            {
                User_ID = request.User_ID,
                User_Name = request.User_Name,
                User_Contact = request.User_Contact,
                User_Email = request.User_Email
            };
            using (AppDbContext dbContext = new())
            {
                _ = dbContext.Users.Update(tmpUser);
                _ = dbContext.SaveChanges();

                Users? GetUser = dbContext.Users.Where(user => user.User_ID == request.User_ID).FirstOrDefault();
                response.User_ID = GetUser.User_ID;
                response.User_Name = GetUser.User_Name;
                response.User_Email = GetUser.User_Email;
                response.User_Contact = GetUser.User_Contact;
            }
            return Task.FromResult(response);
        }

        public Task<DeleteUserResponse> DeleteUser (DeleteUserRequest request)
        {
            DeleteUserResponse response = new();
            using (AppDbContext dbContext = new())
            {
                Users? FindedUser = dbContext.Users.Find(request.User_ID);
                _ = dbContext.Users.Remove(FindedUser);
                _ = dbContext.SaveChanges();

                Users ?GetUser = dbContext.Users.Where(user => user.User_ID == request.User_ID).FirstOrDefault();
                response.User_ID = Guid.Empty;
                response.User_Name = "";
                response.User_Email = "";
                response.User_Contact = "";
            }
            return Task.FromResult(response);
        }
    }
}

