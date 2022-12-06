using ATMCONSOLEAPPINTHREELANGUAGE;
using AtmConsoleAppInThreeLanguages.Implementations;

namespace AtmConsoleAppInThreeLanguages.Transactions
{
    internal static class ChooseTransactionTypeEnglish
    {
        public static void ChooseTransactionType(string usersAccountName)
        {

            Program.Message($"Welcome {usersAccountName}\n\t", "Choose 1-3 for your preffered transactions\n");
            Program.Message("\t\t1.\t", "Deposit\n");
            Program.Message("\t\t2.\t", "Withdrawal\n");
            Program.Message("\t\t.3\t", "Transfer\n");
            Program.Message("\t\t4.\t", "Check Balance\n");

        }

        public static void CheckBalance(decimal accountBalance, string userfullName)
        {
                Console.WriteLine($"{userfullName} Your new balance is {accountBalance}");
            LoginValInEnglish.GetUser(LoginValInEnglish.ReturnUser, LoginValInEnglish.ReturnUser.AccountNumber);
        }

        public static void Deposit(int AccountNumber, decimal AccountBalance, string AccountFullName)
        {
start:
            try
            {
                Console.WriteLine("Enter Amount");
                int AmountToDeposit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Your Account Number");

                int DepositAccountNumber = Convert.ToInt32(Console.ReadLine());
                    decimal newBalance = AccountBalance += AmountToDeposit;
                    Program.Message($"\n{AccountFullName}\t", $"Your made a deposit of {AmountToDeposit} in your account. Your new balance is\t : {newBalance} ");
                    LoginValInEnglish.GetUser(LoginValInEnglish.ReturnUser, LoginValInEnglish.ReturnUser.AccountNumber);
            }
            catch (Exception errorException)
            {

                Program.Message("\nError:\t", $"{errorException.Message}");
                goto start;
            }
        }
        public static void Withdrawal(int AccountNumber, decimal AccountBalance, string AccountFullName)
        {
            begining:
            try
            {

                Console.WriteLine("Enter Amount");
                int amountToWidthraw = Convert.ToInt32(Console.ReadLine());
                    decimal newBalance = AccountBalance -= amountToWidthraw;
                    Program.Message($"\n{AccountFullName}\t", $"Your just withdrawed {amountToWidthraw} from your account, your new balance is:\t {newBalance} ");
                LoginValInEnglish.GetUser(LoginValInEnglish.ReturnUser, LoginValInEnglish.ReturnUser.AccountNumber); ;
            }
            catch (Exception errorException)
            {
                Program.Message("\nError:\t", $"{errorException.Message}");
                goto begining;
            }
        }

        public static void Transfer(string SenderFullName, int SenderAccountNumber, decimal SenderAccountBalance)
        {
            theBegining:
            try
            {
                LoginValInEnglish loginValidation = new ();
                var account = loginValidation._userAccountList;
                foreach (var user in account)
                {
                    Console.WriteLine("Enter Amount");
                    decimal AmountToTransfer = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter Your Account Number");

                    int ReceiverAccountNumberInput = Convert.ToInt32(Console.ReadLine());
                    var currentUser = account.FirstOrDefault(specificUser => specificUser.AccountNumber == ReceiverAccountNumberInput);
                    if (SenderAccountNumber == currentUser.AccountNumber)
                    {
                        Console.WriteLine("You Cannot Transfer money to your self");
                    }
                    else if (SenderAccountBalance < AmountToTransfer)
                    {
                        Console.WriteLine("Insuficient Balance");
                    }
                    else
                    {
                        currentUser.AccountBalance += AmountToTransfer;
                        SenderAccountBalance -= AmountToTransfer;
                        Console.WriteLine($"{SenderFullName} you just sent {AmountToTransfer} to {currentUser.FullName} and {AmountToTransfer} has been depisted from your account");
                        Program.Message($"\n{SenderFullName} Your new balance is", $"{SenderAccountBalance}");

                    }
                    LoginValInEnglish.GetUser(user, user.AccountNumber);
                }
            }
            catch (Exception exception)
            {
                Program.Message("\nError:", $"{exception.Message}");
                goto theBegining;

            }
        }
    }
}