using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Invoices
    {
       [Key]
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public decimal Value { get; set; }
        public  InvoiceState State{ get; set; }
        
    }
}
