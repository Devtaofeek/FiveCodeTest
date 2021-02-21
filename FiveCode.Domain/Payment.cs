using FiveCode.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiveCode.Domain
{
    public class Payment : AuditableEntity

    {
        public int ID { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}