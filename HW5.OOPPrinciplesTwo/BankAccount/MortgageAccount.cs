namespace BankAccount
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterestForMonths(int months)
        {
            if (this.Customer is Company)
            {
                if (months > 12)
                {
                    int low = 12;
                    int high = months - 12;
                    return base.CalculateInterestForMonths(high) + low * this.MonthlyInterestRate / 2;
                }
                else
                {
                    return months * this.MonthlyInterestRate / 2;
                }
            }
            else
            {
                if (months > 6)
                {
                    months -= 6;
                    return base.CalculateInterestForMonths(months);             
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}