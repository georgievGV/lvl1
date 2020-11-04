using System;
using System.Collections.Generic;
using System.Text;

using ShoppingSpree.Common;

namespace ShoppingSpree.Model
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value.TrimEnd()))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMeg);
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NegativeMoneyExcMsg);
                }
                this.money = value;
            }
        }

        public IReadOnlyList<Product> Bag
        {
            get
            {
                return this.bag;
            }
        }

        public void AddProduct(Product product)
        {
            this.bag.Add(product);
        }
    }
}
