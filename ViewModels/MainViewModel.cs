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
using System.Windows.Input;
using System.Windows.Navigation;

namespace WpfApp3.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<AccountViewModel> Accounts { get; set; }

        [ObservableProperty]
        private AccountViewModel _accountViewModel;

        [ObservableProperty]
        private string _accountName;

        public MainViewModel()
        {
            Accounts = new ObservableCollection<AccountViewModel>();
        }

        [RelayCommand]
        private void ActivateAccount()
        {

            if (_accountViewModel.Id != null)
            {
                _accountViewModel.UnlockAccount();
            }
        }

        [RelayCommand]
        public void CreateAccount()
        {
            if(string.IsNullOrWhiteSpace(AccountName))
            {
                MessageBox.Show("Введите корректное имя для аккаунта!");
                return;
            }
            var account = new Account(AccountName);
            var accountViewModel = new AccountViewModel(account);

            Accounts.Add(accountViewModel);
            AccountViewModel = accountViewModel;
        }
        
    }
}
