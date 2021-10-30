using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace FinalProject.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string CreateDate { get; set; }
        public decimal? Total { get; set; }
        public int? Pending { get; set; }
        public int? IdProvider { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual Provider IdProviderNavigation { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
