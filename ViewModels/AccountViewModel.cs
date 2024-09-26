using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PocketFinansistWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3.ViewModels
{
    public partial class AccountViewModel : ObservableObject
    {
        public ObservableCollection<Account> Accounts { get; set; }

        [ObservableProperty]
        private Account _account;

        public AccountViewModel()
        {
            Accounts = new ObservableCollection<Account>();
        }

        public void UnlockAccount()
        {
            Account.IsLocked = false;
        }

        [ObservableProperty]
        private string? _accountName;


        [RelayCommand]
        private void ActivateAccount()
        {

            if (Account.ID != null && Account.Balance >= 0)
            {
                Account.IsLocked = false;
            }
        }

        [RelayCommand]
        public void CreateAccount()
        {
            if (string.IsNullOrWhiteSpace(AccountName))
            {
                MessageBox.Show("Введите корректное имя для аккаунта!");
                return;
            }
            if (Accounts.Any(a=> a.AccountName == AccountName))
            {
                MessageBox.Show("Аккаунт с таким именем существует!");
                return;
            }
            var account = new Account(AccountName);

            Accounts.Add(account);
        }
    }
}
