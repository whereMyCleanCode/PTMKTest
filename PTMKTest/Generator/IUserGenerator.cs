using System;
using PTMKTest.Models;

namespace PTMKTest.Generator
{
	public interface IUserGenerator
	{
		public string GenerateUserGender(bool onlyMale);

        public DateTime GenerateUserBirthday();

        public string GenerateUserFirstName();

        public string GenerateUserSecondName();

        public string GenerateUserFatherName();

        public UserModel GenerateFullUserData(bool onlyMale);
    }
}

