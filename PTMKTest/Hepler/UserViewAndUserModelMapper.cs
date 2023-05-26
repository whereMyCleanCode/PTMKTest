using System;
using PTMKTest.Models;
using PTMKTest.ViewModel;

namespace PTMKTest.Hepler
{
	public static class UserViewAndUserModelMapper
	{
		public static UserModel ReturnUserModelMapper(UserConsoleViewModel model)
		{
			return new UserModel
			{
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				FatherName = model.FatherName,
				Gender = model.Gender,
				Birthday = model.Birthday
			};
		}

		public static UserConsoleViewModel ReurnUserConsoleViewModel(UserModel model)
		{
            return new UserConsoleViewModel
            {
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                FatherName = model.FatherName,
                Gender = model.Gender,
                Birthday = model.Birthday
            };
        }
	}
}

