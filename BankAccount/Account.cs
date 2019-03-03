using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public Account(string account, string name, int amount)
        {
            AccountNumber = account;
            Name = name;
            Amount = amount;
        }

        public Account()
        {

        }

        public override string ToString()
        {
            return string.Format(AccountNumber + " - " + Name);
        }

        public virtual string FileFormat()
        {
            return string.Format("{0},{1},{2}", AccountNumber, Name, Amount);
        }

    }
}
