using System;
using PTMKTest.Models;

namespace PTMKTest.DAL
{
	public interface IIdentityDb
	{
        public Task<int> CreateUser(UserModel model);
        public Task<UserModel> GetUser(int id);
        public Task<UserModel> GetUser(string secondname);
        public Task<List<UserModel>> GetUniqUsers();
        public Task<List<UserModel>> GetUniqUsers(string param);

    }
}

