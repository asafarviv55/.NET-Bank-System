using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string email { get; set; }

        public DateTime birth_date { get; set; }

        public string phone_number { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }

        public string created_by { get; set; }

    }
}
