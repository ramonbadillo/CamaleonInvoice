namespace CamaleonInvoice.Models
{
    using System.Collections.Generic;

    public class DET
    {
        public string numeroItem { get; set; }
        public string codigoProducto { get; set; }
        public string descripcionProducto { get; set; }
        public string cantidadItems { get; set; }
        public string unidad { get; set; }
        public string valorUnitario { get; set; }
        public string precioVentaUnitario { get; set; }
        public List<TotalImpuesto> totalImpuestos { get; set; }
        public string valorVenta { get; set; }
    }
}