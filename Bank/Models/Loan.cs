using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Loan
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("ApplicationUser")]
        [MaxLength(450)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int loan_balance { get; set; }

        public DateTime created_at { get; set; }



    }
}
