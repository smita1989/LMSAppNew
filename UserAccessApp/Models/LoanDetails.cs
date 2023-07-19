using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace UserAccessApp.Models
{
    public class LoanDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        [Required]
        public int LoanNumber { get; set; }

        public Double? LoanAmount { get; set; }
        
        public string? LoanTerm { get; set; }
        public string BorrowerInfo { get; set; }
        [Required]
        public string PropertyInfo { get; set; }
        public int Status { get; set; }
        public Double? Loanfees { get; set; }
        public DateTime OriginationDate { get; set; }
        public string OriginalAccount { get; set; }
        public string LienInfo { get; set; }
        public string LoanDocuments { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        

    }
}
