using LMSApp.Models;

namespace LMSApp.Interface
{
    public interface ILoanService
    {
        IEnumerable<LoanDetails> GetAllLoans();
        LoanDetails GetLoanDetailsById(int LoanId);
        void SaveLoanDetails(LoanDetails loanDetails);
        void UpdateLoanDetails(LoanDetails loanDetails);

    }
}
