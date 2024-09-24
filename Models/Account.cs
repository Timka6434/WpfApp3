using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PocketFinansistWPF.Models
{
     public partial class Account
     {
        private string _id;
        public string ID
        {
            get => _id;
        }


        private string _accountName;
        public string AccountName
        {
            get => _accountName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _accountName = value;
                }
                else
                {
                    throw new ArgumentException("Name is can't will null");
                }
            }
        }

        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value > 0)
                {
                    _balance = value;
                }
            }
        }

        private bool _isLocked;
        public bool IsLocked
        {
            get => _isLocked;
            set
            {
                if (_balance >= 0)
                {
                    _isLocked = value;  
                }
                else if(_balance < 0)
                {
                    _isLocked = true;
                }
            }
        }

        private DateTime _dataCreateAccount;
        public DateTime DataCreateAccount
        {
            get => _dataCreateAccount;
        }


        public Account(string name) 
        {
            _id = Guid.NewGuid().ToString();
            _accountName = name;
            _balance = 0;
            _isLocked = true;
            _dataCreateAccount = DateTime.Now;
        }
     }
}
