﻿using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata
{
    public class Product
    {
        public string Name { get; private set; }

        public string UPC { get; private set; }

        public Money Price { get; private set; }

        public Product(string name, string uPC, Money price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name", "name required");
            if (string.IsNullOrWhiteSpace(uPC))
                throw new ArgumentException("uPC", "uPC required");
            if (price == null)
                throw new ArgumentException("price", "price required");
            Name = name;
            UPC = uPC;
            Price = price;
        }

        public Money ApplyTax(decimal percentage)
        {
            var taxAmount = GetTaxAmount(percentage);
            return new Money(Price.Amount + taxAmount, Price.Currency);
        }

        private decimal GetTaxAmount(decimal percentage)
        {
            return Math.Round((Price.Amount * percentage) / 100, 2);
        }

        public Money ApplyDicount(decimal percentageTax, decimal percentageDiscount)
        {
            var taxAmount = GetTaxAmount(percentageTax);
            var disCountAmount = GetTaxAmount(percentageDiscount);
            return new Money((Price.Amount + taxAmount) - disCountAmount, Price.Currency);
        }
    }
}