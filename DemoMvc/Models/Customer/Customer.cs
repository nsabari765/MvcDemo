﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc.Models.Customer
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        public long? PhoneNumber { get; set; }
    }
}
