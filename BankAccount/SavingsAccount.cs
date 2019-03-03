using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class SavingsAccount: Account
    {
        public int SavingRate { get; set; }

        public SavingsAccount(string account, string name,int amount, int rate) : base(account, name, amount)
        {
            SavingRate = rate;
        }

        public int AddInterest()
        {
            return 0;
        }

        public override string FileFormat()
        {
            return string.Format("{0},{1},{2},{3}", AccountNumber, Name, Amount,SavingRate);
        }
       

        //public override string ToString()
        //{
        //    return base.ToString()+string.Format("{0} \n", Name);
        //}

    }
}
