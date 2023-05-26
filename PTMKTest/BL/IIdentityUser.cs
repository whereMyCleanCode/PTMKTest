using System;
using PTMKTest.Models;

namespace PTMKTest.BL
{
	public interface IIdentityUser
	{
        public Task<int> AddUser(UserModel model);
        public Task<List<UserModel>> SearchUniqUser();
        public Task<List<UserModel>> SearchUniqUser(string fathername);
        public Task<List<int>> GenerateUserDb();
    }
}

