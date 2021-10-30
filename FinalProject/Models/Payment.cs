using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace FinalProject.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? IdInvoice { get; set; }
        public decimal? Amount { get; set; }

        [JsonIgnore]
        public virtual Invoice IdInvoiceNavigation { get; set; }
    }
}
