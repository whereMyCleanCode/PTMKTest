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
            Console.WriteLine("Make a choise\n1.Create user \n2.Check user\n3.Generate user");
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
                    Console.WriteLine("Input user name");
                    _userModel.FirstName = Console.ReadLine() ?? "";
                    Console.WriteLine("Input user second name");
                    _userModel.SecondName = Console.ReadLine() ?? "";
                    Console.WriteLine("Input user father name");
                    _userModel.FatherName = Console.ReadLine() ?? "";
                    Console.WriteLine("Input user gender");
                    _userModel.Gender = Console.ReadLine() ?? "";
                    Console.WriteLine("Input bithday user  Example(Years.Month.Day)");
                    string bithday = Console.ReadLine() ?? "0000.00.00";
                    _userModel.Birthday = DateTime.Parse(bithday);
                    if (_userModel != null) ///activated model mapper
                        if (await _identityUser.AddUser(PTMKTest.Hepler.UserViewAndUserModelMapper.ReturnUserModelMapper(_userModel)) == 0)//Activate user creator methood
                            Console.WriteLine("this user exist");
                        else
                            Console.WriteLine("User Created!");
                    break;

                case 2:
                    Console.WriteLine("Make a choice\n1.Select all uniq user\n2Select all uniq user get startet with F");
                    switch(Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                          List<UserModel> users = await _identityUser.SearchUniqUser();
                            foreach (UserModel model in users)
                            {
                                Console.WriteLine(@"Firstname {model.Firstname} ");
                                Console.WriteLine("Firstname" + " " + model.SecondName + "\n");
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

                    ///if (userId.Count > 0)///
                        Console.WriteLine("User generated");
                        Console.ReadKey();
                    break;
            }
        }

    }
}

