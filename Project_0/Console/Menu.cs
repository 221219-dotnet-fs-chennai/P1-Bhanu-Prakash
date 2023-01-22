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
            System.Console.WriteLine("******************************************* Welcome to Online Trainer Platform **************************************");
            System.Console.WriteLine("[s] - To SignUp                           [l] - To Login                  [0] - To Exit");
            System.Console.WriteLine("Enter your response to continue");
            //System.Console.WriteLine("[l] - To Login");
            //System.Console.WriteLine("[0] - To Exit");
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
