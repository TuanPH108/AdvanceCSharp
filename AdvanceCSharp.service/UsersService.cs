using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.dto.Users.Response;
using AdvanceCSharp.database;
using AdvanceCSharp.database.Model;

namespace AdvanceCSharp.service
{
    public class UsersService
    {

        public async Task<GetUserResponse> GetById(GetUserRequest request)
        {
            GetUserResponse response = new GetUserResponse();
            using (AppDbContext dbContext = new AppDbContext())
            {
                Users GetUser = dbContext.Users.Where(user => user.User_ID == request.User_ID).FirstOrDefault();
                response.User_ID = GetUser.User_ID;
                response.User_Name = GetUser.User_Name;
                response.User_Email = GetUser.User_Email;
                response.User_Contact = GetUser.User_Contact;
            }
            return response;
        }

        public async Task<GetListUserResponse> GetList(GetListUserRequest request)
        {
            GetListUserResponse response = new GetListUserResponse();

            using (AppDbContext dbContext = new AppDbContext())
            {
                List<Users> ListUser = dbContext.Users.Where(user => user.User_Email == request.User_Email).ToList();
                foreach (Users user in ListUser)
                {
                    response.ListUser.Add(new GetUserResponse() 
                    {
                        User_ID = user.User_ID,
                        User_Name = user.User_Name,
                        User_Contact = user.User_Contact,
                        User_Email = user.User_Email
                    });
                }
            }
            return response;
        }

        public async Task<NewUserResponse> CreateUser(NewUserRequest request)
        {
            NewUserResponse response = new NewUserResponse();
            using (AppDbContext dbContext = new AppDbContext())
            {
                _ = dbContext.Users.Add( new Users()
                {
                    User_ID = request.User_ID,
                    User_Name = request.User_Name,
                    User_Contact = request.User_Contact,
                    User_Email = request.User_Email
                });
                _ = dbContext.SaveChanges();

                Users GetUser = dbContext.Users.Where(user => user.User_ID == request.User_ID).FirstOrDefault();
                response.User_ID = GetUser.User_ID;
                response.User_Name = GetUser.User_Name;
                response.User_Email = GetUser.User_Email;
                response.User_Contact = GetUser.User_Contact;
            }
            return response;
        }

        public async Task<UpdateUserResponse> UpdateUser (UpdateUserRequest request)
        {
            UpdateUserResponse response = new UpdateUserResponse();
            Users tmpUser = new Users()
            {
                User_ID = request.User_ID,
                User_Name = request.User_Name,
                User_Contact = request.User_Contact,
                User_Email = request.User_Email
            };

            using (AppDbContext  dbContext = new AppDbContext())
            {
                _ = dbContext.Users.Update(tmpUser);
                _ = dbContext.SaveChanges();

                Users GetUser = dbContext.Users.Where(user => user.User_ID == request.User_ID).FirstOrDefault();
                response.User_ID = GetUser.User_ID;
                response.User_Name = GetUser.User_Name;
                response.User_Email = GetUser.User_Email;
                response.User_Contact = GetUser.User_Contact;
            }
            return response;
        }

        public async Task<DeleteUserResponse> DeleteUser (DeleteUserRequest request)
        {
            DeleteUserResponse response = new DeleteUserResponse();
            using (AppDbContext dbContext = new AppDbContext()) 
            {
                _ = dbContext.Users.Remove(dbContext.Users.Find(request.User_ID));
                dbContext.SaveChanges();

                Users GetUser = dbContext.Users.Where(user => user.User_ID == request.User_ID).FirstOrDefault();
                response.User_ID = GetUser.User_ID;
                response.User_Name = GetUser.User_Name;
                response.User_Email = GetUser.User_Email;
                response.User_Contact = GetUser.User_Contact;
            }
            return response;
        }
    }
}
