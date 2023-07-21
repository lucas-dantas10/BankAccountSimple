using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BankAccount account = new BankAccount("Lucas Dantas", 100);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with balance of R${account.Balance},00");

            account.MakeDeposit(1200, DateTime.Now, "Payment");
            Console.WriteLine(account.Balance);

            account.MakeWithdrawal(120, DateTime.Now, "Play Station");
            Console.WriteLine(account.Balance);

            try
            {
                var invalidAccount = new BankAccount("Invalid", -55);
            } 
            catch (ArgumentOutOfRangeException err)
            {
                Console.WriteLine("Exception criando uma conta com valor negativo.");
                Console.WriteLine(err.ToString());
            }

            account.MakeWithdrawal(120, DateTime.Now, "Hammock");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
