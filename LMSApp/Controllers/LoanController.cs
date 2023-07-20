using LMSApp.DBContext;
using LMSApp.Interface;
using LMSApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private UserAccessDBContext _dBContext;
        private readonly ILoanService _loanService;
        public LoanController(UserAccessDBContext dBContext,ILoanService loanService) {
            _dBContext = dBContext;
            _loanService = loanService;
        }
        // GET: api/<LoanController>
        [HttpGet]
        public IEnumerable<LoanDetails> Get()
        {
            var res = _loanService.GetAllLoans();
            return res;
        }

        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public LoanDetails Get(int id)
        {
            return _loanService.GetLoanDetailsById(id);
        }

        // POST api/<LoanController>
        [HttpPost]
        public void Post(LoanDetails loanDetails)
        {
            _loanService.SaveLoanDetails(loanDetails);
        }

        // PUT api/<LoanController>/5
        [HttpPut("{id}")]
        public void Put(LoanDetails loanDetails)
        {
            _loanService.UpdateLoanDetails(loanDetails);
        }

        
    }
}
