using Student_Registration_System.Repository;

namespace Student_Registration_System.Business
{
    public class RegistrationManager
    {
        private readonly RegistrationRepository _registrationRepository;

        public RegistrationManager(RegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public void RegisterStudent(string userName, string password)
        {
            _registrationRepository.RegisterStudent(userName, password);
        }
    }
}
