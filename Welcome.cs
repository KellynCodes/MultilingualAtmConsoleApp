﻿using AtmConsoleAppInThreeLanguages;
using AtmConsoleAppInThreeLanguages.Enums;
using AtmConsoleAppInThreeLanguages.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCONSOLEAPPINTHREELANGUAGE
{
    public static class Welcome
    {
        private static string _welcomeMessage;
        private static string _consoleTitle;
        public static void Message(string MessageTitle, string Message)
        {
            Console.Write(MessageTitle); Console.Write(Message);

        }

        public static void RunWelcome()
        {
            _consoleTitle = "Kellys Atm Machine";
            _welcomeMessage = "\n\n******Welcome to Kelly Int Limited*******\n\n";
            Console.Title = _consoleTitle;
            Console.WriteLine(_welcomeMessage);
            ChooseLanguage();
        }
        private static void ChooseLanguage()
        {

        Console.WriteLine("Choose your preferred language");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Nigeria Pidgin");
            Console.WriteLine("3. Igbo");

            try
            {

                string userChoice = Console.ReadLine();
            int userTransactionChoice = Convert.ToInt32(userChoice);
                if (userTransactionChoice > (int)TransactionType.NumberOfItemsInTheList)
                {
                    Console.Clear();
                    Message("\nSorry\t", "Number is not included in the list\n\n");
                    Message("Note:\t", "Enter only digits 1-3\n\n");
                    ChooseLanguage();
                }
                switch (userTransactionChoice)
                {
                    case (int)LanguageSwitch.English:
                        English.CallEnglishLanguageImplementations();
                        break;
                     case (int)LanguageSwitch.NigeriaPidgin:
                        NigeriaPidgin.CallNigeriaPidginLanguageImplementations();
                        break;
                    case (int)LanguageSwitch.Igbo:
                        Igbo.CallIgboLanguageImplementations();
                        break;
                    default: Console.WriteLine("Wrong Input");
                        break;
                }
            }
            catch
            {

                Console.Clear();
                Message("\nError:\t", "Please Try again\n");
                Message("\nNote:\t", "Enter only digits 1-3\n\n");
                ChooseLanguage();
            }
        }
    }
}