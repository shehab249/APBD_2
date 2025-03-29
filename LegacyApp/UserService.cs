using System;


namespace LegacyApp
{
    public class UserService
    {
        private readonly ClientRepository clientRepository;
        private readonly UserCreditService userCreditService;
        public UserService()
        {
            clientRepository = new ClientRepository();
            userCreditService = new UserCreditService();
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!firstName.IsValidName(lastName)) return false;
            if (!email.IsValidEmail()) return false;
            if (!dateOfBirth.IsAdult(DateTime.Now)) return false;
            
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient") user.HasCreditLimit = false;
            
            else
            {
                user.HasCreditLimit = true;
                using (userCreditService)
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    if (client.Type == "ImportantClient")
                    {
                        creditLimit *= 2;
                    }
                    user.CreditLimit = creditLimit;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500) return false;
            
            UserDataAccess.AddUser(user);
            return true;
        }
        
    }
}
