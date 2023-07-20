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
        }
    }
}
