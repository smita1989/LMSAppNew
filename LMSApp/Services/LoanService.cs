using LMSApp.DBContext;
using LMSApp.Interface;
using LMSApp.Models;

namespace LMSApp.Services
{
    public class LoanService : ILoanService
    {
        private readonly UserAccessDBContext _dbContext;
        public LoanService(UserAccessDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<LoanDetails> GetAllLoans()
        {
            var loanDetails = _dbContext.LoanDetails.ToList();
            return loanDetails;
        }

        public LoanDetails GetLoanDetailsById(int LoanId)
        {
            return _dbContext.LoanDetails
                  .FirstOrDefault(e => e.LoanId == LoanId);
        }

        public void SaveLoanDetails(LoanDetails loanDetails)
        {
            _dbContext.LoanDetails.Add(loanDetails);
            _dbContext.SaveChanges();
        }

        public void UpdateLoanDetails(LoanDetails loanDetails)
        {
            LoanDetails entitity=_dbContext.LoanDetails.FirstOrDefault(e=>e.LoanId== loanDetails.LoanId);
            entitity.BorrowerInfo=loanDetails.BorrowerInfo;
            entitity.LoanNumber=loanDetails.LoanNumber;
            entitity.LoanDocuments=loanDetails.LoanDocuments;
            entitity.Status=loanDetails.Status;
            entitity.Loanfees = loanDetails.Loanfees;
            entitity.LienInfo=loanDetails.LienInfo;
            entitity.LoanAmount=loanDetails.LoanAmount;

            _dbContext.SaveChanges();
        }
    }
}
