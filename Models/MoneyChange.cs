﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Models
{
    public enum ChangeType
    {
        Expenses,
        Income
    };

    public class MoneyChange
    {
        private int _id;
        private double _impact;
        private Account _account;
        private DateTime _date;
        private string _description;
        private Category _category;

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public double Impact 
        {
            get
            {
                return this._impact;
            }

            set
            {
                this._impact = value;
            }
        }

        public Account Account
        {
            get
            {
                return this._account;
            }

            set
            {
                if (this._account != null)
                {
                    if (this._account != value)
                    {
                        this._account.RemoveMoneyChange(this);
                        (value as Account).AddMoneyChange(this);
                        this._account = value;
                    }
                }
                else
                {
                    this._account = value;
                    (value as Account).AddMoneyChange(this);
                }
            }
        }

        public DateTime Date
        {
            get 
            { 
                return this._date; 
            }

            set
            {
                this._date = value;
            }
        }

        public string Description
        {
            get
            {
                return this._description;
            }

            set 
            { 
                this._description = value; 
            }
        }

        public Category Category
        {
            get 
            { 
                return this._category;
            }

            set
            {
                if (this._category != null)
                {
                    if (this._category != value)
                    {
                        this._category.RemoveMoneyChange(this);
                        this._category = value;
                        this._category.AddMoneyChange(this);
                    }
                }
                else
                {
                    this._category = value;
                    this._category.AddMoneyChange(this);
                }
            }
        }

        public ChangeType Type { get; set; }

        public MoneyChange() 
        {
            this._impact = 0;
            this._account = null;
            this._date = DateTime.Now;
            this._description = null;
        }

        public MoneyChange(double Impact, Account Account, DateTime Date, ChangeType Type, string Description, Category Category)
        {
            this.Impact = Impact;
            this.Account = Account;
            this.Date = Date;
            this.Description = Description;
            this.Type = Type;
            this.Category = Category;
        }
    }
}
