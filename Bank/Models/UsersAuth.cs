﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class UsersAuth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public User owner { get; set; }


        public string username { get; set; }

        public string password { get; set; }

        public DateTime created_at { get; set; }



    }
}
