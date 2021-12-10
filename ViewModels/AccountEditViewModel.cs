﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Models;
using FinanceManager.Core;

namespace FinanceManager.ViewModels
{
    public class AccountEditViewModel : ViewModelBase
    {
        private AccountViewModel? _editable;

        private bool _isVisible;

        public bool IsVisible
        {
            get 
            { 
                return this._isVisible;
            }
            set
            {
                if (this._editable != null)
                {
                    this._isVisible = value;
                }
                else
                {
                    this._isVisible = false;
                }
                OnPropertyChange();
            }
        }

        public AccountViewModel? Editable 
        { 
            get 
            { 
                return this._editable; 
            }
            set 
            {
                this._editable = value;
                if (this.VisibilityCheck())
                {
                    OnPropertyChange(nameof(this.Name));
                    OnPropertyChange(nameof(this.Balance));
                    OnPropertyChange(nameof(this.ToCount));
                    this._editable.PropertyChanged -= PropertyChanged;
                    this._editable.PropertyChanged += PropertyChanged;
                }
            }
        }

        public string Name
        {
            get 
            {
                if (this.VisibilityCheck())
                {
                    return this._editable.Name;
                }

                return string.Empty;
            }
            set
            {
                if (this.VisibilityCheck())
                {
                    this._editable.Name = value;
                }
            }
        }

        public double Balance
        {
            get 
            {
                if (this.VisibilityCheck())
                {
                    return _editable.Balance;
                }

                return 0d;
            }
            set
            {
                if (this.VisibilityCheck())
                {
                    this._editable.Balance = value;
                }
            }
        }

        public bool ToCount
        {
            get
            {
                if (this.VisibilityCheck())
                {
                    return this._editable.ToCount;
                }
                
                return false;
            }
            set
            {
                if (this.VisibilityCheck())
                {
                    this._editable.ToCount = value;
                }
            }
        }

        public AccountEditViewModel()
        {
        }

        public AccountEditViewModel(AccountViewModel account)
        {
            this.Editable = account;
        }

        private void PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(AccountViewModel.Balance):
                    OnPropertyChange(nameof(this.Balance));
                    break;
                case nameof(AccountViewModel.ToCount):
                    OnPropertyChange(nameof(this.ToCount));
                    break;
                case nameof(AccountViewModel.Name):
                    OnPropertyChange(nameof(this.Name));
                    break;
                default:
                    break;
            }
        }

        private bool VisibilityCheck()
        {
            if (this._editable != null)
            {
                return true;
            }

            this.IsVisible = false;
            return false;
        }
    }
}
