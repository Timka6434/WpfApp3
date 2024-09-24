using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketFinansistWPF.Models
{
     public partial class Account
    {
        private string _id {  get; set; }
        private string _accountName { get; set; }
        private decimal _balance { get; set; }
        private bool _isLocked { get; set; }
        private DateTime _dataCreateAccount {  get; set; }

        public Account(string name) 
        {
            _id = Guid.NewGuid().ToString();
            _accountName = name;
            _balance = 0;
            _isLocked = true;
            _dataCreateAccount = DateTime.Now;
        }
        public string GetAccountId() => _id;

        public string GetAccountName() => _accountName;
        public void SetAccountName(string SetName) => _accountName = SetName;

        public decimal GetBalance() => _balance;
        public void SetBalance(decimal Balance) => _balance = Balance;

        public bool IsLocked() => _isLocked;
        public void UnlockAccount() => _isLocked = false;

        public DateTime GetDataCreateAccount() => _dataCreateAccount;
    }
}
