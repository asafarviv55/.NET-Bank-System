using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class PassBackOperation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public User owner { get; set; }

        public bool is_charge { get; set; }

        public float account_balance { get; set; }

        public DateTime created_at { get; set; }

    }
}
