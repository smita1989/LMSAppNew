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
     
        [HttpGet]
        public IActionResult GetAllLoanDetails()
        {
            var res = _loanService.GetAllLoans();
            if (res.Count() == 0)
            {
                return NotFound();
            }

            return Ok(res);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetLoanDetailsById(int id)
        {
            var res= _loanService.GetLoanDetailsById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        
        [HttpPost]
        public IActionResult SaveLoanDetails(LoanDetails loanDetails)
        {
            if (loanDetails == null)
            {
                return BadRequest("loanDetails is null.");
            }
            _loanService.SaveLoanDetails(loanDetails);
            return Ok();
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateLoanDetails(LoanDetails loanDetails)
        {
            if (loanDetails == null)
            {
                return BadRequest("loanDetails is null.");
            }
            _loanService.UpdateLoanDetails(loanDetails);
            return Ok();
        }

        public IActionResult SearchLoanDetails(string? FirstName,string? LastName,int? LoanNumber)
        {
            return Ok();
        }
        
    }
}
