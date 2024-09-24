using PocketFinansistWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.ViewModels
{
    public partial class AccountViewModel
    {
        private Account _account;

        public string Id => _account.GetAccountId();
        public string AccountName => _account.GetAccountName();
        public decimal Balance => _account.GetBalance();
        public bool IsLocked => _account.IsLocked();
        public DateTime DataCreateAccount => _account.GetDataCreateAccount();

        public AccountViewModel(Account account)
        {
            _account = account;
        }

        public void UnlockAccount()
        {
            _account.UnlockAccount();
        }

    }
}
