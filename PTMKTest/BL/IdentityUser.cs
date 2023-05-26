using System;
using PTMKTest.DAL;
using PTMKTest.Generator;
using PTMKTest.Models;

namespace PTMKTest.BL
{
	public class IdentityUser : IIdentityUser
	{
        private IIdentityDb _identityDb = new IdentityDb();
        private IUserGenerator _userGenerator = new UserGenerator();

        public async Task<int> AddUser(UserModel model)
        {
            if(model != null)
            {
                var user = await SearchUniqUser(model.FatherName) ?? new List<UserModel>();
                  if(user == null)
                  {
                     int result =  await _identityDb.CreateUser(model);
                         return result;
                  }  
            }
            return 0;
        }

        public async Task<List<UserModel>> SearchUniqUser()///maybee read methood with add hock polimorphizm using serapate UserModel property
        {
            return await _identityDb.GetUniqUsers();
        }

        public async Task<List<UserModel>>SearchUniqUser(string fathername)
        {
            return await _identityDb.GetUniqUsers(fathername);
        }


        public async Task<List<int>> GenerateUserDb()
        {
          List<int> usersid = new List<int>();
          for (int i = 0; i < 10000; i++)
          {
            usersid.Add(await _identityDb
                   .CreateUser(_userGenerator
                   .GenerateFullUserData(false)));
                    if (i > 10000)
                    {
                       for (int j = 0; j < 100; j++)
                       {
                        usersid.Add(await _identityDb
                               .CreateUser(_userGenerator
                               .GenerateFullUserData(true)));
                       }
                    }
          }
           return usersid;
        }
    }
}

