namespace BankAccount
{
    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public void Withdraw(decimal money)
        {
            this.Balance -= money;
        }

        public override decimal CalculateInterestForMonths(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterestForMonths(months);
            }
        }
    }
}
