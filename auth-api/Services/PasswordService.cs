using System;
using auth_api.Constants;

namespace auth_api.services
{
    public class PasswordService 
    {

       public static string generatePasswordHash (string PlainPassword)
       {
           var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(PlainPassword, Constants.Constants.SaltRounds);
           return hash;
       }

       public static bool checkPass (string pw, string hash) {
           return BCrypt.Net.BCrypt.EnhancedVerify(pw, hash);
       }
    }
}