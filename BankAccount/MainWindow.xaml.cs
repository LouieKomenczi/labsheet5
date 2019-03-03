using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Account> accountList = new ObservableCollection<Account>();
        public MainWindow()
        {
            InitializeComponent();

            Account b1 = new Account("17364517", "Joe Duffy", 0);
            Account b2 = new Account("56456445", "Peter Griffin", 0);
            Account b3 = new Account("34563457", "Jane Doe" , 0);
            Account b4 = new Account("34524424", "Liam Neel", 0);

            SavingsAccount s1 = new SavingsAccount("13423", "Al David",0, 6);
            SavingsAccount s2 = new SavingsAccount("23524", "Jogn Doe",0,7);
            accountList.Add(b1);
            accountList.Add(b2);
            accountList.Add(b3);
            accountList.Add(b4);
            accountList.Add(s1);
            accountList.Add(s2);
            lbxAccount.ItemsSource = accountList;

        }

        private void BtnDeposit_Click(object sender, RoutedEventArgs e)
        {
            Account selected = lbxAccount.SelectedItem as Account;
            for(int i=0; i<accountList.Count; i++)
            {
                Account acc = accountList.ElementAt(i);
                if (acc.AccountNumber.Equals (selected.AccountNumber))
                {
                    int x = 0;
                    
                    if(Int32.TryParse(tbx.Text, out x))
                    {
                        acc.Amount = acc.Amount + x ;
                        tbxInfo.Text = String.Format("Name:{0} \n Account Numebr:{1} \n Amount:{2} \n",acc.Name,acc.AccountNumber,acc.Amount);
                        accountList.ElementAt(i).Amount =acc.Amount;
                    }
                    else
                    {
                        MessageBox.Show("not valid amount");
                    }
                }
            }

            
          
        }

        private void LbxAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account acc = lbxAccount.SelectedItem as Account;
            if(acc is SavingsAccount)
            {
                SavingsAccount sacc = acc as SavingsAccount;
                tbxInfo.Text = String.Format("Name:{0} \n Account Numebr:{1} \n Amount:{2} \n Rate:{3}", sacc.Name, sacc.AccountNumber, sacc.Amount, sacc.SavingRate);
            }
            else
            {
                tbxInfo.Text = String.Format("Name:{0} \n Account Numebr:{1} \n Amount:{2} \n", acc.Name, acc.AccountNumber, acc.Amount);
            }
            
        }

        private void BtnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            Account selected = lbxAccount.SelectedItem as Account;
            for (int i = 0; i < accountList.Count; i++)
            {
                Account acc = accountList.ElementAt(i);
                if (acc.AccountNumber.Equals(selected.AccountNumber))
                {
                    int x = 0;

                    if (Int32.TryParse(tbx.Text, out x))
                    {
                        acc.Amount = acc.Amount - x;
                        tbxInfo.Text = String.Format("Name:{0} \n Account Numebr:{1} \n Amount:{2} \n", acc.Name, acc.AccountNumber, acc.Amount);
                        accountList.ElementAt(i).Amount = acc.Amount;
                    }
                    else
                    {
                        MessageBox.Show("not valid amount");
                    }
                }
            }


        }

        private void BtnAddInterest_Click(object sender, RoutedEventArgs e)
        {
            Account selected = lbxAccount.SelectedItem as Account;
            for (int i = 0; i < accountList.Count; i++)
            {
                Account acc = accountList.ElementAt(i);
                if (acc.AccountNumber.Equals(selected.AccountNumber))
                {
                    if (acc is SavingsAccount)
                    {
                        SavingsAccount sacc = acc as SavingsAccount;
                        sacc.Amount = sacc.Amount + (sacc.Amount * sacc.SavingRate/100);
                        accountList.ElementAt(i).Amount = sacc.Amount;
                        tbxInfo.Text = String.Format("Name:{0} \n Account Numebr:{1} \n Amount:{2} \n Rate:{3}", sacc.Name, sacc.AccountNumber, sacc.Amount, sacc.SavingRate);
                    }

                    else
                    {
                        MessageBox.Show("this is not a svaings account");
                    }
                }
            }              

        }

        private void WriteToFile(ObservableCollection<Account> account)
        {
            string[] acc = new string[account.Count];
            Account a;

            for (int i = 0; i < account.Count; i++)
            {
                a = account.ElementAt(i);
                acc[i] = a.FileFormat();            }

            File.WriteAllLines(@"E:\Temp\Account.txt", acc);

        }

        private void BtnToFile_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile(accountList);
            MessageBox.Show("saved");
        }
    }
}
