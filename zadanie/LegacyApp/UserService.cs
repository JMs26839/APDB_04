using System;

namespace LegacyApp
{
    public class UserService

    {
        private ICreditProcessor _creditProcessor;
        private IAgeValidation _ageValidation;

        public UserService(ICreditProcessor creditProcessor,IAgeValidation ageValidation)
        {
            _creditProcessor = creditProcessor;
            _ageValidation = ageValidation;
        }


        public UserService()
        {
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var name =FirstNameLastNameNullOrEmpty(firstName, lastName);
            if (!name)
            {
                return false;}


            var mail = Mail(email);
            
            if (!mail)
            {
                return false;}


            // var now = DateTime.Now;
            // int age = now.Year - dateOfBirth.Year;
            // if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            //
            // if (age < 21)
            // {
            //     return false;
            // }

            

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);
            if ( client==null)
            {
                return false;
            }

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            var age = _ageValidation.ageCalculations(user.DateOfBirth);
            if (!age)
            {
                return false;
            }

            // if (client.Type == "VeryImportantClient")
            // {
            //     user.HasCreditLimit = false;
            // }
            // else if (client.Type == "ImportantClient")
            // {
            //     using (var userCreditService = new UserCreditService())
            //     {
            //         int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            //         creditLimit = creditLimit * 2;
            //         user.CreditLimit = creditLimit;
            //     }
            // }
            // else
            // {
            //     user.HasCreditLimit = true;
            //     using (var userCreditService = new UserCreditService())
            //     {
            //         int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            //         user.CreditLimit = creditLimit;
            //     }
            // }

            if (!_creditProcessor.ProcessCredit(user,client))
                return false;
            

            UserDataAccess.AddUser(user);
            return true;
        }

        

        public class ImportanceOfClient:ICreditProcessor
        {
            public string Type { get; }
            public bool ProcessCredit(User user, Client client)
            {
                if (client.Type == "VeryImportantClient")
                {
                    user.HasCreditLimit = false;
                }
                else if (client.Type == "ImportantClient")
                {
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        creditLimit = creditLimit * 2;
                        user.CreditLimit = creditLimit;
                    }
                }
                else
                {
                    user.HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        user.CreditLimit = creditLimit;
                    }
                }

                var limit500 = WhetherLimitIsLowerThan500(user);

                return false;
            }
            
            private static bool WhetherLimitIsLowerThan500(User user)
            {
                if (user.HasCreditLimit && user.CreditLimit < 500)
                {
                    return false;
                }

                return true;
            }

            
        }

        private static bool FirstNameLastNameNullOrEmpty(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            return true;
        }

        private static bool Mail(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            return true;
        }
    }
}
