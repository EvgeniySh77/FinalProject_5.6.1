using System;

namespace FinalProject_5._6._1
{
    class Program
    {
        static void Main()
        {            
            ShowUserData();            
        }
        static string[] CreateArrayPets(int num)
        {
            var result = new string[num];
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"Введите кличку {i + 1}-го питомца");
                result[i] = Console.ReadLine();
            }
            return result;
        }

        static (string Name, string LastName, int Age, string[] PetNames, string[] FavColors) EnterUser()
        {
            (string Name, string LastName, int Age, string[] PetNames, string[] FavColors) User;
            do
            {
                Console.WriteLine("Введите имя");
                User.Name = Console.ReadLine();
            } while (CheckLetter(User.Name));

            do
            {
                Console.WriteLine("Введите фамилию");
                User.LastName = Console.ReadLine();
            } while (CheckLetter(User.LastName));

            string age;
            int intAge;
            do
            {
                Console.WriteLine("Введите возраст цифрами");
                age = Console.ReadLine();

            } while (CheckNum(age, out intAge));
            User.Age = intAge;

            string numOfPets = "";            
            int numElements = 0;            
            do
            {
                Console.WriteLine("У вас есть домашние питомцы? Да/Нет");
                string ans = Console.ReadLine();
                if (ans == "Да" || ans == "да")
                {
                    do
                    {
                        Console.WriteLine("Введите количество питомцев цифрами");
                        numOfPets = Console.ReadLine();
                    } while (CheckNum(numOfPets, out numElements));
                    
                }
                else if (ans == "Нет" || ans == "нет")
                    break;

            } while (CheckNum(numOfPets, out numElements));
            User.PetNames = CreateArrayPets(numElements);

            string colorsNum;
            int intColorsNum;
            do
            {
                Console.WriteLine("Введите количество ваших любимых цветов цифрами");
                colorsNum = Console.ReadLine();
            } while (CheckNum(colorsNum, out intColorsNum));

            User.FavColors = FavColors(intColorsNum);


            return User;
        }

        static string[] FavColors(int colorsNum)
        {            
            var favColors = new string[colorsNum];
            bool notColor = true;
            for (int i = 0; i < favColors.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Введите {i + 1}-й любимый цвет на английском с большой буквы");
                    favColors[i] = Console.ReadLine();
                    ConsoleColor color;
                    for (color = 0; (int)color < 15; color++)
                    {
                        if (string.Equals(favColors[i], Convert.ToString(color)))
                        { notColor = false; break; }                        
                    }
                } while (notColor);
            }
            return favColors;
        }

        static bool CheckLetter(string user)
        {
            for (int i = 0; i < user.Length; i++)
            {
                if (!char.IsLetter(user[i]))
                    return true;
            }
            return false;
        }

        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intNum))
            {
                if (intNum > 0)
                {
                    corrnumber = intNum;
                    return false;
                }
            }
            corrnumber = 0;
            return true;
        }

        static void ShowUserData()
        {
            string petNames = "";
            string favColors = "";
            (string Name, string LastName, int Age, string[] PetNames, string[] FavColors) User = EnterUser();
            
            Console.WriteLine($"Ваше имя - {User.Name}");
            
            Console.WriteLine($"Ваша фамилия - {User.LastName}");
            
            Console.WriteLine($"Ваш возраст - {User.Age}");
            
            Console.Write($"Клички ваших питомцев - ");
            for (int i = 0; i < User.PetNames.Length; i++)
                petNames += $"{User.PetNames[i]}, ";
            Console.Write($"{petNames.TrimEnd(',', ' ')}{Environment.NewLine}");
            
            Console.Write($"Ваши любимые цвета - ");
            for (int i = 0; i < User.FavColors.Length; i++)
                favColors += $"{User.FavColors[i]}, ";            
            Console.Write($"{favColors.TrimEnd(',', ' ')}{Environment.NewLine}");



            Console.ReadKey();
        }
    }
}
