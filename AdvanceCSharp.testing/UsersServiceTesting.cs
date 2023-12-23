using AdvanceCSharp.service;
using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.dto.Users.Response;

namespace AdvanceCSharp.testing
{
    [TestClass]
    public class UsersServiceTesting
    {
        private readonly UsersService _userService;

        public UsersServiceTesting() 
        {
            _userService = new UsersService();
        }
        /// <summary>
        /// Test Get User
        /// </summary>
        [TestMethod]
        public async Task GetUserByIdTesting()
        {
            GetUserRequest request = new()
            { 
                UserID = Guid.Parse("D76B6A97-4B54-4C5E-1550-08DBF88F51D9"),
            };

            GetUserResponse response = await _userService.Get(request);
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
                UserEmail = "ph.hoangtuan18@gmail.com"
            };
            GetListUserRequest request = getListUserRequest;
            GetListUserResponse response = await _userService.GetList(request);
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
                UserID = Guid.NewGuid(),
                UserName = "Test Name",
                UserContact = "Test Contact",
                UserEmail = "Test Email"
            };
            NewUserResponse response = await _userService.Create(request);
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
                UserID = Guid.Parse("D76B6A97-4B54-4C5E-1550-08DBF88F51D9"),
                UserName = "",
                UserContact = "",
                UserEmail = ""
            };
            UpdateUserResponse response = await _userService.Update(request);
            //Check response is not null
            Assert.IsNotNull(response);
        }
    }
}