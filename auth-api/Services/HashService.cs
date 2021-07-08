using System;
using auth_api.Constants;

namespace auth_api.services
{
    public class HashApi 
    {

       public string generatePassword (string PlainPassword)
       {
           var hash = BCrypt.Net.BCrypt.HashPassword(PlainPassword, Constants.Constants.SaltRounds);
           var tes = BCrypt.Net.BCrypt.EnhancedHashPassword(PlainPassword, Constants.Constants.SaltRounds);
           return tes;
       }

       public bool checkPass (string pw, string hash) {
           return BCrypt.Net.BCrypt.Verify(pw, hash);
       }
    }
}