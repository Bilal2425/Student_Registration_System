using Student_Registration_System.Models;
using Student_Registration_System.Repository;
using Microsoft.Extensions.Configuration;

namespace Student_Registration_System.Business
{
    public class UserManager
    {
        private readonly UserRepository _userRepository;

        public UserManager(IConfiguration configuration)
        {
            _userRepository = new UserRepository(configuration);
        }

        public User GetUser(string userName, string password)
        {
            return _userRepository.GetUser(userName, password);
        }
    }
}
