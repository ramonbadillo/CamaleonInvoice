namespace CamaleonInvoice.Models
{
    using System.Collections.Generic;

    public class DetasPlusTaxes
    {
        public List<DET> DET { get; set; }
        public decimal grabadas { get; set; }
        public decimal nograbada { get; set; }
        public decimal exoneradas { get; set; }
        public decimal gratuitas { get; set; }
    }
}