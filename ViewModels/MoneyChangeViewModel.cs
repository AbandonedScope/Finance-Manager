﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Core;
using FinanceManager.Models;

namespace FinanceManager.ViewModels
{
    public class MoneyChangeViewModel : ViewModelBase
    {
        private MoneyChange? _moneyChange;
        private AccountViewModel? _accountViewModel;
        private CategoryViewModel? _categoryViewModel;

        public MoneyChange? MoneyChange
        {
            get 
            { 
                return _moneyChange; 
            }

            set 
            { 
                this._moneyChange = value;
                if (this._moneyChange != null)
                {
                    this._accountViewModel = new AccountViewModel(this._moneyChange.Account);
                    this._categoryViewModel = new CategoryViewModel(this._moneyChange.Category);
                }
                OnPropertyChange(nameof(this.Impact));
                OnPropertyChange(nameof(this.Account));
                OnPropertyChange(nameof(this.Date));
                OnPropertyChange(nameof(this.Description));
                OnPropertyChange(nameof(this.Category));
                OnPropertyChange(nameof(this.Type));
            }
        }

        public double Impact
        {
            get
            {
                if (this.MoneyChange != null)
                {
                    return this._moneyChange.Impact;
                }

                return 0d;
            }

            set
            {
                if (this.MoneyChange != null)
                {
                    this._moneyChange.Impact = value;
                }
                OnPropertyChange();
            }
        }

        public AccountViewModel? Account
        {
            get
            {
                if (this.MoneyChange != null)
                {
                    if (this.MoneyChange.Account != null)
                    {
                        return this._accountViewModel;
                    }
                }

                return null;
            }

            set
            {
                if (value != null)
                {
                    if (this.MoneyChange != null)
                    {
                        this.MoneyChange.Account = value.Account;
                        this._accountViewModel = value;
                        
                    }
                }

                OnPropertyChange();
            }
        }

        public DateTime Date
        {
            get
            {
                return this._moneyChange.Date;
            }

            set
            {
                this._moneyChange.Date = value;
                OnPropertyChange();
            }
        }

        public string Description
        {
            get
            {
                if (this.MoneyChange != null)
                {
                    return this._moneyChange.Description;
                }

                return string.Empty;
            }

            set
            {
                if (this.MoneyChange != null)
                {
                    this._moneyChange.Description = value;
                }
                OnPropertyChange();
            }
        }

        public CategoryViewModel? Category
        {
            get
            {
                if (this.MoneyChange != null)
                {
                    if (this.MoneyChange.Category != null)
                    {
                        return this._categoryViewModel;
                    }
                }

                return null;
            }

            set
            {
                if (value != null)
                {
                    if (this.MoneyChange != null)
                    {
                        this.MoneyChange.Category = (value as CategoryViewModel).Category;
                        this._categoryViewModel = value;
                    }
                }

                OnPropertyChange();
            }
        }

        public ChangeType Type
        {
            get
            {
                return this._moneyChange.Type;
            }
            set
            {
                this._moneyChange.Type = value;
                OnPropertyChange();
            }
        }

        public MoneyChangeViewModel()
        {
            this._moneyChange = new MoneyChange();
            this.PropertyChanged += DB_SaveChanges;
        }

        public MoneyChangeViewModel(MoneyChange change) : this()
        {

            this._moneyChange = change;
        }

        private void DB_SaveChanges(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.Category != null && this.Account != null)
            {
                Service.SaveChanges();
            }
        }
    }
}
