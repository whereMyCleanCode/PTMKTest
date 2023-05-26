using System;
using System.Reflection;
using PTMKTest.BL;
using PTMKTest.Models;
using PTMKTest.ViewModel;

namespace PTMKTest.Controllers
{
    public class ConsoleController : Controller
    {
        public UserConsoleViewModel _userModel = new UserConsoleViewModel();
        public IIdentityUser _identityUser = new IdentityUser();

        public void EntyMethood()
        {
            Console.WriteLine("Выберите действие\n1.Создать пользователя\n2.Посмотреть пользователяn\n3.Сгенерировать пользователя");
            ChooseAnalzer(Convert.ToInt32(Console.ReadLine() ?? "0"));
        }

        public async void ChooseAnalzer(int choose)
        {
            switch (choose)
            {
                case 0:
                    Console.WriteLine("Not implement, Sorry");
                    break;
                    
                case 1:
                    Console.WriteLine("Введите имя пользователя");
                    _userModel.FirstName = Console.ReadLine() ?? "";
                    Console.WriteLine("Введите фамилию пользователя");
                    _userModel.SecondName = Console.ReadLine() ?? "";
                    Console.WriteLine("Введите отчество пользователя");
                    _userModel.FatherName = Console.ReadLine() ?? "";
                    Console.WriteLine("Введите пол пользователя");
                    _userModel.Gender = Console.ReadLine() ?? "";
                    Console.WriteLine("Введите дату рождения пользователя Пример(Год.Месяц.Число)");
                    string bithday = Console.ReadLine() ?? "0000.00.00";
                    _userModel.Birthday = DateTime.Parse(bithday);
                    if (_userModel != null) ///activated model mapper
                        if (await _identityUser.AddUser(PTMKTest.Hepler.UserViewAndUserModelMapper.ReturnUserModelMapper(_userModel)) == 0)//Activate user creator methood
                            Console.WriteLine("Такой пользователь уже существует");
                        else
                            Console.WriteLine("пользователь создан");
                    break;

                case 2:
                    Console.WriteLine("Выберите действие\n1.Выбрать всех уникальных пользователей\n2Выбрать всех уникальных пользователей начинающихся с буквы F");
                    switch(Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                          List<UserModel> users = await _identityUser.SearchUniqUser();
                            foreach (UserModel model in users)
                            {
                                Console.WriteLine("Firstname" + " " + model.FirstName);
                                Console.WriteLine("Firstname" + " " + model.SecondName);
                                Console.WriteLine("Firstname" + " " + model.FatherName);
                                Console.WriteLine("Firstname" + " " + model.Gender);
                                Console.WriteLine("Birthday" + " " + Convert.ToString(model.Birthday ?? new DateTime()));
                                Console.WriteLine(Convert.ToString(DateTime.Now));
                            };
                            break;

                        case 2:
                          List<UserModel> users1 = await _identityUser.SearchUniqUser("F");
                            foreach (UserModel model in users1)
                            {
                                Console.WriteLine("Firstname" + " " + model.FirstName);
                                Console.WriteLine("Firstname" + " " + model.SecondName);
                                Console.WriteLine("Firstname" + " " + model.FatherName);
                                Console.WriteLine("Firstname" + " " + model.Gender);
                                Console.WriteLine("Birthday" + " " + Convert.ToString(model.Birthday ?? new DateTime()));
                                Console.WriteLine(Convert.ToString(DateTime.Now));
                            };
                            break;
                    }
                    break;

                case 3:
                   List<int> userId = await _identityUser.GenerateUserDb();//Activate user generator methood

                    ///if (userId.Count > 0)
                        Console.WriteLine("пользователи сгенерированы");
                        Console.ReadKey();
                    break;
            }
        }

    }
}

