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
        [ObservableProperty]
        private Account _currentAccount;

        [ObservableProperty]
        private string _accountNameInput;
        
        [ObservableProperty]        
        ObservableCollection<Account> _accounts = new ObservableCollection<Account>();


        public ICommand NavigateCommand { get; }

        public MainViewModel()
        {
            NavigateCommand = new RelayCommand<object>(Navigate);
        }

        private void Navigate(object parameter)
        {
            if (parameter is NavigationService navigationService)
            {
                navigationService.Navigate(new Uri("Views/Page1.xaml", UriKind.Relative));
            }
        }

        [RelayCommand]
        private void ActivateAccount()
        {
            if (CurrentAccount == null)
            {
                MessageBox.Show("Аккаунт не создан!");
                return;
            }

            if (CurrentAccount.GetAccountName() != null)
            {
                CurrentAccount.UnlockAccount();
            }
        }

        [RelayCommand]
        public void CreateAccount()
        {
            if(string.IsNullOrWhiteSpace(AccountNameInput))
            {
                MessageBox.Show("Введите корректное имя для аккаунта!");
                return;
            }
            CurrentAccount = new Account(AccountNameInput);

            Accounts.Add(CurrentAccount);
        }
        
    }
}
