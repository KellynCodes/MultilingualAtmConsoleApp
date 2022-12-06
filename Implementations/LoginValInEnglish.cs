using ATMCONSOLEAPPINTHREELANGUAGE;
using AtmConsoleAppInThreeLanguages.Enums;
using AtmConsoleAppInThreeLanguages.Properties;
using AtmConsoleAppInThreeLanguages.Transactions;

namespace AtmConsoleAppInThreeLanguages.Implementations
{

    internal class LoginValInEnglish
    {
        /// <summary>
        /// Action Event declaration
        /// </summary>
        private event Action<string> ErrorMessage;
        private event Action<string> SuccessMessage;

        public List<UserAccount> _userAccountList;
        private int _userAccountNumberInput;
        private int _userCardPin;
        private static string? Options { get; set; }
        private static int UserInput { get; set; }
        public static UserAccount ReturnUser {get; set;}
        /// <summary>
        /// Action delegates for printing messages to user
        /// </summary>

        public virtual void LogError(Action<string> method) => ErrorMessage += method;

        protected virtual void OnError(string message) => ErrorMessage.Invoke(message);
        public LoginValInEnglish()
        {
            _userAccountList = new List<UserAccount>()
            {
                new UserAccount()
                {
                    UserId = 1,
                    CardPin = 423234,
                    CardNumber = 123456789,
                    AccountNumber = 0669976019,
                    AccountBalance = 500000000,
                    AccountName = "Kelechi Amos",
                    FullName = "Kelechi Amos Omeh",
                    Bank = "Gt Bank",
                    Location = "New York City, London"
                },
                new UserAccount()
                {
                    UserId = 2,
                    CardPin = 123231,
                    CardNumber = 987654321,
                    AccountNumber = 423710377,
                    AccountBalance = 600000000,
                    AccountName = "Kennedy",
                    FullName = "John Kennedy",
                    Bank = "Access Bank",
                    Location = "San Francisco, America"
                },new UserAccount()
                {
                    UserId = 3,
                    CardPin = 565656,
                    CardNumber = 656565,
                    AccountNumber = 123456789,
                    AccountBalance = 600000000,
                    AccountName = "Kingsley",
                    FullName = "Kingsley Somtoo",
                    Bank = "Daimond Bank",
                    Location = "Japan"
                }
            };
        }



        public void LoginVal()
        {
            LoginValInEnglish ValEnglish = new();

            try
            {
                Program.Message("\nPlease:\t", "Enter you details for security purposes\n");
                Program.Message("\nPlease:\t", "Enter you Account Number\n");
                _userAccountNumberInput = int.Parse(Console.ReadLine() ?? string.Empty);
                Program.Message("\nPlease:\t", "Enter you CardPin\n");  
                _userCardPin = int.Parse(Console.ReadLine() ?? string.Empty);

                var unicUser = _userAccountList.FirstOrDefault(user => user.AccountNumber == _userAccountNumberInput);
                ReturnUser = unicUser;
                if (unicUser == null)
                {
                    Console.Clear();
                    /*ValEnglish.OnError($"Error Message from Action custom delegate");*/
                    Program.Message("\nError:\t", "User does'nt Exist");
                    LoginVal();
                }
                if (unicUser?.CardPin != _userCardPin)
                {
                    Program.Message("User does not exist", "Please try again");
                    LoginVal();
                }
                while (true)
                {
                    GetUser(unicUser, unicUser.AccountNumber);
                    break;
                }
            }
            catch (Exception exception)
            {
                Console.Clear();
                ValEnglish.OnError($"Error Message from Action custom delegate");
                Program.Message("\nPlease:\t", "Enter A valid inputs\n");
                Console.WriteLine(exception.Message);
                LoginVal();
            }
        }


        public static void GetUser(UserAccount account, int userAccountNumber)
        {
            LoginValInEnglish ValEnglish = new();

        start: ChooseTransactionTypeEnglish.ChooseTransactionType(account.AccountName);

            try
            {
                Options = Console.ReadLine();

                UserInput = Convert.ToInt32(Options);
                switch (UserInput)
                {

                    case (int)TransactionType.Deposit:
                        ChooseTransactionTypeEnglish.Deposit(userAccountNumber, account.AccountBalance, account.FullName);
                        break;
                    case (int)TransactionType.Withdrawal:
                        ChooseTransactionTypeEnglish.Withdrawal(userAccountNumber, account.AccountBalance, account.FullName);
                        break;
                    case (int)TransactionType.Transfer:
                        ChooseTransactionTypeEnglish.Transfer(account.FullName, account.AccountNumber, account.AccountBalance);
                        break;
                    case (int)TransactionType.CheckBalance:
                        ChooseTransactionTypeEnglish.CheckBalance(account.AccountBalance, account.FullName);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Entered value is not in the case");
                        goto start;
                }

            }
            catch (Exception exception)
            {
                ValEnglish.OnError($"Error Message from Action custom delegate");
                Program.Message("\nError:\t", $"{exception.Message} Here Men");
                goto start;
            }       

        }
     
    }
}
