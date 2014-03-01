using System;
namespace BankAccount
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterestForMonths(int months)
        {
            if (this.Customer is Person)
            {
                return base.CalculateInterestForMonths(Math.Max(0, months - 3));                
            }
            else
            {
                return base.CalculateInterestForMonths(Math.Max(0, months - 2));
            }            
        }
    }
}
