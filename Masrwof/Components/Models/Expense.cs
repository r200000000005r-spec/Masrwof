using Masrwof.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masrwof.Components.Models
{
    public class Expense : InterfaceId
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount {  get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public string Category { get; set; }
    }
}
