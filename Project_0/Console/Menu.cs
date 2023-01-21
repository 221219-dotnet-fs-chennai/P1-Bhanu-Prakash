using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class Menu : IMenu
    {
        public void Display()
        {
            System.Console.WriteLine("Hello Trainee");
            System.Console.WriteLine("[s] - To SignUp");
            System.Console.WriteLine("[l] - To Login");
        }
        public string UserChoice()
        {
            string userInput = System.Console.ReadLine();
            switch(userInput)
            {
                case "s":
                    return "Signup";
                case "l":
                    return "Validate";
                case "0":
                    return "Exit";
                default:
                    System.Console.WriteLine("Please input a valid response");
                    System.Console.WriteLine("Please press Enter to continue");
                    System.Console.ReadLine();
                    return "Menu";
            }
        }
    }
}
