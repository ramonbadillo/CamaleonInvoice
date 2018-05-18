namespace CamaleonInvoice.Models
{
    using System.Collections.Generic;

    public class Factura
    {
        public IDE IDE { get; set; }
        public EMI EMI { get; set; }
        public REC REC { get; set; }
        public List<DRF> DRF { get; set; }
        public CAB CAB { get; set; }
        public List<DET> DET { get; set; }
        public List<ADI> ADI { get; set; }
    }
}