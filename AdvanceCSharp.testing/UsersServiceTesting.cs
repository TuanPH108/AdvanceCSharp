using AdvanceCSharp.service;
using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.dto.Users.Response;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class UsersServiceTesting
    {
        private UsersService _UserService;

        public UsersServiceTesting() 
        {
            _UserService = new UsersService();
        }
        /// <summary>
        /// Test Get User
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetUserByIdTesting()
        {
            GetUserRequest request = new GetUserRequest()
            { 
                User_ID = Guid.Parse("A8F53B2E-CD36-4D09-1551-08DBF88F51D9"),
            };

            GetUserResponse response = await _UserService.GetById(request);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetListUserTesting()
        {
            GetListUserRequest request = new GetListUserRequest()
            { 
                User_Email = "ph.hoangtuan18@gmail.com"
            };
            GetListUserResponse response = await _UserService.GetList(request);
            Assert.IsTrue(response.ListUser.Count == 237);
        }

        [TestMethod]
        public async Task CreateUserTesting()
        {
            NewUserRequest request = new NewUserRequest()
            {
                User_ID = Guid.Parse("821464b5-2bee-4110-a8b3-8231835a7ff4"),
                User_Name = "Test Name",
                User_Contact = "Test Contact",
                User_Email = "Test Email"
            };
            NewUserResponse response = await _UserService.CreateUser(request);
            Assert.IsNotNull(response);
        }

       /* [TestMethod]
        public async Task UpdateUserTesting()
        {
            UpdateUserRequest request = new UpdateUserRequest()
            {
                User_ID = Guid.NewGuid(),
                User_Name = "",
                User_Contact = "",
                User_Email = ""
            };
            UpdateUserResponse response = await _UserService.UpdateUser(request);

            Assert.IsNotNull(response);
        }*/
    }
}