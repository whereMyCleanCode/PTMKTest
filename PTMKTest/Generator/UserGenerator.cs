using System;
using Faker;

using PTMKTest.Models;

namespace PTMKTest.Generator
{
    public class UserGenerator : IUserGenerator
    {
        public DateTime GenerateUserBirthday()
        {
           return Faker.DateTimeFaker.DateTime();
        }


        public string GenerateUserGender(bool onlyMale)
        {
            if(onlyMale)
            {
                if (Faker.Boolean.Random())
                    return "Femail";
                else
                    return "Mail";
            }
            return "Male";
           
        }

        public string GenerateUserFirstName()
        {
            return Faker.Name.First() ?? "Unknow";
        }


        public string GenerateUserSecondName()
        {
            return Faker.Name.Last() ?? "Unknow";            
        }

        public string GenerateUserFatherName()
        {
            return Faker.Name.Last() ?? "Unknow";
        }

        public UserModel GenerateFullUserData(bool onlyMale)
        {
          if(onlyMale)
             return new UserModel
             {
               FatherName = "F" + GenerateUserFirstName(),
               SecondName = GenerateUserSecondName(),
               FirstName = GenerateUserFatherName(),
               Birthday = GenerateUserBirthday(),
               Gender = GenerateUserGender(onlyMale)
             };

          else
             return new UserModel
             {
               FatherName = GenerateUserFirstName(),
               SecondName = GenerateUserSecondName(),
               FirstName = GenerateUserFatherName(),
               Birthday = GenerateUserBirthday(),
               Gender = GenerateUserGender(onlyMale)
             };

        }
    }
}

