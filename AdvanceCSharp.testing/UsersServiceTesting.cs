using AdvanceCSharp.service;
using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.dto.Users.Response;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class UsersServiceTesting
    {
        private readonly UsersService _UserService;

        public UsersServiceTesting() 
        {
            _UserService = new UsersService();
        }
        /// <summary>
        /// Test Get User
        /// </summary>
        [TestMethod]
        public async Task GetUserByIdTesting()
        {
            GetUserRequest request = new()
            { 
                User_ID = Guid.Parse("D76B6A97-4B54-4C5E-1550-08DBF88F51D9"),
            };

            GetUserResponse response = await _UserService.GetById(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// Test Get List user
        /// </summary>
        [TestMethod]
        public async Task GetListUserTesting()
        {
            GetListUserRequest getListUserRequest = new()
            {
                User_Email = "ph.hoangtuan18@gmail.com"
            };
            GetListUserRequest request = getListUserRequest;
            GetListUserResponse response = await _UserService.GetList(request);
            //Check List Response equal count of List User
            Assert.IsTrue(response.ListUser.Count == 237);
        }
        /// <summary>
        /// Test Create User
        /// </summary>
        [TestMethod]
        public async Task CreateUserTesting()
        {
            NewUserRequest request = new()
            {
                User_ID = Guid.NewGuid(),
                User_Name = "Test Name",
                User_Contact = "Test Contact",
                User_Email = "Test Email"
            };
            NewUserResponse response = await _UserService.CreateUser(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// Test Update User
        /// </summary>
       [TestMethod]
        public async Task UpdateUserTesting()
        {
            UpdateUserRequest request = new()
            {
                User_ID = Guid.Parse("D76B6A97-4B54-4C5E-1550-08DBF88F51D9"),
                User_Name = "",
                User_Contact = "",
                User_Email = ""
            };
            UpdateUserResponse response = await _UserService.UpdateUser(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
        /// <summary>
        /// Test Delete user
        /// </summary>
        [TestMethod]
        public async Task DeleteUserTesting()
        {
            DeleteUserRequest request = new()
            {
                User_ID = Guid.Parse("5B856F6A-D5CF-432D-1553-08DBF88F51D9")
            };
            DeleteUserResponse response = await _UserService.DeleteUser(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
    }
}