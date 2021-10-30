using System;
using System.Collections.Generic;

#nullable disable

namespace FinalProject.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
