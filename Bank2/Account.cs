using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    public class Account
    {
        private decimal _balance;
        public AccountOwner Owner { get; }
        public AccountAdmin Admin { get; }

        public Account(AccountOwner owner, AccountAdmin admin, decimal initialDeposit)
        {
            if (initialDeposit < 100)
                throw new ArgumentException("Åbningsbeløbet skal være større end: 100Kr");

            Owner = owner;
            Admin = admin;
            _balance = initialDeposit;

            Console.WriteLine($"Hej {Owner.FullName}. Din konto er oprettet med {Admin.FullName} som admin.");
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Indsæt beløbet skal være større end 0");

            _balance += amount;
            NotifyUpdate();
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Udtræks beløbet skal være større end 0");
            if (_balance < amount)
                throw new InvalidOperationException("Ikke penge nok på konto");

            _balance -= amount;
            NotifyUpdate();
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        private void NotifyUpdate()
        {
            Console.WriteLine($"Din konto er blevet opdateret. Der står nu {_balance} kr.");
        }
    }
}
