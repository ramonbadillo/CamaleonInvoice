namespace CamaleonInvoice.Models
{
    using System.Collections.Generic;

    public class CAB
    {
        public Inafectas inafectas { get; set; }
        public Gratuitas gratuitas { get; set; }
        public Gravadas gravadas { get; set; }
        public List<TotalImpuesto> totalImpuestos { get; set; }
        public string importeTotal { get; set; }
        public string tipoOperacion { get; set; }
        public List<Leyenda> leyenda { get; set; }
    }
}