using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    class BankAccount
    {

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { 
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();


        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Balança Inicial");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Valor do deposito deve ser positivo!");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Valor do saque deve ser positivo!");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidProgramException("Fundos não suficientes para realizar o saque.");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\t\tAmount\tNote");

            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}
